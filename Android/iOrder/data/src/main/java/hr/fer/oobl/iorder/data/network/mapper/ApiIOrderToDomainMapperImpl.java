package hr.fer.oobl.iorder.data.network.mapper;

import com.annimon.stream.Stream;

import java.util.List;

import hr.fer.oobl.iorder.data.network.model.ApiCategory;
import hr.fer.oobl.iorder.data.network.model.ApiEstablishment;
import hr.fer.oobl.iorder.data.network.model.ApiOrderHistory;
import hr.fer.oobl.iorder.data.network.model.ApiOrderPost;
import hr.fer.oobl.iorder.data.network.model.ApiProduct;
import hr.fer.oobl.iorder.data.network.model.ApiProductPost;
import hr.fer.oobl.iorder.data.network.model.ApiToken;
import hr.fer.oobl.iorder.data.network.model.ApiUser;
import hr.fer.oobl.iorder.data.network.model.ApiUserCredentials;
import hr.fer.oobl.iorder.domain.model.Category;
import hr.fer.oobl.iorder.domain.model.Establishment;
import hr.fer.oobl.iorder.domain.model.Order;
import hr.fer.oobl.iorder.domain.model.OrderRequest;
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

    private Category mapToCategory(final ApiCategory apiCategory) {
        return new Category(apiCategory.id, apiCategory.name, mapToProducts(apiCategory.products));
    }

    private List<Product> mapToProducts(final List<ApiProduct> products) {
        return Stream.of(products)
                .map(this::mapToProduct)
                .toList();
    }

    private Product mapToProduct(final ApiProduct apiProduct) {
        return new Product(apiProduct.id, apiProduct.name, String.valueOf(apiProduct.price), String.valueOf(0));
    }

    private Order mapToOrder(final ApiOrderHistory apiOrderHistory) {
        return new Order(mapToProductsPost(apiOrderHistory.products), apiOrderHistory.date, mapToEstablishment(apiOrderHistory.apiEstablishment),
                String.valueOf(apiOrderHistory.price));
    }

    private List<Product> mapToProductsPost(final List<ApiProductPost> products) {
        return Stream.of(products)
                .map(this::mapToProductPost)
                .toList();
    }

    private Product mapToProductPost(final ApiProductPost apiProductPost) {
        return new Product(apiProductPost.id, apiProductPost.name, String.valueOf(apiProductPost.price), String.valueOf(apiProductPost.quantity));
    }

    @Override
    public Establishment mapToEstablishment(final ApiEstablishment apiEstablishment) {
        return new Establishment(apiEstablishment.id, apiEstablishment.name, mapToCategories(apiEstablishment.categories));
    }

    private List<Category> mapToCategories(final List<ApiCategory> categories) {
        return Stream.of(categories)
                .map(this::mapToCategory)
                .toList();
    }

    @Override
    public ApiOrderPost mapOrderRequest(final OrderRequest orderRequest) {
        return new ApiOrderPost(mapToApiProducts(orderRequest.getProducts()), orderRequest.getCustomerId(), orderRequest.getLocationId(), orderRequest.getEstablishmentId());
    }

    @Override
    public String mapApiToken(ApiToken apiToken) {
        return apiToken.token;
    }

    private List<ApiProductPost> mapToApiProducts(final List<Product> products) {
        return Stream.of(products)
                .map(this::mapToApiProduct)
                .toList();
    }

    private ApiProductPost mapToApiProduct(final Product product) {
        return new ApiProductPost(product.getId(), product.getName(), Float.parseFloat(product.getPrice()), Integer.parseInt(product.getQuantity()));
    }
}
