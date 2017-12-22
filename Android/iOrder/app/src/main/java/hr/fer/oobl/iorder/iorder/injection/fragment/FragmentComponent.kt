package hr.fer.oobl.iorder.iorder.injection.fragment

import dagger.Component
import hr.fer.oobl.iorder.iorder.injection.activity.ActivityComponent
import hr.fer.oobl.iorder.iorder.injection.fragment.modules.FragmentModule
import hr.fer.oobl.iorder.iorder.injection.fragment.modules.FragmentPresenterModule

@FragmentScope
@Component(dependencies = arrayOf(ActivityComponent::class), modules = arrayOf(FragmentModule::class, FragmentPresenterModule::class))
interface FragmentComponent : FragmentComponentInjects, FragmentComponentExposes {

    object Initializer {

        fun init(fragment: DaggerFragment, activityComponent: ActivityComponent): FragmentComponent {
            return DaggerFragmentComponent.builder()
                    .activityComponent(activityComponent)
                    .fragmentModule(FragmentModule(fragment))
                    .fragmentPresenterModule(FragmentPresenterModule(fragment))
                    .build()
        }
    }
}