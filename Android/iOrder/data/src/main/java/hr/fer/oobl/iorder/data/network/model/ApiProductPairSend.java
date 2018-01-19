package hr.fer.oobl.iorder.data.network.model;

import com.google.gson.annotations.SerializedName;

public final class ApiProductPairSend {

    @SerializedName("quantity")
    public float quantity;

    @SerializedName("product")
    public ApiProductPost product;

    public ApiProductPairSend(float quantity, ApiProductPost product) {
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
