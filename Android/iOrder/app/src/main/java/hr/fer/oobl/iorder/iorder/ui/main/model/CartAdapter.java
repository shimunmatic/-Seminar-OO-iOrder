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
        View view;

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


    public class CartViewHolder extends RecyclerView.ViewHolder {

        private TextView quantity;
        private TextView productName;
        private TextView price;

        public CartViewHolder(View itemView) {
            super(itemView);

            quantity = itemView.findViewById(R.id.cart_quantity);
            productName = itemView.findViewById(R.id.cart_product);
            price = itemView.findViewById(R.id.cart_price);
        }
    }

    public class EmptyViewHolder extends RecyclerView.ViewHolder {

        public EmptyViewHolder(View view) {super(view);}
    }
}