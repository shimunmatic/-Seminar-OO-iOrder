package hr.fer.oobl.iorder.iorder.injection


import hr.fer.oobl.iorder.iorder.application.IOrderApplication
import hr.fer.oobl.iorder.iorder.injection.activity.ActivityComponent
import hr.fer.oobl.iorder.iorder.injection.activity.DaggerActivity
import hr.fer.oobl.iorder.iorder.injection.application.ApplicationComponent
import hr.fer.oobl.iorder.iorder.injection.fragment.DaggerFragment
import hr.fer.oobl.iorder.iorder.injection.fragment.FragmentComponent

object ComponentFactory {

    fun createApplicationComponent(iOrderApplication: IOrderApplication): ApplicationComponent {
        return ApplicationComponent.Initializer.init(iOrderApplication)
    }

    fun createActivityComponent(daggerActivity: DaggerActivity, applicationComponent: ApplicationComponent): ActivityComponent {
        return ActivityComponent.Initializer.init(daggerActivity, applicationComponent)
    }

    fun createFragmentComponent(daggerFragment: DaggerFragment, activityComponent: ActivityComponent): FragmentComponent {
        return FragmentComponent.Initializer.init(daggerFragment, activityComponent)
    }
}
