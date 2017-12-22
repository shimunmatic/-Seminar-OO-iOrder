package hr.fer.oobl.iorder.iorder.injection.application

import hr.fer.oobl.iorder.iorder.application.IOrderApplication

interface ApplicationComponentInjects {

    fun inject(application: IOrderApplication)
}
