package hr.fer.oobl.iorder.iorder.injection.activity.modules

import android.app.Activity
import android.content.Context
import android.support.v4.app.FragmentManager
import android.view.LayoutInflater

import dagger.Module
import dagger.Provides
import hr.fer.oobl.iorder.iorder.injection.activity.ActivityScope
import hr.fer.oobl.iorder.iorder.injection.activity.DaggerActivity
import hr.fer.oobl.iorder.iorder.injection.activity.ForActivity
import hr.fer.oobl.iorder.iorder.ui.router.Router
import hr.fer.oobl.iorder.iorder.ui.router.RouterImpl

@Module
class ActivityModule(private val daggerActivity: DaggerActivity) {

    @Provides
    @ActivityScope
    @ForActivity
    internal fun provideActivityContext(): Context {
        return daggerActivity
    }

    @Provides
    @ActivityScope
    internal fun provideActivity(): Activity {
        return daggerActivity
    }

    @Provides
    @ActivityScope
    internal fun provideFragmentManager(): FragmentManager {
        return daggerActivity.supportFragmentManager
    }

    @Provides
    @ActivityScope
    internal fun provideRouter(fragmentManager: FragmentManager): Router {
        return RouterImpl(daggerActivity, fragmentManager)
    }

    @Provides
    @ActivityScope
    internal fun provideLayoutInflater(@ForActivity context: Context): LayoutInflater {
        return LayoutInflater.from(context)
    }

    interface Exposes {

        fun activity(): Activity

        @ForActivity
        fun context(): Context

        fun fragmentManager(): FragmentManager

        fun router(): Router

        fun layoutInflater(): LayoutInflater
    }
}
