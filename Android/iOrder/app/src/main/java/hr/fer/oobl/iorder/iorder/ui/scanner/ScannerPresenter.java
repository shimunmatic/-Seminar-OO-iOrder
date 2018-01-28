package hr.fer.oobl.iorder.iorder.ui.scanner;

import javax.inject.Inject;

import hr.fer.oobl.iorder.data.util.SharedPrefsManager;
import hr.fer.oobl.iorder.iorder.base.BasePresenter;
import hr.fer.oobl.iorder.iorder.ui.router.Router;

public class ScannerPresenter extends BasePresenter<ScannerContract.View> implements ScannerContract.Presenter {

    @Inject
    SharedPrefsManager sharedPrefsManager;

    @Inject
    Router router;

    private static final String QR_CODE_ERROR = "QR code has invalid types of data.";

    public ScannerPresenter(final ScannerContract.View view) {
        super(view);
    }

    @Override
    public void saveBarcode(final String code) {
        if (code != null && !code.isEmpty()) {
            final String[] parameters = code.split("&");

            try {
                final String establishmentId = parameters[0].split("=")[1];
                final String locationId = parameters[1].split("=")[1];

                sharedPrefsManager.set("establishmentId", establishmentId);
                sharedPrefsManager.set("locationId", locationId);
                router.showMainScreen();
            } catch (NumberFormatException ne) {
                doIfViewNotNull(view -> view.showError(QR_CODE_ERROR));
            }
        } else {
            doIfViewNotNull(view -> view.showError(QR_CODE_ERROR));
        }
    }
}
