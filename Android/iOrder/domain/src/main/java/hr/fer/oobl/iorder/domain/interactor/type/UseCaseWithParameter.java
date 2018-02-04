package hr.fer.oobl.iorder.domain.interactor.type;

import rx.Observable;

public interface UseCaseWithParameter<P, R> {

    Observable<R> execute(P parameter);
}
