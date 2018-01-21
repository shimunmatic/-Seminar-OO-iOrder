package hr.fer.oobl.iorder.data.network.mapper;

import android.util.Log;

import com.annimon.stream.Stream;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;

import hr.fer.oobl.iorder.data.network.model.ApiCategory;
import hr.fer.oobl.iorder.data.network.model.ApiEstablishment;
import hr.fer.oobl.iorder.data.network.model.ApiOrderHistory;
import hr.fer.oobl.iorder.data.network.model.ApiOrderPost;
import hr.fer.oobl.iorder.data.network.model.ApiProduct;
import hr.fer.oobl.iorder.data.network.model.ApiProductPairGet;
import hr.fer.oobl.iorder.data.network.model.ApiProductPairSend;
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

    private static final String API_RESPONSE_DATE_FORMAT = "yyyy-MM-dd'T'HH:mm:ss.SSS";
    private static final String MY_DATE_FORMAT = "DD/mm/yy HH:mm";

    private final ThreadLocal<DateFormat> myDateFormat = new ThreadLocal<DateFormat>() {

        @Override
        protected SimpleDateFormat initialValue() {
            return new SimpleDateFormat(MY_DATE_FORMAT, Locale.US);
        }
    };

    private final ThreadLocal<DateFormat> apiResponseFormat = new ThreadLocal<DateFormat>() {

        @Override
        protected SimpleDateFormat initialValue() {
            return new SimpleDateFormat(API_RESPONSE_DATE_FORMAT, Locale.US);
        }
    };

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
        final List<Order> orderHistory = new ArrayList<>(apiOrderHistories.size());
        for (final ApiOrderHistory apiOrderHistory : apiOrderHistories) {
            orderHistory.add(mapToOrder(apiOrderHistory));
        }
        return orderHistory;
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
        String date;

        try {
            final Date orderDate = apiResponseFormat.get().parse(apiOrderHistory.date);
            date = myDateFormat.get().format(orderDate);
        } catch (ParseException pe) {
            date = apiOrderHistory.date;
        }
        return new Order(mapToProductsPost(apiOrderHistory.products), date,
                String.valueOf(apiOrderHistory.price));
    }

    private List<Product> mapToProductsPost(final List<ApiProductPairGet> products) {
        return Stream.of(products)
                .map(this::mapToProductPost)
                .toList();
    }

    private Product mapToProductPost(final ApiProductPairGet apiProductPairGet) {
        Log.d("info", apiProductPairGet.toString());
        final Product product =  new Product(apiProductPairGet.product.id, apiProductPairGet.product.name, String.valueOf(apiProductPairGet.product.price), String.valueOf(apiProductPairGet.quantity));
        Log.d("info", product.toString());
        return product;
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

    private List<ApiProductPairSend> mapToApiProducts(final List<Product> products) {
        return Stream.of(products)
                .map(this::mapToApiProductPair)
                .toList();
    }

    private ApiProductPairSend mapToApiProductPair(final Product product) {
        return new ApiProductPairSend(Integer.parseInt(product.getQuantity()), mapToApiProduct(product));
    }

    private ApiProductPost mapToApiProduct(final Product product) {
        return new ApiProductPost(product.getId(), product.getName(), Float.parseFloat(product.getPrice()));
    }
}
