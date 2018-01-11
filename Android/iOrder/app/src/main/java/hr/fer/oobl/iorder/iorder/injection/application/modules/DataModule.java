package hr.fer.oobl.iorder.iorder.injection.application.modules;

import javax.inject.Singleton;

import dagger.Module;
import dagger.Provides;
import hr.fer.oobl.iorder.data.network.client.IOrderClient;
import hr.fer.oobl.iorder.data.network.client.IOrderClientImpl;
import hr.fer.oobl.iorder.data.network.service.IOrderService;
import hr.fer.oobl.iorder.data.util.AccessTokenStorage;
import hr.fer.oobl.iorder.iorder.base.IOrderApplication;
import hr.fer.oobl.iorder.iorder.utils.OrderManager;
import okhttp3.OkHttpClient;
import okhttp3.logging.HttpLoggingInterceptor;
import retrofit2.Retrofit;
import retrofit2.adapter.rxjava.RxJavaCallAdapterFactory;
import retrofit2.converter.gson.GsonConverterFactory;

@Module
public final class DataModule {

    private final IOrderApplication iOrderApplication;

    public DataModule(final IOrderApplication iOrderApplication) {
        this.iOrderApplication = iOrderApplication;
    }

    @Provides
    HttpLoggingInterceptor provideHttpLoggingInterceptor() {
        final HttpLoggingInterceptor interceptor = new HttpLoggingInterceptor();
        interceptor.setLevel(HttpLoggingInterceptor.Level.BODY);

        return interceptor;
    }

    @Provides
    @Singleton
    OkHttpClient provideOkhttpClient(final HttpLoggingInterceptor interceptor) {
        final OkHttpClient.Builder builder = new OkHttpClient.Builder();
        builder.interceptors().add(interceptor);

        return builder.build();
    }

    @Provides
    @Singleton
    Retrofit provideRetrofit(final OkHttpClient okHttpClient) {
        //TODO: Add base URL
        return new Retrofit.Builder().baseUrl("")
                                     .client(okHttpClient)
                                     .addConverterFactory(GsonConverterFactory.create())
                                     .addCallAdapterFactory(RxJavaCallAdapterFactory.create())
                                     .build();
    }

    @Provides
    @Singleton
    IOrderService provideNewsService(final Retrofit retrofit) {
        return retrofit.create(IOrderService.class);
    }

    @Provides
    @Singleton
    OrderManager provideOrderManager() {
        return new OrderManager();
    }

    @Provides
    @Singleton
    IOrderClient provideIOrederClient(final IOrderService iOrderService) {
        return new IOrderClientImpl(iOrderService);
    }

    @Provides
    @Singleton
    AccessTokenStorage provideAccessTokenStorage() {
        return new AccessTokenStorage();
    }

    public interface Exposes {

        OrderManager orderManager();

        IOrderClient iOrderClient();

        AccessTokenStorage accessTokenStorage();
    }
}
