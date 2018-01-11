package hr.fer.oobl.iorder.domain.model;

import java.util.List;

public final class OrderRequest {

    private final List<Product> products;

    private final String customerId;

    private final long locationId;

    private final long establishmentId;

    public OrderRequest(final List<Product> products, final String customerId, final long locationId, final long establishmentId) {
        this.products = products;
        this.customerId = customerId;
        this.locationId = locationId;
        this.establishmentId = establishmentId;
    }

    public List<Product> getProducts() {
        return products;
    }

    public String getCustomerId() {
        return customerId;
    }

    public long getLocationId() {
        return locationId;
    }

    public long getEstablishmentId() {
        return establishmentId;
    }
}
