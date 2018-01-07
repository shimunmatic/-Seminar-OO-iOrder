package hr.fer.oobl.iorder.domain.model;

import java.util.List;

public final class Category {

    private final long id;
    private final String name;
    private final List<Product> products;

    public Category(final long id, final String name, final List<Product> products) {
        this.id = id;
        this.name = name;
        this.products = products;
    }

    public String getName() {
        return name;
    }

    public List<Product> getProducts() {
        return products;
    }

    public long getId() {
        return id;
    }
}
