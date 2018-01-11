package hr.fer.oobl.iorder.domain.model;

public final class EstablishmentRequest {

    private final long establishmentId;
    private final long locationInsideEstablishmentId;

    public EstablishmentRequest(final long establishmentId, final long locationInsideEstablishmentId) {
        this.establishmentId = establishmentId;
        this.locationInsideEstablishmentId = locationInsideEstablishmentId;
    }

    public long getEstablishmentId() {
        return establishmentId;
    }

    public long getLocationInsideEstablishmentId() {
        return locationInsideEstablishmentId;
    }
}

