package hr.fer.oobl.iorder.iorder.injection.activity

import dagger.Component
import hr.fer.oobl.iorder.iorder.injection.activity.modules.ActivityModule
import hr.fer.oobl.iorder.iorder.injection.activity.modules.ActivityPresenterModule
import hr.fer.oobl.iorder.iorder.injection.application.ApplicationComponent

@ActivityScope
@Component(dependencies = arrayOf(ApplicationComponent::class), modules = arrayOf(ActivityModule::class, ActivityPresenterModule::class))
interface ActivityComponent : ActivityComponentInjects, ActivityComponentExposes {

    object Initializer {

        fun init(daggerActivity: DaggerActivity, applicationComponent: ApplicationComponent): ActivityComponent {
            return DaggerActivityComponent.builder()
                    .applicationComponent(applicationComponent)
                    .activityModule(ActivityModule(daggerActivity))
                    .activityPresenterModule(ActivityPresenterModule(daggerActivity))
                    .build()
        }
    }
}