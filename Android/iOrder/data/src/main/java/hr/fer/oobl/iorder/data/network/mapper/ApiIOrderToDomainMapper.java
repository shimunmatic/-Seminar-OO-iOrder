package hr.fer.oobl.iorder.data.network.mapper;

import java.util.List;

import hr.fer.oobl.iorder.data.network.model.ApiOrderHistory;
import hr.fer.oobl.iorder.data.network.model.ApiUser;
import hr.fer.oobl.iorder.data.network.model.ApiUserCredentials;
import hr.fer.oobl.iorder.domain.model.Order;
import hr.fer.oobl.iorder.domain.model.UserCredentials;
import hr.fer.oobl.iorder.domain.model.UserRegistration;
import rx.Single;

public interface ApiIOrderToDomainMapper {

    ApiUserCredentials mapUserCredentials(UserCredentials userCredentials);

    ApiUser mapApiUser(UserRegistration userRegistration);

    List<Order> mapApiOrderHistory(List<ApiOrderHistory> apiOrderHistories);
}
