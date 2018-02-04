package hr.fer.oobl.iorder.domain.interactor.login;

import hr.fer.oobl.iorder.domain.interactor.type.SingleUseCaseWithParameter;
import hr.fer.oobl.iorder.domain.model.UserCredentials;
import hr.fer.oobl.iorder.domain.repository.IOrderRepository;
import rx.Single;

public final class GetLoginTokenUseCase implements SingleUseCaseWithParameter<UserCredentials, String> {

    private IOrderRepository iOrderRepository;

    public GetLoginTokenUseCase(final IOrderRepository iOrderRepository) {
        this.iOrderRepository = iOrderRepository;
    }

    @Override
    public Single<String> execute(final UserCredentials userCredentials) {
       return iOrderRepository.fetchAuthToken(userCredentials);
    }
}
