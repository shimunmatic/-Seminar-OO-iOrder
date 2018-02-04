package hr.fer.oobl.iorder.data.network.model;

import com.google.gson.annotations.SerializedName;

import java.util.List;

import hr.fer.oobl.iorder.domain.model.Category;

public final class ApiEstablishment {

    @SerializedName("id")
    public long id;

    @SerializedName("name")
    public String name;

    @SerializedName("categories")
    public List<ApiCategory> categories;

    public ApiEstablishment(final long id, final String name, final List<ApiCategory> categories) {
        this.id = id;
        this.name = name;
        this.categories = categories;
    }

    public ApiEstablishment() {
    }
}
