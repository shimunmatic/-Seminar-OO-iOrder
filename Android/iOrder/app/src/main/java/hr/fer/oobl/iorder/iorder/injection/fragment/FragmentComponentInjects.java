package hr.fer.oobl.iorder.iorder.injection.fragment;

import hr.fer.oobl.iorder.iorder.ui.dashboard.DashboardFragment;
import hr.fer.oobl.iorder.iorder.ui.dashboard.DashboardPresenter;
import hr.fer.oobl.iorder.iorder.ui.history.HistoryFragment;
import hr.fer.oobl.iorder.iorder.ui.history.HistoryPresenter;
import hr.fer.oobl.iorder.iorder.ui.location.LocationFragment;
import hr.fer.oobl.iorder.iorder.ui.location.LocationPresenter;

public interface FragmentComponentInjects {
    
    void inject(DashboardFragment dashboardFragment);

    void inject(HistoryFragment historyFragment);

    void inject(LocationFragment locationFragment);

    void inject(DashboardPresenter presenter);

    void inject(HistoryPresenter presenter);

    void inject(LocationPresenter presenter);
}
