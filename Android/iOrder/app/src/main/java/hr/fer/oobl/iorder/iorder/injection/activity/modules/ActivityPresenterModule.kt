package hr.fer.oobl.iorder.iorder.injection.activity.modules

import dagger.Module
import dagger.Provides
import hr.fer.oobl.iorder.iorder.injection.activity.DaggerActivity

@Module
class ActivityPresenterModule(private val daggerActivity: DaggerActivity)//
//    @Provides
//    @ActivityScope
//    NewsContract.Presenter provideNewsPresenter() {
//        final HomePresenter presenter = new HomePresenter((NewsContract.View) daggerActivity);
//        daggerActivity.getActivityComponent().inject(presenter);
//        return presenter;
//    }
