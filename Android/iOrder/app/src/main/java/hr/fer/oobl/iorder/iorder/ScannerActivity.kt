package hr.fer.oobl.iorder.iorder

import android.os.Bundle
import android.support.v7.app.AppCompatActivity
import android.util.SparseArray
import com.google.android.gms.vision.barcode.Barcode
import info.androidhive.barcode.BarcodeReader

/**
 * Created by mmihalic on 15.12.2017..
 */
class ScannerActivity : AppCompatActivity(), BarcodeReader.BarcodeReaderListener {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.scanner_layout)
    }

    override fun onBitmapScanned(sparseArray: SparseArray<Barcode>?) {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun onScannedMultiple(barcodes: MutableList<Barcode>?) {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun onCameraPermissionDenied() {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun onScanned(barcode: Barcode?) {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun onScanError(errorMessage: String?) {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }
}