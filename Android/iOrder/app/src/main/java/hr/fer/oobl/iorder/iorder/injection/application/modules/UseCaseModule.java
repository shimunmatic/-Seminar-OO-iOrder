package hr.fer.oobl.iorder.iorder.injection.application.modules;

import javax.inject.Singleton;

import dagger.Module;
import dagger.Provides;
import hr.fer.oobl.iorder.domain.interactor.login.GetLoginTokenUseCase;
import hr.fer.oobl.iorder.domain.repository.IOrderRepository;
import retrofit2.http.Path;

@Module
public final class UseCaseModule {

    @Provides
    @Singleton
    GetLoginTokenUseCase provideGetLoginTokenUseCase(final IOrderRepository iOrderRepository) {
        return new GetLoginTokenUseCase(iOrderRepository);
    }
//
//    @Provides
//    @Singleton
//    FetchNewDataUseCase provideFetchNewDataUseCase(final PostRepository newsRepository) {
//        return new FetchNewDataUseCase(newsRepository);
//    }
//
//    @Provides
//    @Singleton
//    FetchLocalDataUseCase provideFetchLocalDataUseCase(final PostRepository newsRepository) {
//        return new FetchLocalDataUseCase(newsRepository);
//    }
//
//    @Provides
//    @Singleton
//    RefreshDataUseCase provideRefreshDataUseCase(final PostRepository newsRepository) {
//        return new RefreshDataUseCase(newsRepository);
//    }
//
//    @Provides
//    @Singleton
//    FavorizeArticleUseCase provideFavorizeArticleUseCase(final PostRepository newsRepository) {
//        return new FavorizeArticleUseCase(newsRepository);
//    }
//
//    @Provides
//    @Singleton
//    FetchArticleByIdUseCase provideFetchArticleByIdUseCase(final PostRepository newsRepository) {
//        return new FetchArticleByIdUseCase(newsRepository);
//    }
//
//    @Provides
//    @Singleton
//    FetchMoreOlderDataUseCase provideFetchMoreOlderDataUseCase(final PostRepository newsRepository) {
//        return new FetchMoreOlderDataUseCase(newsRepository);
//    }
//
//    @Provides
//    @Singleton
//    ShowOnlyFavouriteArticlesUseCase provideShowOnlyFavouriteArticlesUseCase(final PostRepository newsRepository) {
//        return new ShowOnlyFavouriteArticlesUseCase(newsRepository);
//    }
//
    public interface Exposes {

        GetLoginTokenUseCase getLoginTokenUseCase();
    }
}
