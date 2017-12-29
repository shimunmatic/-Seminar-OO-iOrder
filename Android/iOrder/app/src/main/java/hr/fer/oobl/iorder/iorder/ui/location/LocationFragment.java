package hr.fer.oobl.iorder.iorder.ui.location;

import android.os.Bundle;

import hr.fer.oobl.iorder.iorder.base.BaseFragment;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;
import hr.fer.oobl.iorder.iorder.injection.fragment.FragmentComponent;

public final class LocationFragment extends BaseFragment implements LocationContract.View {

    public static LocationFragment newInstance() {
        final LocationFragment fragment = new LocationFragment();
        final Bundle args = new Bundle();
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public ScopedPresenter getPresenter() {
        return null;
    }

    @Override
    protected void inject(final FragmentComponent fragmentComponent) {
        fragmentComponent.inject(this);
    }
}
