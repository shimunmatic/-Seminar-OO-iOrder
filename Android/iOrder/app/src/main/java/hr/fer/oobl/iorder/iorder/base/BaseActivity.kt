package hr.fer.oobl.iorder.iorder.base


import hr.fer.oobl.iorder.iorder.injection.activity.DaggerActivity

abstract class BaseActivity : DaggerActivity(), BaseView {

    abstract val presenter: ScopedPresenter

    public override fun onStop() {
        presenter.stop()
        super.onStop()
    }

    public override fun onPause() {
        presenter.deactivate()
        super.onPause()
    }
}
