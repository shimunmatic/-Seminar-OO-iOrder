package hr.fer.oobl.iorder.data.network.model;

import android.location.Location;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public final class ApiEstablishment {

    @SerializedName("id")
    public long id;

    @SerializedName("name")
    public String name;

    @SerializedName("locations")
    public List<Location> locations;

    public ApiEstablishment(final long id, final String name, final List<Location> locations) {
        this.id = id;
        this.name = name;
        this.locations = locations;
    }

    public ApiEstablishment() {}
}
