package hr.fer.oobl.iorder.iorder.application

import android.app.Application
import com.facebook.stetho.Stetho
import hr.fer.oobl.iorder.iorder.injection.ComponentFactory
import hr.fer.oobl.iorder.iorder.injection.application.ApplicationComponent

/**
 * Created by mmihalic on 19.12.2017..
 */
class IOrderApplication : Application() {

    private var applicationComponent: ApplicationComponent? = null

    override fun onCreate() {
        super.onCreate()
        Stetho.initializeWithDefaults(applicationContext)
        initApplicationComponent()
        injectMe()
    }

    fun getApplicationComponent(): ApplicationComponent? {
        return applicationComponent
    }

    private fun injectMe() {
        applicationComponent!!.inject(this)
    }

    private fun initApplicationComponent() {
        applicationComponent = ComponentFactory.createApplicationComponent(this)
    }

}