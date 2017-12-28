package hr.fer.oobl.iorder.iorder.network;

import android.content.Context;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;

public class SimpleNetworkManager implements NetworkManager {

    private final ConnectivityManager manager;

    public SimpleNetworkManager(final Context context) {
        manager = (ConnectivityManager) context.getSystemService(Context.CONNECTIVITY_SERVICE);
    }

    @Override
    public boolean isNetworkAvailable() {
        final NetworkInfo networkInfo = manager.getActiveNetworkInfo();
        return networkInfo != null && networkInfo.isConnectedOrConnecting();
    }
}
