package hr.fer.oobl.iorder.iorder.injection.activity.modules;

import dagger.Module;
import dagger.Provides;
import hr.fer.oobl.iorder.iorder.injection.activity.ActivityScope;
import hr.fer.oobl.iorder.iorder.injection.activity.DaggerActivity;
import hr.fer.oobl.iorder.iorder.ui.login.LoginContract;
import hr.fer.oobl.iorder.iorder.ui.login.LoginPresenter;
import hr.fer.oobl.iorder.iorder.ui.signup.SignupContract;
import hr.fer.oobl.iorder.iorder.ui.signup.SignupPresenter;

@Module
public final class ActivityPresenterModule {

    private final DaggerActivity daggerActivity;

    public ActivityPresenterModule(final DaggerActivity daggerActivity) {
        this.daggerActivity = daggerActivity;
    }

    @Provides
    @ActivityScope
    LoginContract.Presenter provideLoginPresenter() {
        final LoginPresenter presenter = new LoginPresenter((LoginContract.View) daggerActivity);
        daggerActivity.getActivityComponent().inject(presenter);
        return presenter;
    }

    @Provides
    @ActivityScope
    SignupContract.Presenter provideSignUpPresenter() {
        final SignupPresenter presenter = new SignupPresenter((SignupContract.View) daggerActivity);
        daggerActivity.getActivityComponent().inject(presenter);
        return presenter;
    }
//
//    @Provides
//    @ActivityScope
//    NewsContract.Presenter provideNewsPresenter() {
//        final HomePresenter presenter = new HomePresenter((NewsContract.View) daggerActivity);
//        daggerActivity.getActivityComponent().inject(presenter);
//        return presenter;
//    }
//
//    @Provides
//    @ActivityScope
//    LoginContract.Presenter provideLoginPresenter() {
//        LoginPresenter presenter = new LoginPresenter((LoginContract.View) daggerActivity);
//        daggerActivity.getActivityComponent().inject(presenter);
//        return presenter;
//    }
}
