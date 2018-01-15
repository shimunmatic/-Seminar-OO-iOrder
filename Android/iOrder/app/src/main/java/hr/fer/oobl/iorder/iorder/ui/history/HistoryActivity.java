package hr.fer.oobl.iorder.iorder.ui.history;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.ProgressBar;
import android.widget.Toast;

import java.util.Collections;
import java.util.List;

import javax.inject.Inject;

import butterknife.BindView;
import butterknife.ButterKnife;
import hr.fer.oobl.iorder.domain.model.Order;
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

    @BindView(R.id.progress_history)
    ProgressBar progressHistory;

    @Inject
    HistoryContract.Presenter presenter;

    private HistoryAdapter historyAdapter;
    private long establishmentId;
    private String establishmentName;

    @Override
    public ScopedPresenter getPresenter() {
        return presenter;
    }

    @Override
    public void onCreate(@Nullable final Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.history_layout);
        ButterKnife.bind(this);

        final Bundle bundle = getIntent().getExtras();
        if (bundle != null) {
            establishmentId = bundle.getLong("establishmentId");
            establishmentName = bundle.getString("name");

            setupToolbar(establishmentName);
            if (establishmentId != 0L) {
                presenter.fetchHistory(establishmentId);
            }
        }
    }

    @Override
    protected void inject(final ActivityComponent activityComponent) {
        activityComponent.inject(this);
    }

    @Override
    public void initializeRecyclerView(final List<Order> orderHistory) {
        changeVisibility();
        historyAdapter = new HistoryAdapter(orderHistory, this, establishmentName);
        recyclerView.setAdapter(historyAdapter);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
    }

    @Override
    public void showError(final String message) {
        changeVisibility();
        initializeRecyclerView(Collections.emptyList());
        Toast.makeText(this, message, Toast.LENGTH_SHORT).show();

    }

    private void changeVisibility() {
        progressHistory.setVisibility(View.GONE);
        recyclerView.setVisibility(View.VISIBLE);
    }

    private void setupToolbar(final String establishmentName) {
        toolbar.setNavigationIcon(R.drawable.ic_back);
        toolbar.setNavigationOnClickListener(view1 -> onBackPressed());
        if (establishmentName != null && !establishmentName.isEmpty()) {
            final String title = "History for " + establishmentName;
            toolbar.setTitle(title);
        }
    }
}
