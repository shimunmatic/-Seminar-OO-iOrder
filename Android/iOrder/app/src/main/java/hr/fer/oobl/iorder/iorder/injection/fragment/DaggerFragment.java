package hr.fer.oobl.iorder.iorder.injection.fragment;

import android.os.Bundle;
import android.support.v4.app.Fragment;

import hr.fer.oobl.iorder.iorder.injection.ComponentFactory;
import hr.fer.oobl.iorder.iorder.injection.activity.DaggerActivity;

public abstract class DaggerFragment extends Fragment {

    private FragmentComponent fragmentComponent;

    @Override
    public void onCreate(final Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        inject(getFragmentComponent());
    }

    protected abstract void inject(FragmentComponent fragmentComponent);

    public FragmentComponent getFragmentComponent() {
        if (fragmentComponent == null) {
            fragmentComponent = ComponentFactory.createFragmentComponent(this, getDaggerActivity().getActivityComponent());
        }

        return fragmentComponent;
    }

    public DaggerActivity getDaggerActivity() {
        return ((DaggerActivity) getActivity());
    }
}
