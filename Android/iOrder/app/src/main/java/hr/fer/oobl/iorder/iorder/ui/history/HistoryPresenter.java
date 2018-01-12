package hr.fer.oobl.iorder.iorder.ui.history;

import java.util.Collections;
import java.util.List;

import hr.fer.oobl.iorder.domain.model.Order;
import hr.fer.oobl.iorder.iorder.base.BasePresenter;

public final class HistoryPresenter extends BasePresenter<HistoryContract.View> implements HistoryContract.Presenter {

    private List<Order> orderHistory = Collections.emptyList();

    public HistoryPresenter(final HistoryContract.View view) {
        super(view);
    }

    @Override
    public List<Order> getHistory() {
        return orderHistory;
    }
}
