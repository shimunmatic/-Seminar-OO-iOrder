package hr.fer.oobl.iorder.domain.interactor.establishment;

import hr.fer.oobl.iorder.domain.interactor.type.SingleUseCaseWithParameter;
import hr.fer.oobl.iorder.domain.model.Establishment;
import hr.fer.oobl.iorder.domain.repository.IOrderRepository;
import rx.Single;

public final class GetEstablishmentFromQRCodeUseCase implements SingleUseCaseWithParameter<Long, Establishment> {

    private IOrderRepository iOrderRepository;

    public GetEstablishmentFromQRCodeUseCase(final IOrderRepository iOrderRepository) {
        this.iOrderRepository = iOrderRepository;
    }

    @Override
    public Single<Establishment> execute(final Long establishmentId) {
        return iOrderRepository.findEstablishment(establishmentId);
    }
}
