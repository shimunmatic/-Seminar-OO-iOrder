package hr.fer.oobl.iorder.iorder.ui.main;

import java.util.List;
import java.util.Map;

import hr.fer.oobl.iorder.domain.model.Product;
import hr.fer.oobl.iorder.iorder.base.BaseView;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;

public interface MainContract {

    interface View extends BaseView {

        void updateCartView(int quantity);

        void updateBill(double currentBill);

        void showError(String message);

        void fillViewState();

        void showOrderSuccess();
    }

    interface Presenter extends ScopedPresenter {

        void startScanner();

        void showBlackBoard();

        void incrementCart(Product product);

        void decrementCart(Product product);

        List<Product> getCartProducts();

        void sendOrder(long establishmentId, long locationId);

        void fetchCategories(long establishmentId);

        List<String> getExpandableTitles();

        Map<String,List<Product>> getExpandableItems();

        String getEstablishmentName();
    }
}
