package hr.fer.oobl.iorder.iorder.injection.application.modules;

import javax.inject.Singleton;

import dagger.Module;
import dagger.Provides;
import hr.fer.oobl.iorder.data.network.IOrderService;
import hr.fer.oobl.iorder.iorder.base.IOrderApplication;
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

//    @Provides
//    @Singleton
//    NewsClient provideNewsClient(final NewsService newsService) {
//        return new NewsClientImpl(newsService);
//    }
//
//    @Provides
//    @Singleton
//    PostsDao provideArticlesDao(final PostsDatabase articlesDatabase) {
//        return articlesDatabase.articlesDao();
//    }
//
//    @Provides
//    @Singleton
//    PostsDatabase provideNewsDatabase(@ForApplication final Context context) {
//        return Room.databaseBuilder(context, PostsDatabase.class, PostsDatabase.NAME)
//                   .build();
//    }
//
//    @Provides
//    @Singleton
//    PostCrudder provideArticleCrudder(final PostsDao articlesDao, final DbToDomainMapper mapper) {
//        return new PostCrudderImpl(articlesDao, mapper);
//    }
//
//    public interface Exposes {
//
//        NewsClient newsClient();
//
//        PostCrudder articleCrudder();
//    }
}
