package hr.fer.oobl.iorder.domain.interactor.type;

import rx.Single;

public interface SingleUseCaseWithParameter<P, R> {

    Single<R> execute(P p);
}
