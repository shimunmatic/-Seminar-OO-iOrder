package hr.fer.oobl.iorder.data.repository;

import java.util.List;

import hr.fer.oobl.iorder.data.network.client.IOrderClient;
import hr.fer.oobl.iorder.data.network.mapper.ApiIOrderToDomainMapper;
import hr.fer.oobl.iorder.data.network.model.ApiToken;
import hr.fer.oobl.iorder.data.util.AccessTokenStorage;
import hr.fer.oobl.iorder.domain.model.Category;
import hr.fer.oobl.iorder.domain.model.Establishment;
import hr.fer.oobl.iorder.domain.model.EstablishmentRequest;
import hr.fer.oobl.iorder.domain.model.Order;
import hr.fer.oobl.iorder.domain.model.OrderHistoryRequest;
import hr.fer.oobl.iorder.domain.model.OrderRequest;
import hr.fer.oobl.iorder.domain.model.UserCredentials;
import hr.fer.oobl.iorder.domain.model.UserRegistration;
import hr.fer.oobl.iorder.domain.repository.IOrderRepository;
import rx.Single;

public final class IOrderRepositoryImpl implements IOrderRepository {

    private final IOrderClient iOrderClient;
    private final ApiIOrderToDomainMapper apiIOrderToDomainMapper;
    private final AccessTokenStorage accessTokenStorage;

    public IOrderRepositoryImpl(final IOrderClient iOrderClient, final ApiIOrderToDomainMapper apiMapper, final AccessTokenStorage accessTokenStorage) {
        this.iOrderClient = iOrderClient;
        this.apiIOrderToDomainMapper = apiMapper;
        this.accessTokenStorage = accessTokenStorage;
    }

    @Override
    public Single<String> fetchAuthToken(final UserCredentials userCredentials) {
        return iOrderClient.fetchAuthToken(apiIOrderToDomainMapper.mapUserCredentials(userCredentials))
                            .map(apiToken -> apiIOrderToDomainMapper.mapApiToken(apiToken))
                            .doOnSuccess(accessTokenStorage::setAuthToken);
    }

    @Override
    public Single<Void> requestRegistration(final UserRegistration userRegistration) {
        return iOrderClient.registerUser(apiIOrderToDomainMapper.mapApiUser(userRegistration));
    }

    @Override
    public Single<List<Order>> fetchOrderHistory(final OrderHistoryRequest orderHistoryRequest) {
        return iOrderClient.fetchOrderHistoryForUser(accessTokenStorage.getAuthToken(),
                                                     orderHistoryRequest.getUsername(),
                                                     orderHistoryRequest.getEstablishmentId())
                           .map(apiIOrderToDomainMapper::mapApiOrderHistory);
    }

    @Override
    public Single<Establishment> findEstablishment(final Long establishmentId) {
        return iOrderClient.findEstablishment(accessTokenStorage.getAuthToken(), establishmentId)
                           .map(apiIOrderToDomainMapper::mapToEstablishment);
    }

    @Override
    public Single<Void> processOrder(final OrderRequest orderRequest) {
        return iOrderClient.processOrderRequest(accessTokenStorage.getAuthToken(), apiIOrderToDomainMapper.mapOrderRequest(orderRequest));
    }
}
