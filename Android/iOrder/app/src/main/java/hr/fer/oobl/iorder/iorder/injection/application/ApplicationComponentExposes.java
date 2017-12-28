package hr.fer.oobl.iorder.iorder.injection.application;

import hr.fer.oobl.iorder.iorder.injection.application.modules.ApplicationModule;
import hr.fer.oobl.iorder.iorder.injection.application.modules.ThreadingModule;

public interface ApplicationComponentExposes extends ApplicationModule.Exposes,
//                                                     DataModule.Exposes,
//                                                     DomainModule.Exposes,
//                                                     MappersModule.Exposes,
                                                     ThreadingModule.Exposes
//                                                     UseCaseModule.Exposes
{
}
