package hr.fer.oobl.iorder.iorder.injection.activity;

import hr.fer.oobl.iorder.iorder.ui.history.HistoryActivity;
import hr.fer.oobl.iorder.iorder.ui.history.HistoryPresenter;
import hr.fer.oobl.iorder.iorder.ui.login.LoginActivity;
import hr.fer.oobl.iorder.iorder.ui.login.LoginPresenter;
import hr.fer.oobl.iorder.iorder.ui.main.MainActivity;
import hr.fer.oobl.iorder.iorder.ui.main.MainPresenter;
import hr.fer.oobl.iorder.iorder.ui.scanner.ScannerActivity;
import hr.fer.oobl.iorder.iorder.ui.signup.SignUpActivity;
import hr.fer.oobl.iorder.iorder.ui.signup.SignupPresenter;

public interface ActivityComponentInjects {

    void inject(LoginActivity loginActivity);

    void inject(LoginPresenter loginPresenter);

    void inject(SignUpActivity signupFragment);

    void inject(SignupPresenter presenter);

    void inject(MainActivity mainActivity);

    void inject(MainPresenter mainPresenter);

    void inject(ScannerActivity scannerActivity);
    
    void inject(HistoryActivity historyActivity);

    void inject(HistoryPresenter presenter);
}
