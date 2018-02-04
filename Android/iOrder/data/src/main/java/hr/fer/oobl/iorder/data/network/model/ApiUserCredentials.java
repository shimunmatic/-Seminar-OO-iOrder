package hr.fer.oobl.iorder.data.network.model;

import com.google.gson.annotations.SerializedName;

public final class ApiUserCredentials {

    @SerializedName("username")
    public String username;

    @SerializedName("password")
    public String password;

    public ApiUserCredentials(final String username, final String password) {
        this.username = username;
        this.password = password;
    }

    public ApiUserCredentials() {
    }
}


