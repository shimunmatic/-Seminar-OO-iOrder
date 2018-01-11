package hr.fer.oobl.iorder.domain.interactor.type;

import rx.Observable;

public interface UseCase<T> {

    Observable<T> execute();
}
