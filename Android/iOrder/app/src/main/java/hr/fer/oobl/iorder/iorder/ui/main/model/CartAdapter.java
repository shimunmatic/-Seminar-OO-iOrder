package hr.fer.oobl.iorder.iorder.ui.main.model;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.List;

import hr.fer.oobl.iorder.domain.model.Product;
import hr.fer.oobl.iorder.iorder.R;

public class CartAdapter extends RecyclerView.Adapter<RecyclerView.ViewHolder> {

    private static final int ITEMS = 1;
    private static final int EMPTY_STATE = 0;

    private List<Product> cartProducts;
    private Context context;

    public CartAdapter(final List<Product> cartProducts, final Context context) {
        this.cartProducts = cartProducts;
        this.context = context;
    }

    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(final ViewGroup parent, final int viewType) {
        LayoutInflater inflater = LayoutInflater.from(context);
        RecyclerView.ViewHolder viewHolder = null;
        View view = null;

        switch (viewType) {
            case EMPTY_STATE:
                view = inflater.inflate(R.layout.cart_empty_state, parent, false);
                viewHolder = new EmptyViewHolder(view);
                break;
            case ITEMS:
                view = inflater.inflate(R.layout.cart_item, parent, false);
                viewHolder = new CartViewHolder(view);
                break;
            default:
                break;
        }

        return viewHolder;
    }

    @Override
    public void onBindViewHolder(final RecyclerView.ViewHolder holder, final int position) {
        if (getItemViewType(position) == ITEMS) {
            Product product = cartProducts.get(position);

            CartViewHolder cartViewHolder = (CartViewHolder) holder;
            String quantityString = product.getQuantity() + "x";
            cartViewHolder.quantity.setText(quantityString);
            cartViewHolder.productName.setText(product.getName());

            double price = Integer.parseInt(product.getQuantity()) * Double.parseDouble(product.getFormattedPrice());
            String priceString = String.valueOf(price) + " HRK";
            cartViewHolder.price.setText(priceString);
        }
    }

    @Override
    public int getItemViewType(int position) {
        if (cartProducts == null || cartProducts.isEmpty()) {
            return EMPTY_STATE;
        } else {
            return ITEMS;
        }
    }

    @Override
    public int getItemCount() {
        return cartProducts.size();
    }

    // Provide a direct reference to each of the views within a data item
    // Used to cache the views within the item layout for fast access
    public class CartViewHolder extends RecyclerView.ViewHolder {

        private TextView quantity;
        private TextView productName;
        private TextView price;

        // We also create a constructor that accepts the entire item row
        // and does the view lookups to find each subview
        public CartViewHolder(View itemView) {
            // Stores the itemView in a public final member variable that can be used
            // to access the context from any ViewHolder instance.
            super(itemView);

            quantity = (TextView) itemView.findViewById(R.id.cart_quantity);
            productName = (TextView) itemView.findViewById(R.id.cart_product);
            price = itemView.findViewById(R.id.cart_price);
        }
    }

    public class EmptyViewHolder extends RecyclerView.ViewHolder {

        public EmptyViewHolder(View view) {super(view);}
    }
}