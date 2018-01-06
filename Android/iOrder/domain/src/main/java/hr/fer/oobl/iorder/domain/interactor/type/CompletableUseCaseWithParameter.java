package hr.fer.oobl.iorder.domain.interactor.type;

import rx.Completable;

public interface CompletableUseCaseWithParameter<P> {

    Completable execute(P parameter);
}
