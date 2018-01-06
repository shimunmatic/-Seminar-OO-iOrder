package hr.fer.oobl.iorder.iorder.ui.main;

import java.util.List;

import hr.fer.oobl.iorder.data.model.Product;
import hr.fer.oobl.iorder.iorder.base.BaseView;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;

public interface MainContract {

    interface View extends BaseView {

        void updateCartView(int quantity);

        void updateBill(double currentBill);
    }

    interface Presenter extends ScopedPresenter {

        void startScanner();

        void showCart();

        void showBlackBoard();

        void incrementCart(Product product);

        void decrementCart(Product product);

        List<Product> getCartProducts();
    }
}
