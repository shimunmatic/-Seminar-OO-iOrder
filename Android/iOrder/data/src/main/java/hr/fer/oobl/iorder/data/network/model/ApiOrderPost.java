package hr.fer.oobl.iorder.data.network.model;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public final class ApiOrderPost {

    @SerializedName("orderedProducts")
    public List<ApiProductPairSend> orderedProducts;

    @SerializedName("customerId")
    public String customerId;

    @SerializedName("locationId")
    public long locationId;

    @SerializedName("establishmentId")
    public long establishmentId;

    public ApiOrderPost(final List<ApiProductPairSend> orderedProducts, final String customerId, final long locationId, final long establishmentId) {
        this.orderedProducts = orderedProducts;
        this.customerId = customerId;
        this.locationId = locationId;
        this.establishmentId = establishmentId;
    }

    public ApiOrderPost() {}

    @Override
    public String toString() {
        return "ApiOrderPost{" +
                "orderedProducts=" + orderedProducts +
                ", customerId='" + customerId + '\'' +
                ", locationId=" + locationId +
                ", establishmentId=" + establishmentId +
                '}';
    }
}
