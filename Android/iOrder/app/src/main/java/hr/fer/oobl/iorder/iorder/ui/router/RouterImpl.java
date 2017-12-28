package hr.fer.oobl.iorder.iorder.ui.router;

import android.app.Activity;
import android.content.Intent;
import android.support.v4.app.FragmentManager;

import javax.inject.Inject;

import hr.fer.oobl.iorder.iorder.ui.main.MainActivity;
import hr.fer.oobl.iorder.iorder.ui.signup.SignUpActivity;

public final class RouterImpl implements Router {

    @Inject
    Activity activity;

    @Inject
    FragmentManager fragmentManager;

    public RouterImpl(final Activity activity, final FragmentManager fragmentManager) {
        this.activity = activity;
        this.fragmentManager = fragmentManager;
    }

    @Override
    public void showSignUp() {
        Intent intent = new Intent(activity, SignUpActivity.class);
        activity.startActivity(intent);
    }

    @Override
    public void showMainScreen() {
        Intent intent = new Intent(activity, MainActivity.class);
        activity.startActivity(intent);
    }
}
