package hr.fer.oobl.iorder.domain.model;

public final class Establishment {

    private long id;
    private String name;

    public Establishment(final long id, final String name) {
        this.id = id;
        this.name = name;
    }

    public long getId() {
        return id;
    }

    public void setId(final long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(final String name) {
        this.name = name;
    }
}
