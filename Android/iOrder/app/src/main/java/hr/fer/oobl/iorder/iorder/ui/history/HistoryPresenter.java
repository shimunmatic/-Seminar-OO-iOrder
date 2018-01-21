package hr.fer.oobl.iorder.iorder.ui.history;

import java.util.Collections;
import java.util.List;

import javax.inject.Inject;

import hr.fer.oobl.iorder.data.util.UserManager;
import hr.fer.oobl.iorder.domain.interactor.history.GetOrderHistoryForUserUseCase;
import hr.fer.oobl.iorder.domain.model.Order;
import hr.fer.oobl.iorder.domain.model.OrderHistoryRequest;
import hr.fer.oobl.iorder.iorder.base.BasePresenter;

public final class HistoryPresenter extends BasePresenter<HistoryContract.View> implements HistoryContract.Presenter {

    @Inject
    GetOrderHistoryForUserUseCase getOrderHistoryForUserUseCase;

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

    private void onHistoryFetched(final List<Order> orders) {
        doIfViewNotNull(view -> view.initializeRecyclerView(orders));
    }

    private void onHistoryError(final Throwable throwable) {
        doIfViewNotNull(view -> view.showError(throwable.getMessage()));
    }
}
