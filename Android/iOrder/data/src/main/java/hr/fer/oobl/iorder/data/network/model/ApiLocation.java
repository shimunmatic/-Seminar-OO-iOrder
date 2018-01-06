package hr.fer.oobl.iorder.data.network.model;

import com.google.gson.annotations.SerializedName;

public final class ApiLocation {

    @SerializedName("id")
    public long id;

    @SerializedName("name")
    public String name;

    public ApiLocation(final long id, final String name) {
        this.id = id;
        this.name = name;
    }
}
