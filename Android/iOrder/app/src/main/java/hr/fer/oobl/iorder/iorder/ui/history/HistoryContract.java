package hr.fer.oobl.iorder.iorder.ui.history;

import java.util.List;

import hr.fer.oobl.iorder.domain.model.Order;
import hr.fer.oobl.iorder.iorder.base.BaseView;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;

public interface HistoryContract {

    interface View extends BaseView {

        void initializeRecyclerView(List<Order> orderHistroy);

        void showError(String message);
    }

    interface Presenter extends ScopedPresenter {

        List<Order> getHistory();

        void fetchHistory(long establishmentId);
    }
}
