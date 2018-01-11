package hr.fer.oobl.iorder.domain.model;

public final class Product {

    private long id;
    private String name;
    private String price;
    private String quantity;

    public Product(final long id, final String name, final String price, final String quantity) {
        this.id = id;
        this.name = name;
        this.price = price;
        this.quantity = "0";
    }

    public long getId() {
        return id;
    }

    public void setId(final long id) {
        this.id = id;
    }

    public void setName(final String name) {
        this.name = name;
    }

    public void setPrice(final String price) {
        this.price = price;
    }

    public String getName() {
        return name;
    }

    public String getPrice() {
        return price;
    }

    public String getQuantity() {
        return quantity;
    }

    public void setQuantity(final String quantity) {
        this.quantity = quantity;
    }

    public String getFormattedPrice() {
        return price.replace(",", ".");
    }

    @Override
    public boolean equals(final Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }

        final Product product = (Product) o;

        if (!name.equals(product.name)) {
            return false;
        }
        if (!price.equals(product.price)) {
            return false;
        }
        return quantity.equals(product.quantity);
    }

    @Override
    public int hashCode() {
        int result = name.hashCode();
        result = 31 * result + price.hashCode();
        result = 31 * result + quantity.hashCode();
        return result;
    }
}
