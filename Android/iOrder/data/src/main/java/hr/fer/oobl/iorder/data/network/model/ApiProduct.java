package hr.fer.oobl.iorder.data.network.model;

import com.google.gson.annotations.SerializedName;

public final class ApiProduct {

    @SerializedName("id")
    public long id;

    @SerializedName("name")
    public String name;

    @SerializedName("price")
    public float price;
}
