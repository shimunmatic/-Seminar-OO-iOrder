package hr.fer.oobl.iorder.iorder.base;

import android.support.annotation.Nullable;

import java.lang.ref.WeakReference;

import javax.inject.Inject;
import javax.inject.Named;

import hr.fer.oobl.iorder.iorder.injection.application.modules.ThreadingModule;
import rx.Scheduler;
import rx.Subscription;
import rx.functions.Action1;
import rx.subscriptions.CompositeSubscription;

public abstract class BasePresenter<View extends BaseView> implements ScopedPresenter {

    @Inject
    @Named(ThreadingModule.MAIN_SCHEDULER)
    protected Scheduler mainThreadScheduler;

    @Inject
    @Named(ThreadingModule.BACKGROUND_SCHEDULER)
    protected Scheduler backgroundScheduler;

    private final WeakReference<View> viewReference;
    private final CompositeSubscription subscriptions = new CompositeSubscription();

    public BasePresenter(final View view) {
        this.viewReference = new WeakReference<>(view);
    }

    @Nullable
    protected View getNullableView() {
        return viewReference.get();
    }

    protected void addSubscription(final Subscription subscription) {
        subscriptions.add(subscription);
    }

    @Override
    public void deactivate() {
        subscriptions.clear();
    }

    @Override
    public void stop() {
        subscriptions.clear();
    }

    @Override
    public void activate() {
    }

    protected void doIfViewNotNull(final Action1<View> whenViewNotNull) {
        final View view = getNullableView();
        if (view != null) {
            whenViewNotNull.call(view);
        }
    }
}
