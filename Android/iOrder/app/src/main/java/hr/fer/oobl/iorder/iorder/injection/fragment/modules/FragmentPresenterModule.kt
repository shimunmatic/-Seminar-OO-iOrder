package hr.fer.oobl.iorder.iorder.injection.fragment.modules

import dagger.Module
import hr.fer.oobl.iorder.iorder.injection.fragment.DaggerFragment

@Module
class FragmentPresenterModule(fragment: DaggerFragment)//    private final DaggerFragment daggerFragment;
//
//    public FragmentPresenterModule(final DaggerFragment daggerFragment) {this.daggerFragment = daggerFragment;}
//
//    @Provides
//    @FragmentScope
//    LoginContract.Presenter provideLoginPresenter() {
//        final LoginPresenter presenter = new LoginPresenter((LoginContract.View) daggerFragment);
//        daggerFragment.getFragmentComponent().inject(presenter);
//        return presenter;
//    }
//    @Provides
//    @FragmentScope
//    CategoryContract.Presenter provideCategoryFragment() {
//        final CategoryPresenter presenter = new CategoryPresenter((CategoryContract.View) daggerFragment);
//        daggerFragment.getFragmentComponent().inject(presenter);
//        return presenter;
//    }
//
//    @Provides
//    @FragmentScope
//    DetailsContract.Presenter provideDetailsPresenter() {
//        final DetailsPresenter presenter = new DetailsPresenter((DetailsContract.View) daggerFragment);
//        daggerFragment.getFragmentComponent().inject(presenter);
//        return presenter;
//    }
