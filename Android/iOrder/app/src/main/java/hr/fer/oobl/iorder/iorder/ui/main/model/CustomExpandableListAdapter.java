package hr.fer.oobl.iorder.iorder.ui.main.model;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.graphics.Typeface;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

import com.annimon.stream.Stream;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import hr.fer.oobl.iorder.domain.interactor.order.ProcessOrderUseCase;
import hr.fer.oobl.iorder.domain.model.Product;
import hr.fer.oobl.iorder.iorder.R;
import hr.fer.oobl.iorder.iorder.ui.main.MainActivity;

public class CustomExpandableListAdapter extends BaseExpandableListAdapter {

    private Activity activity;
    private List<String> expandableListTitle;
    private Map<String, List<Product>> expandableListDetail;

    public CustomExpandableListAdapter(Activity activity, List<String> expandableListTitle,
                                       Map<String, List<Product>> expandableListDetail) {
        this.activity = activity;
        this.expandableListTitle = expandableListTitle;
        this.expandableListDetail = expandableListDetail;
    }

    @Override
    public Object getChild(int listPosition, int expandedListPosition) {
        return this.expandableListDetail.get(this.expandableListTitle.get(listPosition))
                                        .get(expandedListPosition);
    }

    @Override
    public long getChildId(int listPosition, int expandedListPosition) {
        return expandedListPosition;
    }

    @Override
    public View getChildView(int listPosition, final int expandedListPosition,
                             boolean isLastChild, View convertView, ViewGroup parent) {
        final Product product = (Product) getChild(listPosition, expandedListPosition);
        LayoutInflater layoutInflater = null;
        if (convertView == null) {
            layoutInflater = (LayoutInflater) this.activity
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            if (layoutInflater != null) {
                convertView = layoutInflater.inflate(R.layout.list_article, null);
            }
        }
        TextView productName;
        TextView productPrice;
        ImageView addButton;
        ImageView removeButton;
        TextView quantity;

        if (convertView != null) {
            productName = convertView.findViewById(R.id.product);
            productPrice = convertView.findViewById(R.id.price);
            quantity = convertView.findViewById(R.id.quantity);
            addButton = convertView.findViewById(R.id.add_button);
            removeButton = convertView.findViewById(R.id.remove_button);

            if (product.getQuantity().equals("0")) {
                removeButton.setVisibility(View.GONE);
            } else {
                removeButton.setVisibility(View.VISIBLE);
            }

            addButton.setOnClickListener(view -> {
                removeButton.setVisibility(View.VISIBLE);

                int incrementQuantity = Integer.parseInt(product.getQuantity()) + 1;
                product.setQuantity(String.valueOf(incrementQuantity));
                quantity.setText(String.valueOf(incrementQuantity));
                ((MainActivity) activity).updateCartUp(product);
            });

            addButton.setOnLongClickListener(view -> {
                popupDialog(product, quantity);
                removeButton.setVisibility(View.VISIBLE);
                return true;
            });

            removeButton.setOnClickListener(view -> {
                int decrementQuantity = Integer.parseInt(product.getQuantity()) - 1;
                if (decrementQuantity == 0) {
                    removeButton.setVisibility(View.GONE);
                }
                if (decrementQuantity >= 0) {
                    product.setQuantity(String.valueOf(decrementQuantity));
                    quantity.setText(String.valueOf(decrementQuantity));
                    ((MainActivity) activity).updateCartDown(product);
                }
            });
            productPrice.setText(String.valueOf(product.getPrice()));
            productName.setText(product.getName().trim());
            quantity.setText(product.getQuantity());
        }
        return convertView;
    }

    public void emptyQuantities() {
        Stream.of(expandableListDetail.keySet())
              .forEach(title -> {
                  for (Product product : expandableListDetail.get(title)) {
                      product.setQuantity("0");
                  }
              });
    }

    private void popupDialog(final Product product, final TextView quantity) {
        AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(activity, AlertDialog.THEME_HOLO_LIGHT);
        final LayoutInflater layoutInflater = (LayoutInflater) this.activity
                .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View dialogView = null;
        if (layoutInflater != null) {
            dialogView = layoutInflater.inflate(R.layout.alert_add_more_products, null);

            dialogBuilder.setView(dialogView);

            EditText editText = dialogView.findViewById(R.id.more_products);
            ImageView sendImage = dialogView.findViewById(R.id.send);

            AlertDialog alertDialog = dialogBuilder.create();
            sendImage.setOnClickListener(view -> {
                int inputtedQuantity = Integer.parseInt(editText.getText().toString());

                if (inputtedQuantity >= 0) {
                    product.setQuantity(String.valueOf(inputtedQuantity));
                    quantity.setText(String.valueOf(inputtedQuantity));
                    ((MainActivity) activity).updateCartUp(product);
                }
                alertDialog.cancel();
            });
            alertDialog.show();
        }
    }

    @Override
    public int getChildrenCount(int listPosition) {
        return this.expandableListDetail.get(this.expandableListTitle.get(listPosition))
                                        .size();
    }

    @Override
    public Object getGroup(int listPosition) {
        return this.expandableListTitle.get(listPosition);
    }

    @Override
    public int getGroupCount() {
        return this.expandableListTitle.size();
    }

    @Override
    public long getGroupId(int listPosition) {
        return listPosition;
    }

    @Override
    public View getGroupView(int listPosition, boolean isExpanded,
                             View convertView, ViewGroup parent) {
        String listTitle = (String) getGroup(listPosition);
        if (convertView == null) {
            LayoutInflater layoutInflater = (LayoutInflater) this.activity.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            if (layoutInflater != null) {
                convertView = layoutInflater.inflate(R.layout.list_category, null);
            }
        }
        TextView listTitleTextView = null;
        if (convertView != null) {
            listTitleTextView = convertView
                    .findViewById(R.id.listTitle);
        }
        if (listTitleTextView != null) {
            listTitleTextView.setTypeface(Typeface.defaultFromStyle(Typeface.BOLD));
            listTitleTextView.setText(listTitle);
        }
        return convertView;
    }

    @Override
    public boolean hasStableIds() {
        return false;
    }

    @Override
    public boolean isChildSelectable(int listPosition, int expandedListPosition) {
        return true;
    }
}