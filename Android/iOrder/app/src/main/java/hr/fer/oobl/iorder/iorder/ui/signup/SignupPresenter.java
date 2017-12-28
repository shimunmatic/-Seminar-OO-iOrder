package hr.fer.oobl.iorder.iorder.ui.signup;

import javax.inject.Inject;

import hr.fer.oobl.iorder.iorder.base.BasePresenter;
import hr.fer.oobl.iorder.iorder.ui.router.Router;

public final class SignupPresenter extends BasePresenter<SignupContract.View> implements SignupContract.Presenter {

    @Inject
    Router router;

    public SignupPresenter(final SignupContract.View view) {
        super(view);
    }

    @Override
    public void navigateToContentScreen() {
        router.showMainScreen();
    }

    @Override
    public void signup() {
        doIfViewNotNull(view -> {
            final String email = view.getEmail();
            final String password = view.getPassword();
            final String name = view.getName();
            final String surname = view.getSurname();


            //TODO: Register on server view.navigateToContentScreen();
            view.navigateToContentScreen();
        });
    }
}
