package hr.fer.oobl.iorder.iorder.utils

import android.app.Activity
import android.content.Context
import android.net.ConnectivityManager
import android.net.NetworkInfo
import android.text.TextUtils

object CredentialsValidator {

    fun validateEmail(email: String): Boolean {
        return !TextUtils.isEmpty(email.trim { it <= ' ' }) && android.util.Patterns.EMAIL_ADDRESS.matcher(email).matches()
    }

    fun validatePassword(password: String): Boolean {
        return !TextUtils.isEmpty(password) && password.length >= 8
    }

    fun checkInternetConnection(activity: Activity): Boolean {
        val connectivityManager = activity.getSystemService(Context.CONNECTIVITY_SERVICE) as ConnectivityManager
        val networkInfo = connectivityManager.activeNetworkInfo
        return networkInfo != null && networkInfo.isConnected

    }

    fun validateNickname(nickname: String): Boolean {
        return !TextUtils.isEmpty(nickname.trim { it <= ' ' })
    }

    fun comparePasswords(password: String, confPass: String): Boolean {
        return password == confPass
    }
}
