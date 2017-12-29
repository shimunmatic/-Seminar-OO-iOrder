package hr.fer.oobl.iorder.iorder.ui.main;

import javax.inject.Inject;

import hr.fer.oobl.iorder.iorder.base.BasePresenter;
import hr.fer.oobl.iorder.iorder.ui.router.Router;

public final class MainPresenter extends BasePresenter<MainContract.View> implements MainContract.Presenter {

    @Inject
    Router router;

    public MainPresenter(final MainContract.View view) {
        super(view);
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

    }
}
