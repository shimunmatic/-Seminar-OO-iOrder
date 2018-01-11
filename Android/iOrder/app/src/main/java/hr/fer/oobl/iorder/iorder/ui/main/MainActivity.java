package hr.fer.oobl.iorder.iorder.ui.main;

import android.app.AlertDialog;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.Button;
import android.widget.ExpandableListAdapter;
import android.widget.ExpandableListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import javax.inject.Inject;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnClick;
import hr.fer.oobl.iorder.data.network.model.ApiOrderHistory;
import hr.fer.oobl.iorder.domain.model.Product;
import hr.fer.oobl.iorder.iorder.R;
import hr.fer.oobl.iorder.iorder.base.BaseActivity;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;
import hr.fer.oobl.iorder.iorder.injection.activity.ActivityComponent;
import hr.fer.oobl.iorder.iorder.ui.main.model.CartAdapter;
import hr.fer.oobl.iorder.iorder.ui.main.model.CustomExpandableListAdapter;
import hr.fer.oobl.iorder.iorder.ui.main.model.ExpandableListDataPump;

public class MainActivity extends BaseActivity implements MainContract.View {

    @BindView(R.id.cartQuantity)
    TextView cartQuantity;

    @Inject
    MainContract.Presenter presenter;

    @BindView(R.id.currentBill)
    TextView currentBill;

    private ExpandableListView expandableListView;
    private ExpandableListAdapter expandableListAdapter;
    private List<String> expandableListTitle;
    private HashMap<String, List<Product>> expandableListDetail;

    @Override
    protected void onCreate(@Nullable final Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main_layout);
        ButterKnife.bind(this);

        expandableListView = findViewById(R.id.expandableListView);
        expandableListDetail = ExpandableListDataPump.getData();
        expandableListTitle = new ArrayList<>(expandableListDetail.keySet());
        expandableListAdapter = new CustomExpandableListAdapter(this, expandableListTitle, expandableListDetail);
        expandableListView.setAdapter(expandableListAdapter);
    }

    public void updateCartUp(final Product product) {
        presenter.incrementCart(product);
    }

    @Override
    public void updateCartView(final int currentQuantity) {
        cartQuantity.setText(String.valueOf(currentQuantity));
    }

    @Override
    public void updateBill(final double bill) {
        final String billString = String.valueOf(bill) + " HRK";
        currentBill.setText(billString);
    }

    public void updateCartDown(final Product product) {
        presenter.decrementCart(product);
    }

    @OnClick(R.id.scanner)
    public void scannerPressed() {
        Toast.makeText(this, "Scanner is starting...", Toast.LENGTH_SHORT).show();
        presenter.startScanner();
    }

    @OnClick({R.id.cart, R.id.cartQuantity})
    public void cartPressed() {
        AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(this, AlertDialog.THEME_HOLO_LIGHT);
        final List<Product> products = presenter.getCartProducts();
        View dialogView;

        if (products == null || products.isEmpty()) {
            dialogView = getLayoutInflater().inflate(R.layout.cart_empty_state, null);
            final Button dismissButton = dialogView.findViewById(R.id.dismiss);
            dialogBuilder.setView(dialogView);

            AlertDialog alertDialog = dialogBuilder.create();
            dismissButton.setOnClickListener(v -> alertDialog.cancel());
            alertDialog.show();
        } else {
            dialogView = getLayoutInflater().inflate(R.layout.alert_cart_layout, null);

            dialogBuilder.setView(dialogView);

            final RecyclerView recyclerView = dialogView.findViewById(R.id.recycler_products);
            final CartAdapter cartAdapter = new CartAdapter(products, this);
            recyclerView.setAdapter(cartAdapter);
            recyclerView.setLayoutManager(new LinearLayoutManager(this));

            final TextView bill = dialogView.findViewById(R.id.bill);
            String billText = "Price to pay: " + currentBill.getText().toString();
            bill.setText(billText);

            final Button orderButton = dialogView.findViewById(R.id.order_button);
            final Button cancelOrderButton = dialogView.findViewById(R.id.cancel_order);

            AlertDialog alertDialog = dialogBuilder.create();
            orderButton.setOnClickListener(view -> {
                ApiOrderHistory order = new ApiOrderHistory();
                //TODO: Send ApiOrderHistory
                alertDialog.cancel();
            });
            cancelOrderButton.setOnClickListener(v -> {
                presenter.getCartProducts().clear();
                cartAdapter.notifyDataSetChanged();
            });
            alertDialog.show();
        }
    }

    @OnClick({R.id.blackboard, R.id.notification_icon})
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
