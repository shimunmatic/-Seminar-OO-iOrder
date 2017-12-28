package hr.fer.oobl.iorder.iorder.base;

import android.app.Application;

import com.facebook.stetho.Stetho;

import hr.fer.oobl.iorder.iorder.injection.ComponentFactory;
import hr.fer.oobl.iorder.iorder.injection.application.ApplicationComponent;

public final class IOrderApplication extends Application {

    private ApplicationComponent applicationComponent;

    @Override
    public void onCreate() {
        super.onCreate();
        Stetho.initializeWithDefaults(getApplicationContext());
        initApplicationComponent();
        injectMe();
    }

    public ApplicationComponent getApplicationComponent() {
        return applicationComponent;
    }

    private void injectMe() {
        applicationComponent.inject(this);
    }

    private void initApplicationComponent() {
        applicationComponent = ComponentFactory.createApplicationComponent(this);
    }
}
