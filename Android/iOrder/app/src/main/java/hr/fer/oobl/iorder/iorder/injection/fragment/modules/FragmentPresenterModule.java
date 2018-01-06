package hr.fer.oobl.iorder.iorder.injection.fragment.modules;

import dagger.Module;
import dagger.Provides;
import hr.fer.oobl.iorder.iorder.injection.fragment.DaggerFragment;
import hr.fer.oobl.iorder.iorder.injection.fragment.FragmentScope;
import hr.fer.oobl.iorder.iorder.ui.history.HistoryContract;
import hr.fer.oobl.iorder.iorder.ui.history.HistoryPresenter;

@Module
public final class FragmentPresenterModule {

    private final DaggerFragment daggerFragment;

    public FragmentPresenterModule(final DaggerFragment daggerFragment) {this.daggerFragment = daggerFragment;}
}
