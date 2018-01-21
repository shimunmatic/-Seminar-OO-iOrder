package hr.fer.oobl.iorder.iorder.ui.signup;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.TextInputEditText;
import android.support.design.widget.TextInputLayout;
import android.support.v7.widget.Toolbar;
import android.widget.Button;
import android.widget.ProgressBar;
import android.widget.Toast;

import javax.inject.Inject;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnClick;
import butterknife.OnFocusChange;
import hr.fer.oobl.iorder.iorder.R;
import hr.fer.oobl.iorder.iorder.base.BaseActivity;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;
import hr.fer.oobl.iorder.iorder.injection.activity.ActivityComponent;
import hr.fer.oobl.iorder.iorder.utils.CredentialsValidator;

import static android.view.View.GONE;
import static android.view.View.VISIBLE;

public final class SignUpActivity extends BaseActivity implements SignupContract.View {

    @BindView(R.id.signUpToolbar)
    Toolbar toolbar;

    @BindView(R.id.etEmail)
    TextInputEditText etEmail;

    @BindView(R.id.etUsername)
    TextInputEditText etUsername;

    @BindView(R.id.etName)
    TextInputEditText etName;

    @BindView(R.id.etSurname)
    TextInputEditText etSurname;

    @BindView(R.id.etPassword)
    TextInputEditText etPassword;

    @BindView(R.id.etConfirmPass)
    TextInputEditText etConfirmPass;

    @BindView(R.id.etEmailLayout)
    TextInputLayout etEmailLayout;

    @BindView(R.id.etUsernameLayout)
    TextInputLayout etUsernameLayout;

    @BindView(R.id.etNameLayout)
    TextInputLayout etNameLayout;

    @BindView(R.id.etSurnameLayout)
    TextInputLayout etSurnameLayout;

    @BindView(R.id.etPasswordLayout)
    TextInputLayout etPasswordLayout;

    @BindView(R.id.etConfirmPassLayout)
    TextInputLayout etConfirmPassLayout;

    @BindView(R.id.signup_button)
    Button signupButton;

    @BindView(R.id.progressBar1)
    ProgressBar progressBar;

    @Inject
    SignupContract.Presenter presenter;

    @Override
    protected void onCreate(@Nullable final Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.register_layout);
        ButterKnife.bind(this);

        setupToolbar();
    }

    @Override
    public void onResume() {
        super.onResume();
        signupButton.setEnabled(true);
    }

    @Override
    protected void inject(final ActivityComponent activityComponent) {
        activityComponent.inject(this);
    }

    @OnFocusChange(R.id.etUsername)
    public void checkEmailError() {
        if (!etEmail.isFocused()) {
            if (CredentialsValidator.validateEmail(etEmail.getText().toString())) {
                setEmailError(null);
            } else {
                setEmailError(getString(R.string.emailError));
            }
        } else {
            setEmailError(null);
        }
    }

    @OnFocusChange(R.id.etUsername)
    public void checkUsernameError() {
        if (!etUsername.isFocused()) {
            if (CredentialsValidator.validateNickname(etUsername.getText().toString())) {
                setUsernameError(null);
            } else {
                setUsernameError(getString(R.string.usernameError));
            }
        } else {
            setUsernameError(null);
        }
    }

    @OnFocusChange(R.id.etPassword)
    public void checkPasswordError() {
        if (!etPassword.isFocused()) {
            if (CredentialsValidator.validatePassword(etPassword.getText().toString())) {
                setPasswordError(null);
            } else {
                setPasswordError(getString(R.string.passwordError));
            }
        } else {
            setPasswordError(null);
        }
    }

    @OnFocusChange(R.id.etName)
    public void checkNameError() {
        if (!etName.isFocused()) {
            if (CredentialsValidator.validateNickname(etName.getText().toString())) {
                setNameError(null);
            } else {
                setNameError(getString(R.string.nameError));
            }
        } else {
            setNameError(null);
        }
    }

    @OnFocusChange(R.id.etSurname)
    public void checkSurnameError() {
        if (!etSurname.isFocused()) {
            if (CredentialsValidator.validateNickname(etSurname.getText().toString())) {
                setSurnameError(null);
            } else {
                setSurnameError(getString(R.string.surnameError));
            }
        } else {
            setSurnameError(null);
        }
    }

    @OnFocusChange(R.id.etConfirmPass)
    public void checkConfPassError() {
        if (!etConfirmPass.isFocused()) {
            if (CredentialsValidator.comparePasswords(etPassword.getText().toString(),
                    etConfirmPass.getText().toString())) {
                setConfPasswordError(null);
            } else {
                setConfPasswordError(getString(R.string.passwordError));
            }
        } else {
            setConfPasswordError(null);
        }
    }

    @OnClick(R.id.signup_button)
    public void signup() {
        setProgress(true);
        signupButton.setEnabled(false);
        presenter.signup();
    }

    @Override
    public void setUsernameError(final String error) {
        etUsernameLayout.setError(error);
    }

    @Override
    public void setEmailError(final String error) {
        etEmailLayout.setError(error);
    }

    @Override
    public void setNameError(final String error) {
        etNameLayout.setError(error);
    }

    @Override
    public void setSurnameError(final String error) {
        etSurnameLayout.setError(error);
    }

    @Override
    public void setPasswordError(final String error) {
        etPasswordLayout.setError(error);
    }

    @Override
    public void setConfPasswordError(final String error) {
        etConfirmPassLayout.setError(error);
    }

    @Override
    public void navigateToContentScreen() {
        setProgress(false);
        Toast.makeText(this, "Scanner is starting...", Toast.LENGTH_SHORT).show();
        presenter.navigateToContentScreen();
    }

    @Override
    public void setProgress(final boolean visible) {
        progressBar.setVisibility(visible ? VISIBLE : GONE);
    }

    @Override
    public void hideErrors() {
        setEmailError(null);
        setUsernameError(null);
        setPasswordError(null);
        setNameError(null);
        setSurnameError(null);
        setConfPasswordError(null);
    }

    @Override
    public String getEmail() {
        return etEmail.getText().toString();
    }

    @Override
    public String getUsername() {
        return etUsername.getText().toString();
    }

    @Override
    public String getPassword() {
        return etPassword.getText().toString();
    }

    @Override
    public void showErrorMessage(final String message) {
        setProgress(false);
        Toast.makeText(getApplicationContext(), message, Toast.LENGTH_LONG).show();
    }

    @Override
    public String getName() {
        return etName.getText().toString();
    }

    @Override
    public String getSurname() {
        return etSurname.getText().toString();
    }

    @Override
    public void displayEmailInvalidError() {
        setEmailError(getString(R.string.emailError));
    }

    @Override
    public void displayPasswordInvalidError() {
        setEmailError(getString(R.string.passwordError));
    }

    @Override
    public void displayUsernameInvalidError() {
        setEmailError(getString(R.string.usernameError));
    }

    @Override
    public String getConfPassword() {
        return etConfirmPass.getText().toString();
    }

    @Override
    public void displaConfPassInvalidError() {
        setEmailError(getString(R.string.passwordError));
    }

    @Override
    public void displaySurnameInvalidError() {
        setEmailError(getString(R.string.surnameError));
    }

    @Override
    public void displayNameInvalidError() {
        setEmailError(getString(R.string.nameError));
    }

    private void setupToolbar() {
        toolbar.setNavigationIcon(R.drawable.ic_back);
        toolbar.setNavigationOnClickListener(view1 -> onBackPressed());
    }

    @Override
    public ScopedPresenter getPresenter() {
        return presenter;
    }
}
