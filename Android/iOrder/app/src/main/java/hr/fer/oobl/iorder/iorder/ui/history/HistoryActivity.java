package hr.fer.oobl.iorder.iorder.ui.history;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;

import javax.inject.Inject;

import butterknife.BindView;
import butterknife.ButterKnife;
import hr.fer.oobl.iorder.iorder.R;
import hr.fer.oobl.iorder.iorder.base.BaseActivity;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;
import hr.fer.oobl.iorder.iorder.injection.activity.ActivityComponent;
import hr.fer.oobl.iorder.iorder.ui.history.model.HistoryAdapter;

public final class HistoryActivity extends BaseActivity implements HistoryContract.View {

    @BindView(R.id.historyToolbar)
    Toolbar toolbar;

    @BindView(R.id.history_recycler)
    RecyclerView recyclerView;

    @Inject
    HistoryContract.Presenter presenter;

    private HistoryAdapter historyAdapter;

    @Override
    public ScopedPresenter getPresenter() {
        return presenter;
    }

    @Override
    public void onCreate(@Nullable final Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.history_layout);
        ButterKnife.bind(this);

        setupToolbar();
        initializeRecycler();
    }

    @Override
    protected void inject(final ActivityComponent activityComponent) {
        activityComponent.inject(this);
    }

    private void initializeRecycler() {
        historyAdapter = new HistoryAdapter(presenter.getHistory(), this);
        recyclerView.setAdapter(historyAdapter);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
    }

    private void setupToolbar() {
        toolbar.setNavigationIcon(R.drawable.ic_back);
        toolbar.setNavigationOnClickListener(view1 -> onBackPressed());
    }
}
