package hr.fer.oobl.iorder.domain.interactor.type;

import rx.Single;

public interface SingleUseCase<T> {

    Single<T> execute();
}
