package hr.fer.oobl.iorder.iorder.injection.fragment.modules;

import dagger.Module;
import dagger.Provides;
import hr.fer.oobl.iorder.iorder.injection.fragment.DaggerFragment;
import hr.fer.oobl.iorder.iorder.injection.fragment.FragmentScope;
import hr.fer.oobl.iorder.iorder.ui.dashboard.DashboardContract;
import hr.fer.oobl.iorder.iorder.ui.dashboard.DashboardPresenter;
import hr.fer.oobl.iorder.iorder.ui.history.HistoryContract;
import hr.fer.oobl.iorder.iorder.ui.history.HistoryPresenter;
import hr.fer.oobl.iorder.iorder.ui.location.LocationContract;
import hr.fer.oobl.iorder.iorder.ui.location.LocationPresenter;

@Module
public final class FragmentPresenterModule {

    private final DaggerFragment daggerFragment;

    public FragmentPresenterModule(final DaggerFragment daggerFragment) {this.daggerFragment = daggerFragment;}

    @Provides
    @FragmentScope
    DashboardContract.Presenter provideDashboardPresenter() {
        final DashboardPresenter presenter = new DashboardPresenter((DashboardContract.View) daggerFragment);
        daggerFragment.getFragmentComponent().inject(presenter);
        return presenter;
    }

    @Provides
    @FragmentScope
    HistoryContract.Presenter provideHistoryPresenter() {
        final HistoryPresenter presenter = new HistoryPresenter((HistoryContract.View) daggerFragment);
        daggerFragment.getFragmentComponent().inject(presenter);
        return presenter;
    }

    @Provides
    @FragmentScope
    LocationContract.Presenter provideLocationPresenter() {
        final LocationPresenter presenter = new LocationPresenter((LocationContract.View) daggerFragment);
        daggerFragment.getFragmentComponent().inject(presenter);
        return presenter;
    }
}
