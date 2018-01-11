package hr.fer.oobl.iorder.iorder.ui.history;

import java.util.ArrayList;
import java.util.List;

import hr.fer.oobl.iorder.data.model.Product;
import hr.fer.oobl.iorder.data.network.model.ApiEstablishment;
import hr.fer.oobl.iorder.data.network.model.ApiLocation;
import hr.fer.oobl.iorder.data.network.model.ApiOrderHistory;
import hr.fer.oobl.iorder.data.network.model.ApiUser;
import hr.fer.oobl.iorder.iorder.base.BasePresenter;
import hr.fer.oobl.iorder.iorder.ui.main.model.ExpandableListDataPump;
import hr.fer.oobl.iorder.iorder.utils.DateFormatter;

public final class HistoryPresenter extends BasePresenter<HistoryContract.View> implements HistoryContract.Presenter {

    private List<ApiOrderHistory> orderHistory = new ArrayList<>();

    public HistoryPresenter(final HistoryContract.View view) {
        super(view);
        List<Product> products = ExpandableListDataPump.getData().get("Warm drink");

        double price = 0;

        for (final Product product : products) {
            price += Integer.parseInt(product.getQuantity()) * Double.parseDouble(product.getFormattedPrice());
        }
        DateFormatter dateFormatter = new DateFormatter();
        orderHistory.add(new ApiOrderHistory(products, String.valueOf(price), dateFormatter.getCurrentDate(), new ApiUser(), new ApiEstablishment(0, "Jet-Set"), new ApiLocation()));
        orderHistory.add(new ApiOrderHistory(products, String.valueOf(price), dateFormatter.getCurrentDate(), new ApiUser(), new ApiEstablishment(0, "Peppermint"), new ApiLocation()));
        orderHistory.add(new ApiOrderHistory(products, String.valueOf(price), dateFormatter.getCurrentDate(), new ApiUser(), new ApiEstablishment(0, "Xanadu"), new ApiLocation()));
    }

    @Override
    public List<ApiOrderHistory> getHistory() {
        return orderHistory;
    }
}
