package hr.fer.oobl.iorder.iorder.injection;

import hr.fer.oobl.iorder.iorder.base.IOrderApplication;
import hr.fer.oobl.iorder.iorder.injection.activity.ActivityComponent;
import hr.fer.oobl.iorder.iorder.injection.activity.DaggerActivity;
import hr.fer.oobl.iorder.iorder.injection.application.ApplicationComponent;
import hr.fer.oobl.iorder.iorder.injection.fragment.DaggerFragment;
import hr.fer.oobl.iorder.iorder.injection.fragment.FragmentComponent;

public final class ComponentFactory {

    private ComponentFactory() {
    }

    public static ApplicationComponent createApplicationComponent(final IOrderApplication iOrderApplication) {
        return ApplicationComponent.Initializer.init(iOrderApplication);
    }

    public static ActivityComponent createActivityComponent(final DaggerActivity daggerActivity, final ApplicationComponent applicationComponent) {
        return ActivityComponent.Initializer.init(daggerActivity, applicationComponent);
    }

    public static FragmentComponent createFragmentComponent(final DaggerFragment daggerFragment, final ActivityComponent activityComponent) {
        return FragmentComponent.Initializer.init(daggerFragment, activityComponent);
    }
}
