package hr.fer.oobl.iorder.iorder.ui.main;

import hr.fer.oobl.iorder.iorder.base.BaseView;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;

public interface MainContract {

    interface View extends BaseView {

    }

    interface Presenter extends ScopedPresenter {

        void startScanner();

        void showCart();

        void showBlackBoard();
    }
}
