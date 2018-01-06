package hr.fer.oobl.iorder.domain.repository;

import java.util.List;

import hr.fer.oobl.iorder.domain.model.Order;
import hr.fer.oobl.iorder.domain.model.OrderHistoryRequest;
import hr.fer.oobl.iorder.domain.model.UserCredentials;
import hr.fer.oobl.iorder.domain.model.UserRegistration;
import rx.Single;

public interface IOrderRepository {

    Single<String> fetchAuthToken(UserCredentials userCredentials);

    Single<Void> requestRegistration(UserRegistration userRegistration);

    Single<List<Order>> fetchOrderHistory(OrderHistoryRequest orderHistoryRequest);
}
