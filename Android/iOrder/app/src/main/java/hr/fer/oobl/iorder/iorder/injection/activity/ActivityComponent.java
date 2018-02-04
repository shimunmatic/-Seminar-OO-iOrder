package hr.fer.oobl.iorder.iorder.injection.activity;

import dagger.Component;
import hr.fer.oobl.iorder.iorder.injection.activity.modules.ActivityModule;
import hr.fer.oobl.iorder.iorder.injection.activity.modules.ActivityPresenterModule;
import hr.fer.oobl.iorder.iorder.injection.application.ApplicationComponent;

@ActivityScope
@Component(
        dependencies = {
                ApplicationComponent.class
        },
        modules = {
                ActivityModule.class,
                ActivityPresenterModule.class
        }
)
public interface ActivityComponent extends ActivityComponentInjects, ActivityComponentExposes {

    final class Initializer {

        static public ActivityComponent init(final DaggerActivity daggerActivity, final ApplicationComponent applicationComponent) {
            return DaggerActivityComponent.builder()
                                          .applicationComponent(applicationComponent)
                                          .activityModule(new ActivityModule(daggerActivity))
                                          .activityPresenterModule(new ActivityPresenterModule(daggerActivity))
                                          .build();
        }

        private Initializer() {

        }
    }
}