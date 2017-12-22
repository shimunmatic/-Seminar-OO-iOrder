package hr.fer.oobl.iorder.iorder.base


import hr.fer.oobl.iorder.iorder.injection.fragment.DaggerFragment

abstract class BaseFragment : DaggerFragment(), BaseView {

    abstract val presenter: ScopedPresenter

    override fun onStop() {
        presenter.stop()
        super.onStop()
    }

    override fun onPause() {
        presenter.deactivate()
        super.onPause()
    }
}
