package hr.fer.oobl.iorder.domain.interactor.history;

import java.util.List;

import hr.fer.oobl.iorder.domain.interactor.type.SingleUseCaseWithParameter;
import hr.fer.oobl.iorder.domain.model.Order;
import hr.fer.oobl.iorder.domain.model.OrderHistoryRequest;
import hr.fer.oobl.iorder.domain.repository.IOrderRepository;
import rx.Single;

public final class GetOrderHistoryForUserUseCase implements SingleUseCaseWithParameter<OrderHistoryRequest, List<Order>> {

    private IOrderRepository iOrderRepository;

    public GetOrderHistoryForUserUseCase(final IOrderRepository iOrderRepository) {
        this.iOrderRepository = iOrderRepository;
    }

    @Override
    public Single<List<Order>> execute(final OrderHistoryRequest orderHistoryRequest) {
        return iOrderRepository.fetchOrderHistory(orderHistoryRequest);
    }
}
