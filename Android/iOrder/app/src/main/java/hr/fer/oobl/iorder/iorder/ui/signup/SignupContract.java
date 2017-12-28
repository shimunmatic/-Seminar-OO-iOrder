package hr.fer.oobl.iorder.iorder.ui.signup;

import hr.fer.oobl.iorder.iorder.base.BaseView;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;

public interface SignupContract {

    interface Presenter extends ScopedPresenter {

        void navigateToContentScreen();

        void signup();
    }

    interface View extends BaseView {

        void setEmailError(String error);

        void setNameError(String error);

        void setSurnameError(String error);

        void setPasswordError(String error);

        void setConfPasswordError(String error);

        void navigateToContentScreen();

        void setProgress(boolean visible);

        void hideErrors();

        String getEmail();

        String getPassword();

        void showErrorMessage(String error);

        String getName();

        String getSurname();
    }
}
