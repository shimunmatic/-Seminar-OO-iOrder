package hr.fer.oobl.iorder.iorder.injection.application.modules;

import android.content.Context;
import android.content.res.Resources;

import javax.inject.Singleton;

import dagger.Module;
import dagger.Provides;
import hr.fer.oobl.iorder.data.util.UserManager;
import hr.fer.oobl.iorder.iorder.base.IOrderApplication;
import hr.fer.oobl.iorder.iorder.injection.application.ForApplication;
import hr.fer.oobl.iorder.iorder.network.NetworkManager;
import hr.fer.oobl.iorder.iorder.network.SimpleNetworkManager;

@Module
public final class ApplicationModule {

    private final IOrderApplication iOrderApplication;

    public ApplicationModule(final IOrderApplication iOrderApplication) {
        this.iOrderApplication = iOrderApplication;
    }

    @Provides
    @Singleton
    IOrderApplication provideIOrderApplication() {
        return iOrderApplication;
    }

    @Provides
    @Singleton
    @ForApplication
    Context provideContext() {
        return iOrderApplication;
    }

    @Provides
    @Singleton
    UserManager provideUserManager() {
        return new UserManager(iOrderApplication);
    }

    @Provides
    @Singleton
    NetworkManager provideNetworkManager() {
        return new SimpleNetworkManager(iOrderApplication);
    }

    @Provides
    @Singleton
    Resources provideResources(@ForApplication final Context context) {
        return context.getResources();
    }

    public interface Exposes {

        IOrderApplication iOrderApplication();

        @ForApplication
        Context context();

        UserManager userManager();

        NetworkManager networkManager();

        Resources resources();
    }
}
