package hr.fer.oobl.iorder.iorder.injection.fragment

import android.os.Bundle
import android.support.v4.app.Fragment

import hr.fer.oobl.iorder.iorder.injection.ComponentFactory
import hr.fer.oobl.iorder.iorder.injection.activity.DaggerActivity

abstract class DaggerFragment : Fragment() {

    private var fragmentComponent: FragmentComponent? = null

    val daggerActivity: DaggerActivity
        get() = (activity as DaggerActivity?)!!

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        inject(getFragmentComponent())
    }

    protected abstract fun inject(fragmentComponent: FragmentComponent)

    fun getFragmentComponent(): FragmentComponent {
        if (fragmentComponent == null) {
            fragmentComponent = ComponentFactory.createFragmentComponent(this, daggerActivity.getActivityComponent())
        }

        return fragmentComponent as FragmentComponent
    }
}
