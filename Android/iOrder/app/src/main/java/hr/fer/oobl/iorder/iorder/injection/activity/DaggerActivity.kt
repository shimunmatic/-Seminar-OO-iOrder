package hr.fer.oobl.iorder.iorder.injection.activity

import android.os.Bundle
import android.support.v7.app.AppCompatActivity

import hr.fer.oobl.iorder.iorder.application.IOrderApplication
import hr.fer.oobl.iorder.iorder.injection.ComponentFactory
import hr.fer.oobl.iorder.iorder.injection.application.ApplicationComponent

abstract class DaggerActivity : AppCompatActivity() {

    private var activityComponent: ActivityComponent? = null

    private val applicationComponent: ApplicationComponent?
        get() = (application as IOrderApplication).getApplicationComponent()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        inject(getActivityComponent())
    }

    fun getActivityComponent(): ActivityComponent {
        if (activityComponent == null) {
            activityComponent = ComponentFactory.createActivityComponent(this, applicationComponent)
        }

        return activityComponent
    }

    protected abstract fun inject(activityComponent: ActivityComponent)
}
