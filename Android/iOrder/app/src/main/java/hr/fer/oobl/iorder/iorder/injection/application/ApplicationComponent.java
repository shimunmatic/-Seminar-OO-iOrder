package hr.fer.oobl.iorder.iorder.injection.application;

import javax.inject.Singleton;

import dagger.Component;
import hr.fer.oobl.iorder.iorder.base.IOrderApplication;
import hr.fer.oobl.iorder.iorder.injection.application.modules.ApplicationModule;
import hr.fer.oobl.iorder.iorder.injection.application.modules.DataModule;
import hr.fer.oobl.iorder.iorder.injection.application.modules.DomainModule;
import hr.fer.oobl.iorder.iorder.injection.application.modules.MappersModule;
import hr.fer.oobl.iorder.iorder.injection.application.modules.ThreadingModule;
import hr.fer.oobl.iorder.iorder.injection.application.modules.UseCaseModule;

@Singleton
@Component(
        modules = {
                ApplicationModule.class,
                DataModule.class,
                DomainModule.class,
                MappersModule.class,
                ThreadingModule.class,
                UseCaseModule.class,
        }
)
public interface ApplicationComponent extends ApplicationComponentInjects, ApplicationComponentExposes {

    final class Initializer {

        static public ApplicationComponent init(final IOrderApplication iOrderApplication) {
            return DaggerApplicationComponent.builder()
                                             .applicationModule(new ApplicationModule(iOrderApplication))
                                             .dataModule(new DataModule(iOrderApplication))
                                             .mappersModule(new MappersModule())
                                             .domainModule(new DomainModule())
                                             .threadingModule(new ThreadingModule())
                                             .useCaseModule(new UseCaseModule())
                                             .build();
        }

        private Initializer() {
        }
    }
}
