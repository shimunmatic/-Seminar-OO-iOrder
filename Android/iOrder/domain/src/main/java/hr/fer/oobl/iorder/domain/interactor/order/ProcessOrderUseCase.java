package hr.fer.oobl.iorder.domain.interactor.order;

import hr.fer.oobl.iorder.domain.interactor.type.SingleUseCaseWithParameter;
import hr.fer.oobl.iorder.domain.model.OrderRequest;
import hr.fer.oobl.iorder.domain.repository.IOrderRepository;
import rx.Single;

public final class ProcessOrderUseCase implements SingleUseCaseWithParameter<OrderRequest, Void> {


    private IOrderRepository iOrderRepository;

    public ProcessOrderUseCase(final IOrderRepository iOrderRepository) {
        this.iOrderRepository = iOrderRepository;
    }

    @Override
    public Single<Void> execute(final OrderRequest orderRequest) {
        return iOrderRepository.processOrder(orderRequest);
    }
}
