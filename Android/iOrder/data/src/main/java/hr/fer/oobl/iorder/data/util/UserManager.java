package hr.fer.oobl.iorder.data.util;

import android.content.Context;
import android.content.SharedPreferences;


public final class UserManager {

    private final SharedPreferences sharedPreferences;
    private static final String USER_INFO = "user_info";

    public UserManager(final Context context) {
        sharedPreferences = context.getSharedPreferences(USER_INFO, Context.MODE_PRIVATE);
    }

    public String get(final String key, final String defaultValue) {
        return sharedPreferences.getString(key, defaultValue);
    }

    public boolean isSet(final String key) {
        return sharedPreferences.contains(key);
    }

    public void set(final String key, final String value) {
        sharedPreferences.edit().putString(key, value).apply();
    }

    public void delete(final String key) {
        sharedPreferences.edit().remove(key).apply();
    }
}
