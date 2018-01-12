package hr.fer.oobl.iorder.data.network.mapper;

import java.util.List;

import hr.fer.oobl.iorder.data.network.model.ApiCategory;
import hr.fer.oobl.iorder.data.network.model.ApiEstablishment;
import hr.fer.oobl.iorder.data.network.model.ApiOrderHistory;
import hr.fer.oobl.iorder.data.network.model.ApiOrderPost;
import hr.fer.oobl.iorder.data.network.model.ApiToken;
import hr.fer.oobl.iorder.data.network.model.ApiUser;
import hr.fer.oobl.iorder.data.network.model.ApiUserCredentials;
import hr.fer.oobl.iorder.domain.model.Category;
import hr.fer.oobl.iorder.domain.model.Establishment;
import hr.fer.oobl.iorder.domain.model.Order;
import hr.fer.oobl.iorder.domain.model.OrderRequest;
import hr.fer.oobl.iorder.domain.model.UserCredentials;
import hr.fer.oobl.iorder.domain.model.UserRegistration;
import rx.Single;

public interface ApiIOrderToDomainMapper {

    ApiUserCredentials mapUserCredentials(UserCredentials userCredentials);

    ApiUser mapApiUser(UserRegistration userRegistration);

    List<Order> mapApiOrderHistory(List<ApiOrderHistory> apiOrderHistories);

    Establishment mapToEstablishment(ApiEstablishment apiEstablishment);

    ApiOrderPost mapOrderRequest(OrderRequest orderRequest);

    String mapApiToken(ApiToken apiToken);
}
