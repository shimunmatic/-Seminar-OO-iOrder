package hr.fer.oobl.iorder.iorder.injection.application.modules;

import javax.inject.Singleton;

import dagger.Module;
import dagger.Provides;
import hr.fer.oobl.iorder.domain.interactor.category.GetCategoriesWithProductsUseCase;
import hr.fer.oobl.iorder.domain.interactor.establishment.GetEstablishmentFromQRCodeUseCase;
import hr.fer.oobl.iorder.domain.interactor.history.GetOrderHistoryForUserUseCase;
import hr.fer.oobl.iorder.domain.interactor.login.GetLoginTokenUseCase;
import hr.fer.oobl.iorder.domain.interactor.order.ProcessOrderUseCase;
import hr.fer.oobl.iorder.domain.interactor.signup.SignUpRequestUseCase;
import hr.fer.oobl.iorder.domain.repository.IOrderRepository;

@Module
public final class UseCaseModule {

    @Provides
    @Singleton
    GetLoginTokenUseCase provideGetLoginTokenUseCase(final IOrderRepository iOrderRepository) {
        return new GetLoginTokenUseCase(iOrderRepository);
    }

    @Provides
    @Singleton
    GetCategoriesWithProductsUseCase provideGetCategoriesWithProductsUseCase(final IOrderRepository iOrderRepository) {
        return new GetCategoriesWithProductsUseCase(iOrderRepository);
    }

    @Provides
    @Singleton
    GetEstablishmentFromQRCodeUseCase provideGetEstablishmentFromQRCodeUseCase(final IOrderRepository iOrderRepository) {
        return new GetEstablishmentFromQRCodeUseCase(iOrderRepository);
    }

    @Provides
    @Singleton
    GetOrderHistoryForUserUseCase provideGetOrderHistoryForUserUseCase(final IOrderRepository iOrderRepository) {
        return new GetOrderHistoryForUserUseCase(iOrderRepository);
    }

    @Provides
    @Singleton
    ProcessOrderUseCase provideProcessOrderUseCase(final IOrderRepository iOrderRepository) {
        return new ProcessOrderUseCase(iOrderRepository);
    }

    @Provides
    @Singleton
    SignUpRequestUseCase provideSignUpRequestUseCase(final IOrderRepository iOrderRepository) {
        return new SignUpRequestUseCase(iOrderRepository);
    }

    public interface Exposes {

        GetLoginTokenUseCase getLoginTokenUseCase();

        GetCategoriesWithProductsUseCase getCategoriesWithProductsUseCase();

        GetEstablishmentFromQRCodeUseCase getEstablishmentFromQRCodeUseCase();

        GetOrderHistoryForUserUseCase getOrderHistoryForUserUseCase();

        ProcessOrderUseCase processOrderUseCase();

        SignUpRequestUseCase signUpRequestUseCase();
    }
}
