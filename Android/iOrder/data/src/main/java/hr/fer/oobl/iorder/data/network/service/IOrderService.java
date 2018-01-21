package hr.fer.oobl.iorder.data.network.service;

import java.util.List;

import hr.fer.oobl.iorder.data.network.model.ApiCategory;
import hr.fer.oobl.iorder.data.network.model.ApiEstablishment;
import hr.fer.oobl.iorder.data.network.model.ApiOrderHistory;
import hr.fer.oobl.iorder.data.network.model.ApiOrderPost;
import hr.fer.oobl.iorder.data.network.model.ApiToken;
import hr.fer.oobl.iorder.data.network.model.ApiUser;
import hr.fer.oobl.iorder.data.network.model.ApiUserCredentials;
import retrofit2.http.Body;
import retrofit2.http.FormUrlEncoded;
import retrofit2.http.GET;
import retrofit2.http.Header;
import retrofit2.http.POST;
import retrofit2.http.Path;
import rx.Single;

public interface IOrderService {

    @POST("/api/User/Register/Customer")
    Single<Void> createUser(@Body ApiUser registeringUser);

    @POST("/api/Auth")
    Single<ApiToken> login(@Body ApiUserCredentials loggingUser);

    @GET("/api/Establishment/{establishmentId}")
    Single<ApiEstablishment> getEstablishment(@Header("Authorization") String authHeader, @Path("establishmentId") long establishmentId);

    @GET("/api/Order/CustomerHistory/{establishmentId}")
    Single<List<ApiOrderHistory>> getOrderHistoryForUserAndEstablishment(@Header("Authorization") String authHeader, @Path("establishmentId") long establishmentId);

    @POST("/api/Order")
    Single<Void> processOrder(@Header("Authorization") String authHeader, @Body ApiOrderPost apiOrderPost);
}
