package hr.fer.oobl.iorder.iorder.ui.scanner;

import android.os.Bundle;
import android.util.SparseArray;
import android.widget.Toast;

import com.google.android.gms.vision.barcode.Barcode;

import java.util.List;

import javax.inject.Inject;

import hr.fer.oobl.iorder.iorder.R;
import hr.fer.oobl.iorder.iorder.base.BaseActivity;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;
import hr.fer.oobl.iorder.iorder.injection.activity.ActivityComponent;
import hr.fer.oobl.iorder.iorder.ui.router.Router;
import info.androidhive.barcode.BarcodeReader;

public class ScannerActivity extends BaseActivity implements BarcodeReader.BarcodeReaderListener, ScannerContract.View {

    @Inject
    Router router;

    @Inject
    ScannerContract.Presenter presenter;

    BarcodeReader barcodeReader;

    @Override
    public ScopedPresenter getPresenter() {
        return presenter;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.scanner_layout);

        barcodeReader = (BarcodeReader) getSupportFragmentManager().findFragmentById(R.id.barcode_scanner);
    }

    @Override
    protected void inject(final ActivityComponent activityComponent) {
        activityComponent.inject(this);
    }

    @Override
    public void onScanned(Barcode barcode) {
        barcodeReader.playBeep();
        router.showMainScreen(barcode.displayValue);
    }

    @Override
    public void onScannedMultiple(List<Barcode> list) {

    }

    @Override
    public void onBitmapScanned(SparseArray<Barcode> sparseArray) {

    }

    @Override
    public void onCameraPermissionDenied() {
        finish();
    }

    @Override
    public void onScanError(String s) {
        Toast.makeText(getApplicationContext(), "Error occurred while scanning " + s, Toast.LENGTH_SHORT).show();
    }
}
