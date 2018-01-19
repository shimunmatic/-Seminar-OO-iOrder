package hr.fer.oobl.iorder.data.network.client;

import java.util.List;

import hr.fer.oobl.iorder.data.network.model.ApiEstablishment;
import hr.fer.oobl.iorder.data.network.model.ApiOrderHistory;
import hr.fer.oobl.iorder.data.network.model.ApiOrderPost;
import hr.fer.oobl.iorder.data.network.model.ApiToken;
import hr.fer.oobl.iorder.data.network.model.ApiUser;
import hr.fer.oobl.iorder.data.network.model.ApiUserCredentials;
import hr.fer.oobl.iorder.data.network.service.IOrderService;
import rx.Single;

public final class IOrderClientImpl implements IOrderClient {

    private IOrderService iOrderService;

    public IOrderClientImpl(final IOrderService iOrderService) {
        this.iOrderService = iOrderService;
    }

    @Override
    public Single<ApiToken> fetchAuthToken(final ApiUserCredentials apiUserCredentials) {
        return iOrderService.login(apiUserCredentials);
    }

    @Override
    public Single<Void> registerUser(final ApiUser apiUser) {
        return iOrderService.createUser(apiUser);
    }

    @Override
    public Single<List<ApiOrderHistory>> fetchOrderHistory(final String authToken, final long establishmentId) {
        return iOrderService.getOrderHistoryForUserAndEstablishment("Bearer " + authToken, establishmentId);
    }

    @Override
    public Single<ApiEstablishment> findEstablishment(final String authToken, final Long establishmentId) {
        return iOrderService.getEstablishment("Bearer " + authToken, establishmentId);
    }

    @Override
    public Single<Void> processOrderRequest(final String authToken, final ApiOrderPost apiOrderPost) {
        return iOrderService.processOrder("Bearer " + authToken, apiOrderPost);
    }
}
