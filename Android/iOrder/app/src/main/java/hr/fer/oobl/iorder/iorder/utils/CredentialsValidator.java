package hr.fer.oobl.iorder.iorder.utils;

import android.app.Activity;
import android.content.Context;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.text.TextUtils;

public class CredentialsValidator {

    public static boolean validateEmail(String email) {
        return !TextUtils.isEmpty(email.trim())
                && android.util.Patterns.EMAIL_ADDRESS.matcher(email).matches();
    }

    public static boolean validatePassword(String password) {
        return !TextUtils.isEmpty(password) && password.length() >= 8;
    }

    public static boolean checkInternetConnection(Activity activity) {
        ConnectivityManager connectivityManager =
                (ConnectivityManager) activity.getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo networkInfo = connectivityManager.getActiveNetworkInfo();
        if (networkInfo != null && networkInfo.isConnected()) {
            return true;
        }

        return false;
    }

    public static boolean validateNickname(String nickname) {
        return !TextUtils.isEmpty(nickname.trim());
    }

    public static boolean comparePasswords(String password, String confPass) {
        return password.equals(confPass);
    }
}
