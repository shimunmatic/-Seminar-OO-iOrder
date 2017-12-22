package hr.fer.oobl.iorder.iorder.injection.application.modules

import javax.inject.Named
import javax.inject.Singleton

import dagger.Module
import dagger.Provides
import rx.Scheduler
import rx.android.schedulers.AndroidSchedulers
import rx.schedulers.Schedulers

@Module
class ThreadingModule {

    @Provides
    @Singleton
    @Named(ThreadingModule.MAIN_SCHEDULER)
    fun provideMainScheduler(): Scheduler {
        return AndroidSchedulers.mainThread()
    }

    @Provides
    @Singleton
    @Named(ThreadingModule.BACKGROUND_SCHEDULER)
    fun provideBackgroundScheduler(): Scheduler {
        return Schedulers.io()
    }

    interface Exposes {

        @Named(ThreadingModule.MAIN_SCHEDULER)
        fun mainScheduler(): Scheduler

        @Named(ThreadingModule.BACKGROUND_SCHEDULER)
        fun backgroundScheduler(): Scheduler
    }

    companion object {

        val MAIN_SCHEDULER = "main_scheduler"
        val BACKGROUND_SCHEDULER = "background_scheduler"
    }
}
