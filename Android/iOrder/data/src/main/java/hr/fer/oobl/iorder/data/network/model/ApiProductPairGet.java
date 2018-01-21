package hr.fer.oobl.iorder.data.network.model;

import com.google.gson.annotations.SerializedName;

public final class ApiProductPairGet {

    @SerializedName("quantity")
    public int quantity;

    @SerializedName("product")
    public ApiProduct product;

    public ApiProductPairGet(int quantity, ApiProduct product) {
        this.quantity = quantity;
        this.product = product;
    }

    @Override
    public String toString() {
        return "ApiProductPairGet{" +
                "quantity=" + quantity +
                ", product=" + product +
                '}';
    }
}
