package hr.fer.oobl.iorder.domain.model;

import java.util.List;

public final class Order {

    private List<Product> products;
    private String date;
    private Establishment establishment;
    private String price;

    public Order(final List<Product> products, final String date, final Establishment establishment, final String price) {
        this.products = products;
        this.date = date;
        this.establishment = establishment;
        this.price = price;
    }

    public Order(final List<Product> products, final String date, final String price) {
        this.products = products;
        this.date = date;
        this.price = price;
    }

    public List<Product> getProducts() {
        return products;
    }

    public void setProducts(final List<Product> products) {
        this.products = products;
    }

    public String getDate() {
        return date;
    }

    public void setDate(final String date) {
        this.date = date;
    }

    public Establishment getEstablishment() {
        return establishment;
    }

    public void setEstablishment(final Establishment establishment) {
        this.establishment = establishment;
    }

    public String getPrice() {
        return price;
    }

    public void setPrice(final String price) {
        this.price = price;
    }

    @Override
    public String toString() {
        return "Order{" +
                "products=" + products +
                ", date='" + date + '\'' +
                ", establishment=" + establishment +
                ", price='" + price + '\'' +
                '}';
    }
}
