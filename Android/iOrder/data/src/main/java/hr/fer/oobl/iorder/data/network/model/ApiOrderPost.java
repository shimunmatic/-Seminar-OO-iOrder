package hr.fer.oobl.iorder.data.network.model;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public final class ApiOrderPost {

    @SerializedName("products")
    public List<ApiProductPost> products;

    @SerializedName("customerId")
    public String customerId;

    @SerializedName("locationId")
    public long locationId;

    @SerializedName("establishmentIdd")
    public long establishmentId;

    public ApiOrderPost(final List<ApiProductPost> products, final String customerId, final long locationId, final long establishmentId) {
        this.products = products;
        this.customerId = customerId;
        this.locationId = locationId;
        this.establishmentId = establishmentId;
    }

    public ApiOrderPost() {}
}
