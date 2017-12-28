package hr.fer.oobl.iorder.iorder.base;

import hr.fer.oobl.iorder.iorder.injection.fragment.DaggerFragment;

public abstract class BaseFragment extends DaggerFragment implements BaseView {

    @Override
    public void onStop() {
        getPresenter().stop();
        super.onStop();
    }

    @Override
    public void onPause() {
        getPresenter().deactivate();
        super.onPause();
    }

    public abstract ScopedPresenter getPresenter();
}
