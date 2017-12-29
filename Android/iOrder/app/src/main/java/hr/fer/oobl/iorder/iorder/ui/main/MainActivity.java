package hr.fer.oobl.iorder.iorder.ui.main;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.BottomNavigationView;
import android.support.v4.view.ViewPager;
import android.view.MenuItem;

import javax.inject.Inject;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnClick;
import hr.fer.oobl.iorder.iorder.R;
import hr.fer.oobl.iorder.iorder.base.BaseActivity;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;
import hr.fer.oobl.iorder.iorder.injection.activity.ActivityComponent;
import hr.fer.oobl.iorder.iorder.ui.dashboard.DashboardFragment;
import hr.fer.oobl.iorder.iorder.ui.history.HistoryFragment;
import hr.fer.oobl.iorder.iorder.ui.location.LocationFragment;
import hr.fer.oobl.iorder.iorder.ui.main.model.ViewPageAdapter;

public class MainActivity extends BaseActivity implements MainContract.View {

    @BindView(R.id.navigation)
    BottomNavigationView bottomNavigationView;

    @BindView(R.id.container)
    ViewPager viewPager;

    @Inject
    MainContract.Presenter presenter;

    private MenuItem prevMenuItem;

    @Override
    protected void onCreate(@Nullable final Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main_layout);
        ButterKnife.bind(this);

        setNavigation();
        setupViewPager();
    }

    private void setupViewPager() {
        ViewPageAdapter adapter = new ViewPageAdapter(getSupportFragmentManager());
        adapter.addFragment(DashboardFragment.newInstance());
        adapter.addFragment(HistoryFragment.newInstance());
        adapter.addFragment(LocationFragment.newInstance());
        viewPager.setAdapter(adapter);
    }

    private void setNavigation() {
        bottomNavigationView.setOnNavigationItemSelectedListener(
                item -> {
                    switch (item.getItemId()) {
                        case R.id.navigation_dashboard:
                            viewPager.setCurrentItem(0);
                            break;

                        case R.id.navigation_history:
                            viewPager.setCurrentItem(1);
                            break;

                        case R.id.navigation_location:
                            viewPager.setCurrentItem(2);
                            break;
                    }
                    return false;
                });

        viewPager.addOnPageChangeListener(new ViewPager.OnPageChangeListener() {

            @Override
            public void onPageScrolled(int position, float positionOffset, int positionOffsetPixels) {

            }

            @Override
            public void onPageSelected(int position) {
                if (prevMenuItem != null) {
                    prevMenuItem.setChecked(false);
                } else {
                    bottomNavigationView.getMenu().getItem(0).setChecked(false);
                }
                bottomNavigationView.getMenu().getItem(position).setChecked(true);
                prevMenuItem = bottomNavigationView.getMenu().getItem(position);
            }

            @Override
            public void onPageScrollStateChanged(int state) {

            }
        });
    }

    @OnClick(R.id.scanner)
    public void scannerPressed() {
        presenter.startScanner();
    }

    @OnClick(R.id.cart)
    public void cartPressed() {
        presenter.showCart();
    }

    @OnClick(R.id.blackboard)
    public void blackboardPressed() {
        presenter.showBlackBoard();
    }

    @Override
    public ScopedPresenter getPresenter() {
        return presenter;
    }

    @Override
    protected void inject(final ActivityComponent activityComponent) {
        activityComponent.inject(this);
    }
}
