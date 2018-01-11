package hr.fer.oobl.iorder.iorder.ui.main;

import java.util.ArrayList;
import java.util.List;

import javax.inject.Inject;

import hr.fer.oobl.iorder.data.model.Product;
import hr.fer.oobl.iorder.iorder.base.BasePresenter;
import hr.fer.oobl.iorder.iorder.ui.router.Router;

public final class MainPresenter extends BasePresenter<MainContract.View> implements MainContract.Presenter {

    @Inject
    Router router;

    private List<Product> cartProducts;

    public MainPresenter(final MainContract.View view) {
        super(view);
        cartProducts = new ArrayList<>();
    }

    @Override
    public void startScanner() {
        router.showScanner();
    }

    @Override
    public void showCart() {
        //fetch current

        router.popUpCart();
    }

    @Override
    public void showBlackBoard() {
        router.showHistory();
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

    public int getCurrentQuantity() {
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
