package hr.fer.oobl.iorder.iorder.injection.activity.modules;

import android.app.Activity;
import android.content.Context;
import android.support.v4.app.FragmentManager;
import android.view.LayoutInflater;

import dagger.Module;
import dagger.Provides;
import hr.fer.oobl.iorder.iorder.injection.activity.ActivityScope;
import hr.fer.oobl.iorder.iorder.injection.activity.DaggerActivity;
import hr.fer.oobl.iorder.iorder.injection.activity.ForActivity;
import hr.fer.oobl.iorder.iorder.ui.router.Router;
import hr.fer.oobl.iorder.iorder.ui.router.RouterImpl;

@Module
public final class ActivityModule {

    private final DaggerActivity daggerActivity;

    public ActivityModule(final DaggerActivity daggerActivity) {
        this.daggerActivity = daggerActivity;
    }

    @Provides
    @ActivityScope
    @ForActivity
    Context provideActivityContext() {
        return daggerActivity;
    }

    @Provides
    @ActivityScope
    Activity provideActivity() {
        return daggerActivity;
    }

    @Provides
    @ActivityScope
    FragmentManager provideFragmentManager() {
        return daggerActivity.getSupportFragmentManager();
    }

    @Provides
    @ActivityScope
    Router provideRouter(final FragmentManager fragmentManager) {
        return new RouterImpl(daggerActivity, fragmentManager);
    }

    @Provides
    @ActivityScope
    LayoutInflater provideLayoutInflater(@ForActivity final Context context) {
        return LayoutInflater.from(context);
    }

    public interface Exposes {

        Activity activity();

        @ForActivity
        Context context();

        FragmentManager fragmentManager();

        Router router();

        LayoutInflater layoutInflater();
    }
}
