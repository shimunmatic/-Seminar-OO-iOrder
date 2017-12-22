package hr.fer.oobl.iorder.iorder.ui.login

import android.os.Bundle
import android.support.v7.app.AppCompatActivity
import android.view.View
import android.view.animation.*
import hr.fer.oobl.iorder.iorder.R
import hr.fer.oobl.iorder.iorder.utils.CredentialsValidator
import kotlinx.android.synthetic.main.login_layout.*
import javax.inject.Inject

class LoginActivity : AppCompatActivity(), LoginContract.View {


    @Inject
    internal var presenter: LoginContract.Presenter? = null

    @Inject
    internal var userManager: hr.fer.oobl.iorder.data.util.UserManager? = null


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.login_layout)

        etEmailLayout.isErrorEnabled = false
        etPasswordLayout.isErrorEnabled = false

        setFocusChangeListeners()
        startAnimations()
    }

    override fun getPasswordInput(): String {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun showProgress(visible: Boolean) {
        progressBar.visibility = if (visible) View.VISIBLE else View.GONE
    }

    override fun setButtons(enabled: Boolean) {
        login_btn.isClickable = enabled
        login_btn.isEnabled = enabled
        signup_button.isEnabled = enabled
        signup_button.isClickable = enabled
    }

    override fun saveChanges() {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun getEmailInput(): String {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    private fun setEmailError(errorMessage: String?) {
        etEmailLayout.error = errorMessage
    }

    private fun setPasswordError(errorMessage: String?) {
        etPasswordLayout.error = errorMessage
    }

    private fun setFocusChangeListeners() {
        etEmail.onFocusChangeListener = View.OnFocusChangeListener { _, _ ->
            if (!etPassword.isFocused) {
                if (CredentialsValidator.validatePassword(etPassword.text.toString())) {
                    setPasswordError(null)
                } else {
                    setPasswordError(getString(R.string.passwordError))
                }
            } else {
                setPasswordError(null)
            }
        }

        etPassword.onFocusChangeListener = View.OnFocusChangeListener { _, _ ->
            if (!etEmail.isFocused) {
                if (CredentialsValidator.validateEmail(etEmail.text.toString())) {
                    setEmailError(null)
                } else {
                    setEmailError(getString(R.string.emailError))
                }
            } else {
                setEmailError(null)
            }
        }
    }

    private fun startAnimations() {
        val translateAnimationLogo = TranslateAnimation(Animation.RELATIVE_TO_PARENT, 0f,
                Animation.RELATIVE_TO_PARENT, 0f, Animation.RELATIVE_TO_PARENT, 0.5f,
                Animation.RELATIVE_TO_PARENT, 0f)
        translateAnimationLogo.duration = 750
        translateAnimationLogo.fillAfter = true
        translateAnimationLogo.setAnimationListener(object : Animation.AnimationListener {

            override fun onAnimationStart(animation: Animation) {
                logo.setVisibility(View.VISIBLE)
            }

            override fun onAnimationEnd(animation: Animation) {
                val scale = ScaleAnimation(0.1f, 1f, 0.1f, 1f, Animation.RELATIVE_TO_SELF,
                        0.5f, Animation.RELATIVE_TO_SELF, 0.5f)
                scale.duration = 750
                scale.fillAfter = true
                scale.setAnimationListener(object : Animation.AnimationListener {

                    override fun onAnimationStart(animation: Animation) {

                    }

                    override fun onAnimationEnd(animation: Animation) {
                        val fadeIn = AlphaAnimation(0f, 1f)
                        fadeIn.interpolator = DecelerateInterpolator() //add this
                        fadeIn.duration = 1000
                        fadeIn.fillAfter = true
                        fadeIn.setAnimationListener(object : Animation.AnimationListener {

                            override fun onAnimationStart(animation: Animation) {
                                firstLayout.visibility = View.VISIBLE
                                secondLayout.visibility = View.VISIBLE
                                login_btn.visibility = View.VISIBLE
                                signup_button.visibility = View.VISIBLE
                            }

                            override fun onAnimationEnd(animation: Animation) {}

                            override fun onAnimationRepeat(animation: Animation) {

                            }
                        })
                        firstLayout.startAnimation(fadeIn)
                        secondLayout.startAnimation(fadeIn)
                        login_btn.startAnimation(fadeIn)
                        signup_button.startAnimation(fadeIn)
                    }

                    override fun onAnimationRepeat(animation: Animation) {

                    }
                })
            }

            override fun onAnimationRepeat(animation: Animation) {

            }
        })
        logo.startAnimation(translateAnimationLogo)
    }
}
