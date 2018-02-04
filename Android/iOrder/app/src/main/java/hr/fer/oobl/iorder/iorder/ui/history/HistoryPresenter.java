package hr.fer.oobl.iorder.iorder.ui.history;

import java.util.Collections;
import java.util.List;

import javax.inject.Inject;

import hr.fer.oobl.iorder.data.util.SharedPrefsManager;
import hr.fer.oobl.iorder.domain.interactor.history.GetOrderHistoryForUserUseCase;
import hr.fer.oobl.iorder.domain.interactor.order.ProcessOrderUseCase;
import hr.fer.oobl.iorder.domain.model.Order;
import hr.fer.oobl.iorder.domain.model.OrderRequest;
import hr.fer.oobl.iorder.domain.model.Product;
import hr.fer.oobl.iorder.iorder.base.BasePresenter;
import hr.fer.oobl.iorder.iorder.ui.router.Router;

public final class HistoryPresenter extends BasePresenter<HistoryContract.View> implements HistoryContract.Presenter {

    @Inject
    GetOrderHistoryForUserUseCase getOrderHistoryForUserUseCase;

    @Inject
    SharedPrefsManager sharedPrefsManager;

    @Inject
    ProcessOrderUseCase orderUseCase;

    @Inject
    Router router;

    private static final String ESTABLISHMENT_ERROR = "Establishment identification number invalid. Try to scan QR code again...";
    private static final String USERNAME_ERROR = "Username is not set correctly. Try to log in again...";
    private static final String ORDER_SUCCESS = "Order processed successfully again! :)";

    private List<Order> orderHistory = Collections.emptyList();

    public HistoryPresenter(final HistoryContract.View view) {
        super(view);
    }

    @Override
    public List<Order> getHistory() {
        return orderHistory;
    }

    @Override
    public void fetchHistory(long establishmentId) {
        addSubscription(getOrderHistoryForUserUseCase.execute(establishmentId)
                                                     .subscribeOn(backgroundScheduler)
                                                     .observeOn(mainThreadScheduler)
                                                     .subscribe(this::onHistoryFetched, this::onHistoryError));
    }

    @Override
    public void orderAgain(final List<Product> products) {
        final String username = sharedPrefsManager.get("username", "");
        try {
            final long establishmentId = Long.parseLong(sharedPrefsManager.get("establishmentId", ""));
            final long locationId = Long.parseLong(sharedPrefsManager.get("locationId", ""));
            if (establishmentId == 0L || locationId == 0L) {
                doIfViewNotNull(view -> view.showError(ESTABLISHMENT_ERROR));
            }
            if (!username.isEmpty()) {
                addSubscription(orderUseCase.execute(new OrderRequest(products, username, locationId, establishmentId))
                                            .subscribeOn(backgroundScheduler)
                                            .observeOn(mainThreadScheduler)
                                            .subscribe(this::onOrderSuccessfullyProcessed,
                                                       this::onOrderFailed));
            } else {
                doIfViewNotNull(view -> view.showError(USERNAME_ERROR));
            }
        } catch (final NumberFormatException ne) {
            doIfViewNotNull(view -> view.showError(ESTABLISHMENT_ERROR));
        }
    }

    private void onOrderFailed(final Throwable throwable) {
        doIfViewNotNull(view -> view.showError(throwable.getMessage()));
    }

    private void onOrderSuccessfullyProcessed(final Void aVoid) {
        doIfViewNotNull(view -> view.showMessage(ORDER_SUCCESS));
        router.showMainScreen();
    }

    private void onHistoryFetched(final List<Order> orders) {
        doIfViewNotNull(view -> view.initializeRecyclerView(orders));
    }

    private void onHistoryError(final Throwable throwable) {
        doIfViewNotNull(view -> view.showError(throwable.getMessage()));
    }
}
