package hr.fer.oobl.iorder.iorder.injection.application.modules

import android.content.Context

import javax.inject.Singleton

import dagger.Module
import dagger.Provides
import hr.fer.oobl.iorder.iorder.application.IOrderApplication
import hr.fer.oobl.iorder.iorder.injection.application.ForApplication

@Module
class ApplicationModule(private val iOrderApplication: IOrderApplication) {

    @Provides
    @Singleton
    internal fun provideMkApostoliApplication(): IOrderApplication {
        return iOrderApplication
    }

    @Provides
    @Singleton
    @ForApplication
    internal fun provideContext(): Context {
        return iOrderApplication
    }

    interface Exposes {

        fun iOrderApplication(): IOrderApplication

        @ForApplication
        fun context(): Context
    }
}
