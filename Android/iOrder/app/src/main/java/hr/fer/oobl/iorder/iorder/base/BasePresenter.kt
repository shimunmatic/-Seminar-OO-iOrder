package hr.fer.oobl.iorder.iorder.base

import java.lang.ref.WeakReference

import javax.inject.Inject
import javax.inject.Named

import hr.fer.oobl.iorder.iorder.injection.application.modules.ThreadingModule
import rx.Scheduler
import rx.Subscription
import rx.subscriptions.CompositeSubscription

abstract class BasePresenter(view: BaseView) : ScopedPresenter {

    @Inject
    @Named(ThreadingModule.MAIN_SCHEDULER)
    protected var mainThreadScheduler: Scheduler? = null

    @Inject
    @Named(ThreadingModule.BACKGROUND_SCHEDULER)
    protected var backgroundScheduler: Scheduler? = null

    private val viewReference: WeakReference<BaseView>
    private val subscriptions = CompositeSubscription()

    protected val nullableView: BaseView?
        get() = viewReference.get()

    init {
        this.viewReference = WeakReference(view)
    }

    protected fun addSubscription(subscription: Subscription) {
        subscriptions.add(subscription)
    }

    override fun deactivate() {
        subscriptions.clear()
    }

    override fun stop() {
        subscriptions.clear()
    }

    override fun activate() {}
}
