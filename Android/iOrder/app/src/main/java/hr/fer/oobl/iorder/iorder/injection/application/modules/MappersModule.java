package hr.fer.oobl.iorder.iorder.injection.application.modules;

import javax.inject.Singleton;

import dagger.Module;
import dagger.Provides;
import hr.fer.oobl.iorder.data.network.mapper.ApiIOrderToDomainMapper;
import hr.fer.oobl.iorder.data.network.mapper.ApiIOrderToDomainMapperImpl;

@Module
public final class MappersModule {

    @Provides
    @Singleton
    ApiIOrderToDomainMapper provideApiIOrderToDomainMapper() {
        return new ApiIOrderToDomainMapperImpl();
    }

    public interface Exposes {

        ApiIOrderToDomainMapper apiIOrderToDomainMapper();
    }
}
