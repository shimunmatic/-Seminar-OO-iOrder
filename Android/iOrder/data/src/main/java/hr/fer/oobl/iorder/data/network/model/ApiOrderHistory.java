package hr.fer.oobl.iorder.data.network.model;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public final class ApiOrderHistory {

    @SerializedName("products")
    public List<ApiProductPost> products;

    @SerializedName("date")
    public String date;

    @SerializedName("apiEstablishment")
    public ApiEstablishment apiEstablishment;

    @SerializedName("price")
    public float price;
}
