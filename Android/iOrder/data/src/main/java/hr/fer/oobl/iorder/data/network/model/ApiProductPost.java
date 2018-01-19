package hr.fer.oobl.iorder.data.network.model;

import com.google.gson.annotations.SerializedName;

public final class ApiProductPost {

    @SerializedName("id")
    public long id;

    @SerializedName("name")
    public String name;

    @SerializedName("price")
    public float price;

    public ApiProductPost(final long id, final String name, final float price) {
        this.id = id;
        this.name = name;
        this.price = price;
    }

    public ApiProductPost() {}

    @Override
    public String toString() {
        return "ApiProductPost{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", price=" + price +
                '}';
    }
}
