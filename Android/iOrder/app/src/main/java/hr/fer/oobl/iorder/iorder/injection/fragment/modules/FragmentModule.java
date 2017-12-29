package hr.fer.oobl.iorder.iorder.injection.fragment.modules;

import android.content.Context;

import dagger.Module;
import dagger.Provides;
import hr.fer.oobl.iorder.iorder.injection.fragment.DaggerFragment;
import hr.fer.oobl.iorder.iorder.injection.fragment.FragmentScope;
import hr.fer.oobl.iorder.iorder.ui.dashboard.DashboardFragment;

@Module
public final class FragmentModule {

    private final DaggerFragment fragment;

    public FragmentModule(final DaggerFragment fragment) {
        this.fragment = fragment;
    }

//    @Provides
//    @FragmentScope
//    ImageLoader provideImageLoader(final Context context) {
//        return new GlideImageLoader(context);
//    }

    @Provides
    @FragmentScope
    Context provideFragmentContext() {
        return fragment.getContext();
    }
}
