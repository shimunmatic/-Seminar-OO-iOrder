package hr.fer.oobl.iorder.iorder.ui.main;

import android.app.AlertDialog;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.BaseExpandableListAdapter;
import android.widget.Button;
import android.widget.ExpandableListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.List;

import javax.inject.Inject;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnClick;
import hr.fer.oobl.iorder.domain.model.Product;
import hr.fer.oobl.iorder.iorder.R;
import hr.fer.oobl.iorder.iorder.base.BaseActivity;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;
import hr.fer.oobl.iorder.iorder.injection.activity.ActivityComponent;
import hr.fer.oobl.iorder.iorder.ui.main.model.CartAdapter;
import hr.fer.oobl.iorder.iorder.ui.main.model.CustomExpandableListAdapter;

public class MainActivity extends BaseActivity implements MainContract.View {

    private static final String QR_CODE_ERROR = "QR code has invalid types of data.";

    @BindView(R.id.cartQuantity)
    TextView cartQuantity;

    @BindView(R.id.currentBill)
    TextView currentBill;

    @BindView(R.id.establishment_name)
    TextView establishmentNameTV;

    @BindView(R.id.expandableListView)
    ExpandableListView expandableListView;

    @Inject
    MainContract.Presenter presenter;

    private long locationId;
    private long establishmentId;

    private BaseExpandableListAdapter expandableListAdapter;

    @Override
    protected void onCreate(@Nullable final Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main_layout);
        ButterKnife.bind(this);

        final String code = getIntent().getExtras().getString("code");

        if (code != null && !code.isEmpty()) {
            final String[] parameters = code.split("&");

            try {
                establishmentId = Long.parseLong(parameters[0].split("=")[1]);
                locationId = Long.parseLong(parameters[1].split("=")[1]);
                presenter.fetchCategories(establishmentId);
            } catch (NumberFormatException ne) {
                showError(QR_CODE_ERROR);
            }
        } else {
            showError(QR_CODE_ERROR);
        }
    }

    @Override
    public void showError(final String error) {
        Toast.makeText(this, error, Toast.LENGTH_SHORT).show();
    }

    @Override
    public void fillViewState() {
        establishmentNameTV.setText(presenter.getEstablishmentName());
        expandableListAdapter = new CustomExpandableListAdapter(this, presenter.getExpandableTitles(), presenter.getExpandableItems());
        expandableListView.setAdapter(expandableListAdapter);
    }

    @Override
    public void showOrderSuccess() {
        Toast.makeText(this, "Order processed successfully! :)", Toast.LENGTH_LONG).show();
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
                presenter.sendOrder(establishmentId, locationId);
                alertDialog.cancel();
            });
            cancelOrderButton.setOnClickListener(v -> {
                alertDialog.cancel();
            });
            alertDialog.show();
        }
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
