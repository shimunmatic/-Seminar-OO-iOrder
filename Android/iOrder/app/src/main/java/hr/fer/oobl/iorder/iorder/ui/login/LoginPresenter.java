package hr.fer.oobl.iorder.iorder.ui.login;

import android.os.Bundle;

import javax.inject.Inject;

import hr.fer.oobl.iorder.iorder.base.BasePresenter;
import hr.fer.oobl.iorder.iorder.network.NetworkManager;
import hr.fer.oobl.iorder.iorder.ui.router.Router;
import hr.fer.oobl.iorder.iorder.utils.CredentialsValidator;

public final class LoginPresenter extends BasePresenter<LoginContract.View> implements LoginContract.Presenter {

    @Inject
    NetworkManager networkManager;

    @Inject
    Router router;

    public LoginPresenter(final LoginContract.View view) {
        super(view);
    }

    @Override
    public void onInit(final Bundle savedInstanceState) {
        doIfViewNotNull(view -> view.animateLogo(savedInstanceState));
    }

    @Override
    public void onLoginClicked(final String email, final String password) {
        doIfViewNotNull(view -> {
            view.hideErrors();
            boolean inputValid = true;
            if (!CredentialsValidator.validateEmail(email)) {
                view.displayEmailInvalidError();
                inputValid = false;
            }
            if (!CredentialsValidator.validatePassword(password)) {
                view.displayPasswordInvalidError();
                inputValid = false;
            }

            if (inputValid) {
                if (networkManager.isNetworkAvailable()) {
                    view.showProgress(true);
                    router.showMainScreen();
                    //TODO: Backend authentication
                } else {
                    view.processOfflineMode();
                    //TODO: Offline mode, database storage
                }
            }
        });
    }

    @Override
    public void onRegisterClicked() {
        router.showSignUp();
    }

    @Override
    public void onAnimationEnd() {
        doIfViewNotNull(LoginContract.View::displayLoginComponents);
    }

    @Override
    public void cancel() {

    }
}
