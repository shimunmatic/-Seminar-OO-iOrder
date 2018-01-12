package hr.fer.oobl.iorder.iorder.injection.application;

import hr.fer.oobl.iorder.iorder.injection.application.modules.ApplicationModule;
import hr.fer.oobl.iorder.iorder.injection.application.modules.DataModule;
import hr.fer.oobl.iorder.iorder.injection.application.modules.DomainModule;
import hr.fer.oobl.iorder.iorder.injection.application.modules.MappersModule;
import hr.fer.oobl.iorder.iorder.injection.application.modules.ThreadingModule;
import hr.fer.oobl.iorder.iorder.injection.application.modules.UseCaseModule;

public interface ApplicationComponentExposes extends ApplicationModule.Exposes,
        DataModule.Exposes,
        DomainModule.Exposes,
        MappersModule.Exposes,
        ThreadingModule.Exposes,
        UseCaseModule.Exposes {
}
