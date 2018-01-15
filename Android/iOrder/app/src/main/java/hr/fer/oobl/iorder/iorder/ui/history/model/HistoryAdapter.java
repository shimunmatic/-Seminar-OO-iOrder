package hr.fer.oobl.iorder.iorder.ui.history.model;

import android.app.AlertDialog;
import android.content.Context;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;

import java.util.List;

import javax.inject.Inject;

import hr.fer.oobl.iorder.domain.model.Order;
import hr.fer.oobl.iorder.domain.model.Product;
import hr.fer.oobl.iorder.iorder.R;
import hr.fer.oobl.iorder.iorder.ui.history.HistoryContract;
import hr.fer.oobl.iorder.iorder.ui.main.model.CartAdapter;

public class HistoryAdapter extends RecyclerView.Adapter<RecyclerView.ViewHolder> {

    @Inject
    HistoryContract.Presenter presenter;

    private static final int ITEMS = 1;
    private static final int EMPTY_STATE = 0;

    private List<Order> orderHistory;
    private Context context;
    private String establishmentName;

    public HistoryAdapter(final List<Order> orderHistory, final Context context, String establishmentName) {
        this.orderHistory = orderHistory;
        this.context = context;
        this.establishmentName = establishmentName;
    }

    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(final ViewGroup parent, final int viewType) {
        LayoutInflater inflater = LayoutInflater.from(context);
        RecyclerView.ViewHolder viewHolder = null;
        View view;

        switch (viewType) {
            case EMPTY_STATE:
                view = inflater.inflate(R.layout.history_empty_state, parent, false);
                viewHolder = new EmptyViewHolder(view);
                break;
            case ITEMS:
                view = inflater.inflate(R.layout.order_item, parent, false);
                viewHolder = new HistoryViewHolder(view);
                break;
            default:
                break;
        }

        return viewHolder;
    }

    @Override
    public void onBindViewHolder(final RecyclerView.ViewHolder holder, final int position) {
        if (getItemViewType(position) == ITEMS) {
            final Order order = orderHistory.get(position);
            final HistoryViewHolder historyViewHolder = (HistoryViewHolder) holder;
            historyViewHolder.setData(order);
        }
    }

    @Override
    public int getItemViewType(int position) {
        if (orderHistory == null || orderHistory.isEmpty()) {
            return EMPTY_STATE;
        } else {
            return ITEMS;
        }
    }

    @Override
    public int getItemCount() {
        return orderHistory.size();
    }

    public class HistoryViewHolder extends RecyclerView.ViewHolder {

        private TextView date;
        private TextView establishment;
        private TextView price;
        private LinearLayout item;

        public HistoryViewHolder(View itemView) {
            super(itemView);

            date = itemView.findViewById(R.id.order_time);
            establishment = itemView.findViewById(R.id.order_establishment);
            price = itemView.findViewById(R.id.order_bill);
            item = itemView.findViewById(R.id.order_item);
        }

        public void setData(final Order order) {
            date.setText(order.getDate());
            establishment.setText(establishmentName);

            String priceString = String.valueOf(order.getPrice()) + " HRK";
            price.setText(priceString);
            item.setOnClickListener(v -> {
                showDetails(order);
            });
        }
    }

    private void showDetails(final Order order) {
        AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(context, AlertDialog.THEME_HOLO_LIGHT);
        final List<Product> products = order.getProducts();

        for(final Product product : products) {
            Log.d("product " + product.getId(), product.toString());
        }
        View dialogView;

        if (products == null || products.isEmpty()) {
            dialogView = LayoutInflater.from(context).inflate(R.layout.cart_empty_state, null);
            final Button dismissButton = dialogView.findViewById(R.id.dismiss);
            dialogBuilder.setView(dialogView);

            AlertDialog alertDialog = dialogBuilder.create();
            dismissButton.setOnClickListener(v -> alertDialog.cancel());
            alertDialog.show();
        } else {
            dialogView = LayoutInflater.from(context).inflate(R.layout.alert_cart_layout, null);

            dialogBuilder.setView(dialogView);

            final RecyclerView recyclerView = dialogView.findViewById(R.id.recycler_products);
            final CartAdapter cartAdapter = new CartAdapter(products, context);
            recyclerView.setAdapter(cartAdapter);
            recyclerView.setLayoutManager(new LinearLayoutManager(context));

            final TextView bill = dialogView.findViewById(R.id.bill);
            String billText = "Price paid: " + order.getPrice();
            bill.setText(billText);

            final Button orderButton = dialogView.findViewById(R.id.order_button);
            orderButton.setText(R.string.order_again);
            final Button cancelOrderButton = dialogView.findViewById(R.id.cancel_order);
            cancelOrderButton.setVisibility(View.GONE);

            AlertDialog alertDialog = dialogBuilder.create();
            orderButton.setOnClickListener(view -> {
                //TODO: send order again
                alertDialog.cancel();
            });
            alertDialog.show();
        }
    }

    public class EmptyViewHolder extends RecyclerView.ViewHolder {

        public EmptyViewHolder(View view) {super(view);}
    }
}