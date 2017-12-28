package hr.fer.oobl.iorder.iorder.ui.login;

import android.os.Bundle;

import hr.fer.oobl.iorder.iorder.base.BaseView;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;

public interface LoginContract {

    interface Presenter extends ScopedPresenter {

        void onInit(final Bundle savedInstanceState);

        void onLoginClicked(String email, String password);

        void onRegisterClicked();

        void onAnimationEnd();

        void cancel();
    }

    interface View extends BaseView {

        void displayLoginComponents();

        void animateLogo(final Bundle savedInstanceState);

        String getEmailInput();

        String getPasswordInput();

        void showProgress(boolean visible);

        void setButtons(boolean enable);

        void saveChanges();

        void hideErrors();

        void displayEmailInvalidError();

        void displayPasswordInvalidError();

        void processOfflineMode();
    }
}
