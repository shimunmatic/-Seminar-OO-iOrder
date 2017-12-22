package hr.fer.oobl.iorder.iorder.injection.application

import javax.inject.Singleton

import dagger.Component
import hr.fer.oobl.iorder.iorder.application.IOrderApplication
import hr.fer.oobl.iorder.iorder.injection.application.modules.ApplicationModule
import hr.fer.oobl.iorder.iorder.injection.application.modules.DataModule
import hr.fer.oobl.iorder.iorder.injection.application.modules.DomainModule
import hr.fer.oobl.iorder.iorder.injection.application.modules.MappersModule
import hr.fer.oobl.iorder.iorder.injection.application.modules.ThreadingModule
import hr.fer.oobl.iorder.iorder.injection.application.modules.UseCaseModule

@Singleton
@Component(modules = arrayOf(ApplicationModule::class, DataModule::class, DomainModule::class, MappersModule::class, ThreadingModule::class, UseCaseModule::class))
interface ApplicationComponent : ApplicationComponentInjects, ApplicationComponentExposes {

    object Initializer {

        fun init(iOrderApplication: IOrderApplication): ApplicationComponent {
            return DaggerApplicationComponent.builder()
                    .applicationModule(ApplicationModule(iOrderApplication))
                    .dataModule(DataModule(iOrderApplication))
                    .mappersModule(MappersModule())
                    .domainModule(DomainModule())
                    .threadingModule(ThreadingModule())
                    .useCaseModule(UseCaseModule())
                    .build()
        }
    }
}
