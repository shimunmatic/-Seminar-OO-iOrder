package hr.fer.oobl.iorder.iorder.ui.login;

import android.os.Bundle;

import javax.inject.Inject;

import hr.fer.oobl.iorder.data.util.SharedPrefsManager;
import hr.fer.oobl.iorder.domain.interactor.login.GetLoginTokenUseCase;
import hr.fer.oobl.iorder.domain.model.UserCredentials;
import hr.fer.oobl.iorder.iorder.base.BasePresenter;
import hr.fer.oobl.iorder.iorder.network.NetworkManager;
import hr.fer.oobl.iorder.iorder.ui.router.Router;
import hr.fer.oobl.iorder.iorder.utils.CredentialsValidator;

public final class LoginPresenter extends BasePresenter<LoginContract.View> implements LoginContract.Presenter {

    @Inject
    NetworkManager networkManager;

    @Inject
    SharedPrefsManager sharedPrefsManager;

    @Inject
    GetLoginTokenUseCase getLoginTokenUseCase;

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
    public void onLoginClicked(final String username, final String password) {
        doIfViewNotNull(view -> {
            view.hideErrors();
            boolean inputValid = true;
            if (!CredentialsValidator.validateNickname(username)) {
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
                    addSubscription(getLoginTokenUseCase.execute(new UserCredentials(username, password))
                            .subscribeOn(backgroundScheduler)
                            .observeOn(mainThreadScheduler)
                            .subscribe(token -> onGetLoginTokenSuccess(token, username, password),
                                    this::onGetLoginTokenError));
                } else {
                    view.processOfflineMode();
                }
            }
        });
    }

    private void onGetLoginTokenError(final Throwable throwable) {
        doIfViewNotNull(view -> {
            view.showProgress(false);
            view.showError(throwable.getMessage());
        });
    }

    private void onGetLoginTokenSuccess(final String loginToken, final String username, final String password) {
        sharedPrefsManager.set("username", username);
        sharedPrefsManager.set("password", password);
        sharedPrefsManager.set("token", loginToken);
        doIfViewNotNull(LoginContract.View::startScanner);
        router.showScanner();
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
