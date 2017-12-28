package hr.fer.oobl.iorder.iorder.injection.fragment;

import dagger.Component;
import hr.fer.oobl.iorder.iorder.injection.activity.ActivityComponent;
import hr.fer.oobl.iorder.iorder.injection.fragment.modules.FragmentModule;
import hr.fer.oobl.iorder.iorder.injection.fragment.modules.FragmentPresenterModule;

@FragmentScope
@Component(
        dependencies = {
                ActivityComponent.class
        },
        modules = {
                FragmentModule.class,
                FragmentPresenterModule.class
        }
)
public interface FragmentComponent extends FragmentComponentInjects, FragmentComponentExposes {

    final class Initializer {

        static public FragmentComponent init(final DaggerFragment fragment, final ActivityComponent activityComponent) {
            return DaggerFragmentComponent.builder()
                                          .activityComponent(activityComponent)
                                          .fragmentModule(new FragmentModule(fragment))
                                          .fragmentPresenterModule(new FragmentPresenterModule(fragment))
                                          .build();
        }

        private Initializer() {
        }
    }
}