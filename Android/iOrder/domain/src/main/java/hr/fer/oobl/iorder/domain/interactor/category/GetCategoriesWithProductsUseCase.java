package hr.fer.oobl.iorder.domain.interactor.category;

import java.util.List;

import hr.fer.oobl.iorder.domain.interactor.type.SingleUseCaseWithParameter;
import hr.fer.oobl.iorder.domain.model.Category;
import hr.fer.oobl.iorder.domain.repository.IOrderRepository;
import rx.Single;

public final class GetCategoriesWithProductsUseCase implements SingleUseCaseWithParameter<Long, List<Category>> {

    private IOrderRepository iOrderRepository;

    public GetCategoriesWithProductsUseCase(final IOrderRepository iOrderRepository) {
        this.iOrderRepository = iOrderRepository;
    }

    @Override
    public Single<List<Category>> execute(final Long establishmentId) {
        return iOrderRepository.fetchCategories(establishmentId);
    }
}
