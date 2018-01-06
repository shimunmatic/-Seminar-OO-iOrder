package hr.fer.oobl.iorder.data.network.model;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public final class ApiCategory {

    @SerializedName("id")
    public long id;

    @SerializedName("name")
    public String name;

    @SerializedName("products")
    public List<ApiProduct> products;
}
