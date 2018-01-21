package hr.fer.oobl.iorder.iorder.injection.application.modules;

import javax.inject.Singleton;

import dagger.Module;
import dagger.Provides;
import hr.fer.oobl.iorder.data.network.client.IOrderClient;
import hr.fer.oobl.iorder.data.network.mapper.ApiIOrderToDomainMapper;
import hr.fer.oobl.iorder.data.repository.IOrderRepositoryImpl;
import hr.fer.oobl.iorder.data.util.AccessTokenStorage;
import hr.fer.oobl.iorder.domain.repository.IOrderRepository;

@Module
public final class DomainModule {

    @Provides
    @Singleton
    IOrderRepository provideIOrderRepository(final IOrderClient iOrderClient,
                                             final ApiIOrderToDomainMapper apiMapper,
                                             final AccessTokenStorage accessTokenStorage) {
        return new IOrderRepositoryImpl(iOrderClient, apiMapper, accessTokenStorage);
    }

    public interface Exposes {

        IOrderRepository iOrderRepository();
    }
}
