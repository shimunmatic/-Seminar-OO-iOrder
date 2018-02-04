package hr.fer.oobl.iorder.iorder.injection.activity;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;

import hr.fer.oobl.iorder.iorder.base.IOrderApplication;
import hr.fer.oobl.iorder.iorder.injection.ComponentFactory;
import hr.fer.oobl.iorder.iorder.injection.application.ApplicationComponent;

public abstract class DaggerActivity extends AppCompatActivity {

    private ActivityComponent activityComponent;

    @Override
    protected void onCreate(@Nullable final Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        inject(getActivityComponent());
    }

    public ActivityComponent getActivityComponent() {
        if (activityComponent == null) {
            activityComponent = ComponentFactory.createActivityComponent(this, getApplicationComponent());
        }

        return activityComponent;
    }

    private ApplicationComponent getApplicationComponent() {
        return ((IOrderApplication) getApplication()).getApplicationComponent();
    }

    protected abstract void inject(final ActivityComponent activityComponent);
}
