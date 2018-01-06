package hr.fer.oobl.iorder.domain.model;

public final class OrderHistoryRequest {

    private final String username;
    private final long establishmentId;

    public OrderHistoryRequest(final String username, final long establishmentId) {
        this.username = username;
        this.establishmentId = establishmentId;
    }

    public String getUsername() {
        return username;
    }

    public long getEstablishmentId() {
        return establishmentId;
    }
}
