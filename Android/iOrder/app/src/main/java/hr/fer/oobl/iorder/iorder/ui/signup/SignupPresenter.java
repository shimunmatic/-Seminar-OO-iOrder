package hr.fer.oobl.iorder.iorder.ui.signup;

import javax.inject.Inject;

import hr.fer.oobl.iorder.data.util.SharedPrefsManager;
import hr.fer.oobl.iorder.domain.interactor.login.GetLoginTokenUseCase;
import hr.fer.oobl.iorder.domain.interactor.signup.SignUpRequestUseCase;
import hr.fer.oobl.iorder.domain.model.UserCredentials;
import hr.fer.oobl.iorder.domain.model.UserRegistration;
import hr.fer.oobl.iorder.iorder.base.BasePresenter;
import hr.fer.oobl.iorder.iorder.ui.router.Router;
import hr.fer.oobl.iorder.iorder.utils.CredentialsValidator;

public final class SignupPresenter extends BasePresenter<SignupContract.View> implements SignupContract.Presenter {

    @Inject
    Router router;

    @Inject
    SharedPrefsManager sharedPrefsManager;

    @Inject
    GetLoginTokenUseCase getLoginTokenUseCase;

    @Inject
    SignUpRequestUseCase signUpRequestUseCase;

    public SignupPresenter(final SignupContract.View view) {
        super(view);
    }

    @Override
    public void navigateToContentScreen() {
        router.showScanner();
    }

    @Override
    public void signup() {
        doIfViewNotNull(view -> {
            final String email = view.getEmail();
            final String username = view.getUsername();
            final String password = view.getPassword();
            final String name = view.getName();
            final String surname = view.getSurname();

            boolean inputValid = true;
            if (!CredentialsValidator.validateEmail(email)) {
                view.displayEmailInvalidError();
                inputValid = false;
            }
            if (!CredentialsValidator.validateNickname(username)) {
                view.displayUsernameInvalidError();
                inputValid = false;
            }

            if (!CredentialsValidator.validateNickname(name)) {
                view.displayNameInvalidError();
                inputValid = false;
            }

            if (!CredentialsValidator.validateNickname(surname)) {
                view.displaySurnameInvalidError();
                inputValid = false;
            }

            if (!CredentialsValidator.validatePassword(password)) {
                view.displayPasswordInvalidError();
                inputValid = false;
            }

            if (!CredentialsValidator.comparePasswords(password, view.getConfPassword())) {
                view.displaConfPassInvalidError();
                inputValid = false;
            }

            if (inputValid) {
                final UserRegistration userRegistration = new UserRegistration(username, name, surname, email, password);
                addSubscription(signUpRequestUseCase.execute(userRegistration).subscribeOn(backgroundScheduler)
                                                    .observeOn(mainThreadScheduler)
                                                    .subscribe(aVoid -> onUserSuccessfullyRegistered(username, password),
                                                               this::onUserFailedToRegister));
            } else {
                view.showErrorMessage("Invalid input");
            }
        });
    }

    private void onUserFailedToRegister(final Throwable throwable) {
        doIfViewNotNull(view -> view.showErrorMessage(throwable.getMessage()));
    }

    private void onUserSuccessfullyRegistered(final String username, final String password) {
        sharedPrefsManager.set("username", username);
        sharedPrefsManager.set("password", password);
        addSubscription(getLoginTokenUseCase.execute(new UserCredentials(username, password))
                                            .subscribeOn(backgroundScheduler)
                                            .observeOn(mainThreadScheduler)
                                            .subscribe(this::onUserSuccessfullyLoggedIn, this::onUserFailedToRegister));
    }

    private void onUserSuccessfullyLoggedIn(final String token) {
        sharedPrefsManager.set("token", token);
        doIfViewNotNull(SignupContract.View::navigateToContentScreen);
    }
}
