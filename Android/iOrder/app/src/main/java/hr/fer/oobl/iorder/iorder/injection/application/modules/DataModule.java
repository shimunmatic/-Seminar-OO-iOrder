package hr.fer.oobl.iorder.iorder.injection.application.modules;

import dagger.Module;
import hr.fer.oobl.iorder.iorder.base.IOrderApplication;

@Module
public final class DataModule {

    private final IOrderApplication iOrderApplication;

    public DataModule(final IOrderApplication iOrderApplication) {
        this.iOrderApplication = iOrderApplication;
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
