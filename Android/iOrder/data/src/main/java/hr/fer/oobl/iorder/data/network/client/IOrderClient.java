package hr.fer.oobl.iorder.data.network.client;

import java.util.List;

import hr.fer.oobl.iorder.data.network.model.ApiCategory;
import hr.fer.oobl.iorder.data.network.model.ApiEstablishment;
import hr.fer.oobl.iorder.data.network.model.ApiOrderHistory;
import hr.fer.oobl.iorder.data.network.model.ApiOrderPost;
import hr.fer.oobl.iorder.data.network.model.ApiUser;
import hr.fer.oobl.iorder.data.network.model.ApiUserCredentials;
import hr.fer.oobl.iorder.domain.model.Category;
import hr.fer.oobl.iorder.domain.model.Establishment;
import hr.fer.oobl.iorder.domain.model.Order;
import rx.Single;

public interface IOrderClient {

    Single<String> fetchAuthToken(ApiUserCredentials apiUserCredentials);

    Single<Void> registerUser(ApiUser apiUser);

    Single<List<ApiOrderHistory>> fetchOrderHistoryForUser(String authToken, String username, long establishmentId);

    Single<List<ApiCategory>> fetchCategories(final String authToken, Long establishmentId);

    Single<ApiEstablishment> findEstablishment(String authToken, long establishmentId, long locationInsideEstablishmentId);

    Single<Void> processOrderRequest(String authToken, ApiOrderPost apiOrderPost);
}
