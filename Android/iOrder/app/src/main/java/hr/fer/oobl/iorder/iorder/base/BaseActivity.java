package hr.fer.oobl.iorder.iorder.base;

import hr.fer.oobl.iorder.iorder.injection.activity.DaggerActivity;

public abstract class BaseActivity extends DaggerActivity implements BaseView {

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
