package hr.fer.oobl.iorder.iorder.ui.login

import hr.fer.oobl.iorder.iorder.base.BaseView
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter

/**
 * Created by mmihalic on 19.12.2017..
 */
interface LoginContract {

    interface View : BaseView {
        fun getEmailInput(): String

        fun getPasswordInput(): String

        fun showProgress(visible: Boolean)

        fun setButtons(enable: Boolean)

        fun saveChanges()
    }

    interface Presenter : ScopedPresenter
}