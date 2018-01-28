package hr.fer.oobl.iorder.iorder.ui.main;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.inject.Inject;

import hr.fer.oobl.iorder.data.util.SharedPrefsManager;
import hr.fer.oobl.iorder.domain.interactor.category.GetCategoriesWithProductsUseCase;
import hr.fer.oobl.iorder.domain.interactor.order.ProcessOrderUseCase;
import hr.fer.oobl.iorder.domain.model.Category;
import hr.fer.oobl.iorder.domain.model.Establishment;
import hr.fer.oobl.iorder.domain.model.OrderRequest;
import hr.fer.oobl.iorder.domain.model.Product;
import hr.fer.oobl.iorder.iorder.base.BasePresenter;
import hr.fer.oobl.iorder.iorder.ui.router.Router;

public final class MainPresenter extends BasePresenter<MainContract.View> implements MainContract.Presenter {

    private static final String ESTABLISHMENT_ERROR = "Establishment identification number invalid. Try to scan QR code again...";
    private static final String USERNAME_ERROR = "Username is not set correctly. Try to log in again...";

    @Inject
    Router router;

    @Inject
    ProcessOrderUseCase orderUseCase;

    @Inject
    GetCategoriesWithProductsUseCase getCategoriesWithProductsUseCase;

    @Inject
    SharedPrefsManager sharedPrefsManager;

    private Establishment currentEstablishment;
    private List<Product> cartProducts;
    private List<String> expandableTitles;
    private Map<String, List<Product>> expandableItems;

    public MainPresenter(final MainContract.View view) {
        super(view);
        cartProducts = new ArrayList<>();
        expandableTitles = new ArrayList<>();
        expandableItems = new HashMap<>();
    }

    @Override
    public void startScanner() {
        router.showScanner();
    }

    @Override
    public void showBlackBoard() {
        router.showHistory(currentEstablishment.getId(), currentEstablishment.getName());
    }

    @Override
    public void incrementCart(final Product product) {
        if (cartProducts.contains(product)) {
            if (product.getQuantity().equals("0")) {
                cartProducts.remove(product);
            }
            doIfViewNotNull(view -> view.updateCartView(getCurrentQuantity()));
        } else {
            cartProducts.add(product);
            doIfViewNotNull(view -> view.updateCartView(getCurrentQuantity()));
        }
        doIfViewNotNull(view -> view.updateBill(getCurrentBill()));
    }

    @Override
    public void decrementCart(final Product product) {
        if (product.getQuantity().equals("0")) {
            cartProducts.remove(product);
            doIfViewNotNull(view -> view.updateCartView(getCurrentQuantity()));
        } else {
            doIfViewNotNull(view -> view.updateCartView(getCurrentQuantity()));
        }
        doIfViewNotNull(view -> view.updateBill(getCurrentBill()));
    }

    @Override
    public List<Product> getCartProducts() {
        return cartProducts;
    }

    @Override
    public void sendOrder() {
        final String username = sharedPrefsManager.get("username", "");
        try {
            final long establishmentId = Long.parseLong(sharedPrefsManager.get("establishmentId", ""));
            final long locationId = Long.parseLong(sharedPrefsManager.get("locationId", ""));
            if (establishmentId == 0L || locationId == 0L) {
                doIfViewNotNull(view -> view.showError(ESTABLISHMENT_ERROR));
            }
            if (!username.isEmpty()) {
                addSubscription(orderUseCase.execute(new OrderRequest(cartProducts, username, locationId, establishmentId))
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
        doIfViewNotNull(view -> view.updateCartView(0));
        cartProducts.clear();
        doIfViewNotNull(MainContract.View::showOrderSuccess);
    }

    @Override
    public void fetchCategories() {
        try {
            final long establishmentId = Long.parseLong(sharedPrefsManager.get("establishmentId", ""));
            if (establishmentId == 0L) {
                doIfViewNotNull(view -> view.showError(ESTABLISHMENT_ERROR));
            }

            addSubscription(getCategoriesWithProductsUseCase.execute(establishmentId)
                                                            .subscribeOn(backgroundScheduler)
                                                            .observeOn(mainThreadScheduler)
                                                            .subscribe(this::onCategoriesFetchedSuccessfully, this::onCategoriesFetchedError));
        } catch (final NumberFormatException ne) {
            doIfViewNotNull(view -> view.showError(ESTABLISHMENT_ERROR));
        }
    }

    @Override
    public List<String> getExpandableTitles() {
        return expandableTitles;
    }

    @Override
    public Map<String, List<Product>> getExpandableItems() {
        return expandableItems;
    }

    @Override
    public String getEstablishmentName() {
        return currentEstablishment.getName();
    }

    private void onCategoriesFetchedError(final Throwable throwable) {
        doIfViewNotNull(view -> view.showError(throwable.getMessage()));
    }

    private void onCategoriesFetchedSuccessfully(final Establishment establishment) {
        currentEstablishment = establishment;
        final List<Category> categories = establishment.getCategoryList();

        for (final Category category : categories) {
            expandableTitles.add(category.getName());
            expandableItems.put(category.getName(), category.getProducts());
        }
        doIfViewNotNull(MainContract.View::fillViewState);
    }

    private int getCurrentQuantity() {
        int currentQuantity = 0;
        for (Product product : cartProducts) {
            currentQuantity += Integer.parseInt(product.getQuantity());
        }
        return currentQuantity;
    }

    private double getCurrentBill() {
        double currentBill = 0.0;
        for (Product product : cartProducts) {
            currentBill += Integer.parseInt(product.getQuantity()) * Double.parseDouble(product.getFormattedPrice());
        }
        return currentBill;
    }
}
