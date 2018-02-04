package hr.fer.oobl.iorder.domain.interactor.signup;

import hr.fer.oobl.iorder.domain.interactor.type.SingleUseCaseWithParameter;
import hr.fer.oobl.iorder.domain.model.UserRegistration;
import hr.fer.oobl.iorder.domain.repository.IOrderRepository;
import rx.Single;

public final class SignUpRequestUseCase implements SingleUseCaseWithParameter<UserRegistration, Void> {

    private IOrderRepository iOrderRepository;

    public SignUpRequestUseCase(final IOrderRepository iOrderRepository) {
        this.iOrderRepository = iOrderRepository;
    }

    @Override
    public Single<Void> execute(final UserRegistration userRegistration) {
        return iOrderRepository.requestRegistration(userRegistration);
    }
}
