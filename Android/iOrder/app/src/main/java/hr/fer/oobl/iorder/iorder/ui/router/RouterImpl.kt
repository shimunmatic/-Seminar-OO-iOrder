package hr.fer.oobl.iorder.iorder.ui.router

import android.app.Activity
import android.support.v4.app.FragmentManager

import javax.inject.Inject

class RouterImpl(@field:Inject
                 internal var activity: Activity, @field:Inject
                 internal var fragmentManager: FragmentManager) : Router {

    override fun closeScreen() {
        fragmentManager.popBackStack()
    }

    override fun startLogin() {
        //        fragmentManager.beginTransaction()
        //                       .replace(android.R.id.content, LoginFragment.getInstance())
        //                       .commit();
    }
}
