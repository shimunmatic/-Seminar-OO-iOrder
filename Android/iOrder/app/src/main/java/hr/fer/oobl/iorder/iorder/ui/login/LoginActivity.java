package hr.fer.oobl.iorder.iorder.ui.login;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.design.widget.TextInputEditText;
import android.support.design.widget.TextInputLayout;
import android.util.Log;
import android.view.View;
import android.view.animation.AlphaAnimation;
import android.view.animation.Animation;
import android.view.animation.DecelerateInterpolator;
import android.view.animation.TranslateAnimation;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import javax.inject.Inject;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnFocusChange;
import hr.fer.oobl.iorder.data.util.Constants;
import hr.fer.oobl.iorder.data.util.UserManager;
import hr.fer.oobl.iorder.iorder.R;
import hr.fer.oobl.iorder.iorder.base.BaseActivity;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;
import hr.fer.oobl.iorder.iorder.injection.activity.ActivityComponent;
import hr.fer.oobl.iorder.iorder.utils.CredentialsValidator;

public final class LoginActivity extends BaseActivity implements LoginContract.View {

    @BindView(R.id.logo)
    ImageView logo;

    @BindView(R.id.mainLayout)
    LinearLayout mainLayout;

    @BindView(R.id.etUsernameLayout)
    TextInputLayout etUsernameLayout;

    @BindView(R.id.etPasswordLayout)
    TextInputLayout etPasswordLayout;

    @BindView(R.id.etUsername)
    TextInputEditText etUsername;

    @BindView(R.id.etPassword)
    TextInputEditText etPassword;

    @BindView(R.id.login_btn)
    Button loginButton;

    @BindView(R.id.signup_button)
    TextView signUpButton;

    @BindView(R.id.progressBar)
    ProgressBar loginProgressBar;

    @BindView(R.id.firstLayout)
    LinearLayout firstLayout;

    @BindView(R.id.secondLayout)
    LinearLayout secondLayout;

    @Inject
    LoginContract.Presenter presenter;

    @Inject
    UserManager userManager;

    @Override
    protected void inject(@NonNull final ActivityComponent activityComponent) {
        activityComponent.inject(this);
    }

    @Override
    protected void onResume() {
        super.onResume();
        loginProgressBar.setVisibility(View.GONE);
        loginButton.setVisibility(View.VISIBLE);
    }

    @Override
    protected void onCreate(@Nullable final Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.login_layout);
        ButterKnife.bind(this);

        presenter.onInit(savedInstanceState);
        initListeners();
    }

    private void initListeners() {
        loginButton.setOnClickListener(v -> presenter.onLoginClicked(etUsername.getText().toString(), etPassword.getText().toString()));
        signUpButton.setOnClickListener(v -> presenter.onRegisterClicked());
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

    public void setUsernameError(final String error) {
        etUsernameLayout.setError(error);
    }

    private void setEmailError(final String errorMessage) {
        etUsernameLayout.setError(errorMessage);
    }

    private void setPasswordError(final String errorMessage) {
        etPasswordLayout.setError(errorMessage);
    }

    @Override
    public void showProgress(final boolean visible) {
        loginProgressBar.setVisibility(visible ? View.VISIBLE : View.GONE);
        loginButton.setVisibility(visible ? View.GONE : View.VISIBLE);
    }

    @Override
    public void setButtons(final boolean enabled) {
        loginButton.setClickable(enabled);
        loginButton.setEnabled(enabled);
        signUpButton.setEnabled(enabled);
        signUpButton.setClickable(enabled);
    }

    @Override
    public void saveChanges() {
        userManager.set(Constants.USER_KEY, etUsername.getText().toString());
        userManager.set(Constants.PASSWORD_KEY, etPassword.getText().toString());
    }

    @Override
    public void displayLoginComponents() {
        firstLayout.setVisibility(View.VISIBLE);
        secondLayout.setVisibility(View.VISIBLE);
        loginButton.setVisibility(View.VISIBLE);
        signUpButton.setVisibility(View.VISIBLE);
    }

    public void setInitialFields(final String email, final String password) {
        etUsername.setText(email);
        etPassword.setText(password);
    }

    @Override
    public void animateLogo(final Bundle savedInstanceState) {
        final String username = userManager.get("username", "");
        final String password = userManager.get("password", "");

        if (savedInstanceState != null) {
            return;
        }

        TranslateAnimation translateAnimationLogo =
                new TranslateAnimation(Animation.RELATIVE_TO_PARENT, 0f,
                        Animation.RELATIVE_TO_PARENT, 0f, Animation.RELATIVE_TO_PARENT, 0.5f,
                        Animation.RELATIVE_TO_PARENT, 0f);
        translateAnimationLogo.setDuration(750);
        translateAnimationLogo.setFillAfter(true);
        translateAnimationLogo.setAnimationListener(new Animation.AnimationListener() {

            @Override
            public void onAnimationStart(Animation animation) {
                logo.setVisibility(View.VISIBLE);
            }

            @Override
            public void onAnimationEnd(Animation animation) {
                Animation fadeIn = new AlphaAnimation(0, 1);
                fadeIn.setInterpolator(new DecelerateInterpolator()); //add this
                fadeIn.setDuration(1000);
                fadeIn.setFillAfter(true);
                fadeIn.setAnimationListener(new Animation.AnimationListener() {

                    @Override
                    public void onAnimationStart(Animation animation) {
                        mainLayout.setVisibility(View.VISIBLE);
                    }

                    @Override
                    public void onAnimationEnd(Animation animation) {
                        setInitialFields(username, password);
                        if (CredentialsValidator.checkInternetConnection(LoginActivity.this)) {
                            final String authToken = userManager.get("authToken", "");

                            if (!authToken.equals("")) {
                                Handler handler = new Handler();
                                handler.postDelayed(() -> presenter.onLoginClicked(username, password), 1000);
                            }
                        } else {
                            processOfflineMode();
                        }
                    }

                    @Override
                    public void onAnimationRepeat(Animation animation) {

                    }
                });
                mainLayout.startAnimation(fadeIn);
            }

            @Override
            public void onAnimationRepeat(Animation animation) {

            }
        });
        logo.startAnimation(translateAnimationLogo);
    }

    @Override
    public void processOfflineMode() {
        Toast.makeText(this, "No internet connection, you cannot proceed.", Toast.LENGTH_SHORT).show();
    }

    @Override
    public void showError(final String message) {
        Toast.makeText(this, message, Toast.LENGTH_SHORT).show();
    }

    @Override
    public void startScanner() {
        Toast.makeText(this, "Starting scanner...", Toast.LENGTH_SHORT).show();
    }

    @Override
    public String getEmailInput() {
        return etUsername.getText().toString();
    }

    @Override
    public void hideErrors() {
        etUsernameLayout.setError(null);
        etPasswordLayout.setError(null);
    }

    @Override
    public void displayEmailInvalidError() {
        setEmailError(getString(R.string.emailError));
    }

    @Override
    public void displayPasswordInvalidError() {
        setPasswordError(getString(R.string.passwordError));
    }

    @Override
    public String getPasswordInput() {
        return etPassword.getText().toString();
    }

    @Override
    public ScopedPresenter getPresenter() {
        return presenter;
    }

    @Override
    public void onStop() {
        super.onStop();
        presenter.cancel();
    }
}
