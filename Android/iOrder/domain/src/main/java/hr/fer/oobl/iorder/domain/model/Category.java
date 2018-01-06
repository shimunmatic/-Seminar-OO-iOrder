package hr.fer.oobl.iorder.domain.model;

import java.util.List;

public final class Category {

    private final String name;
    private final List<Product> products;

    public Category(final String name, final List<Product> products) {
        this.name = name;
        this.products = products;
    }

    public String getName() {
        return name;
    }

    public List<Product> getProducts() {
        return products;
    }
}
