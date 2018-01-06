package hr.fer.oobl.iorder.data.network.mapper;

import com.annimon.stream.Stream;

import java.util.List;

import hr.fer.oobl.iorder.data.network.model.ApiEstablishment;
import hr.fer.oobl.iorder.data.network.model.ApiOrderHistory;
import hr.fer.oobl.iorder.data.network.model.ApiProductPost;
import hr.fer.oobl.iorder.data.network.model.ApiUser;
import hr.fer.oobl.iorder.data.network.model.ApiUserCredentials;
import hr.fer.oobl.iorder.domain.model.Establishment;
import hr.fer.oobl.iorder.domain.model.Order;
import hr.fer.oobl.iorder.domain.model.Product;
import hr.fer.oobl.iorder.domain.model.UserCredentials;
import hr.fer.oobl.iorder.domain.model.UserRegistration;

public final class ApiIOrderToDomainMapperImpl implements ApiIOrderToDomainMapper {

    @Override
    public ApiUserCredentials mapUserCredentials(final UserCredentials userCredentials) {
        return new ApiUserCredentials(userCredentials.getUsername(), userCredentials.getPassword());
    }

    @Override
    public ApiUser mapApiUser(final UserRegistration userRegistration) {
        return new ApiUser(userRegistration.getUsername(), userRegistration.getFirstName(), userRegistration.getSurname(), userRegistration.getEmail(),
                           userRegistration.getPassword());
    }

    @Override
    public List<Order> mapApiOrderHistory(final List<ApiOrderHistory> apiOrderHistories) {
        return Stream.of(apiOrderHistories)
                     .map(this::mapToOrder)
                     .toList();
    }

    private Order mapToOrder(final ApiOrderHistory apiOrderHistory) {
        return new Order(mapToProducts(apiOrderHistory.products), apiOrderHistory.date, mapToEstablishment(apiOrderHistory.apiEstablishment),
                         String.valueOf(apiOrderHistory.price));
    }

    private List<Product> mapToProducts(final List<ApiProductPost> products) {
        return Stream.of(products)
                     .map(this::mapToProduct)
                     .toList();
    }

    private Product mapToProduct(final ApiProductPost apiProductPost) {
        return new Product(apiProductPost.id, apiProductPost.name, String.valueOf(apiProductPost.price), String.valueOf(apiProductPost.quantity));
    }

    private Establishment mapToEstablishment(final ApiEstablishment apiEstablishment) {
        return new Establishment(apiEstablishment.id, apiEstablishment.name);
    }
}
