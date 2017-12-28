package hr.fer.oobl.iorder.iorder.ui.main;

import android.os.Bundle;
import android.support.annotation.Nullable;

import butterknife.ButterKnife;
import hr.fer.oobl.iorder.iorder.R;
import hr.fer.oobl.iorder.iorder.base.BaseActivity;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;
import hr.fer.oobl.iorder.iorder.injection.activity.ActivityComponent;

public class MainActivity extends BaseActivity {

    @Override
    protected void onCreate(@Nullable final Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main_layout);
        ButterKnife.bind(this);
    }

    @Override
    public ScopedPresenter getPresenter() {
        return null;
    }

    @Override
    protected void inject(final ActivityComponent activityComponent) {
        activityComponent.inject(this);
    }
}
