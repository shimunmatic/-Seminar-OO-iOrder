package hr.fer.oobl.iorder.data.network.client;

import java.util.List;

import hr.fer.oobl.iorder.data.network.model.ApiOrderHistory;
import hr.fer.oobl.iorder.data.network.model.ApiUser;
import hr.fer.oobl.iorder.data.network.model.ApiUserCredentials;
import hr.fer.oobl.iorder.domain.model.Order;
import rx.Single;

public interface IOrderClient {

    Single<String> fetchAuthToken(ApiUserCredentials apiUserCredentials);

    Single<Void> registerUser(ApiUser apiUser);

    Single<List<ApiOrderHistory>> fetchOrderHistoryForUser(String authToken, String username, long establishmentId);
}
