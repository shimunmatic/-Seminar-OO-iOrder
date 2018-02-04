package hr.fer.oobl.iorder.iorder.ui.scanner;

import hr.fer.oobl.iorder.iorder.base.BaseView;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;

public interface ScannerContract {

    interface View extends BaseView {

        void showError(String qrCodeError);
    }

    interface Presenter extends ScopedPresenter {

        void saveBarcode(String displayValue);
    }
}
