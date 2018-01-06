package hr.fer.oobl.iorder.data.network.model;

import com.google.gson.annotations.SerializedName;

public final class ApiProductPost {

    @SerializedName("id")
    public long id;

    @SerializedName("name")
    public String name;

    @SerializedName("price")
    public float price;

    @SerializedName("quantity")
    public int quantity;

    public ApiProductPost(final long id, final String name, final float price, final int quantity) {
        this.id = id;
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }

    public ApiProductPost() {}
}
