package hr.fer.oobl.iorder.domain.interactor.type;

import rx.Completable;

public interface CompletableUseCase {

    Completable execute();
}
