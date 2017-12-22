package hr.fer.oobl.iorder.iorder.injection.fragment.modules

import android.content.Context

import dagger.Module
import dagger.Provides
import hr.fer.oobl.iorder.iorder.injection.fragment.DaggerFragment
import hr.fer.oobl.iorder.iorder.injection.fragment.FragmentScope

@Module
class FragmentModule(private val fragment: DaggerFragment) {
}
//
//    @Provides
//    @FragmentScope
//    ImageLoader provideImageLoader(final Context context) {
//        return new GlideImageLoader(context);
//    }
//
//    @Provides
//    @FragmentScope
//    Context provideFragmentContext() {
//        return fragment.getContext();
//    }
