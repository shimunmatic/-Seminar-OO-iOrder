package hr.fer.oobl.iorder.iorder.ui.history;

import android.os.Bundle;

import hr.fer.oobl.iorder.iorder.base.BaseFragment;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;
import hr.fer.oobl.iorder.iorder.injection.fragment.FragmentComponent;

public final class HistoryFragment extends BaseFragment implements HistoryContract.View {

    @Override
    public ScopedPresenter getPresenter() {
        return null;
    }

    public static HistoryFragment newInstance() {
        final HistoryFragment fragment = new HistoryFragment();
        final Bundle args = new Bundle();
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    protected void inject(final FragmentComponent fragmentComponent) {
        fragmentComponent.inject(this);
    }
}
