package hr.fer.oobl.iorder.domain.model;

import java.util.List;

public final class Establishment {

    private long id;
    private String name;
    private List<Category> categoryList;

    public Establishment(final long id, final String name, final List<Category> categories) {
        this.id = id;
        this.name = name;
        this.categoryList = categories;

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

    public List<Category> getCategoryList() {
        return categoryList;
    }

    public void setCategoryList(List<Category> categoryList) {
        this.categoryList = categoryList;
    }
}
