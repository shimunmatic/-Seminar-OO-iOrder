package hr.fer.oobl.iorder.data.network.model;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public final class ApiOrderHistory {

    @SerializedName("orderedProducts")
    public List<ApiProductPairGet> products;

    @SerializedName("date")
    public String date;

    @SerializedName("price")
    public float price;

    @Override
    public String toString() {
        return "ApiOrderHistory{" +
                "products=" + products +
                ", date='" + date + '\'' +
                ", price=" + price +
                '}';
    }
}
