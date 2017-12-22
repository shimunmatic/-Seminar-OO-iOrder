package hr.fer.oobl.iorder.iorder.ui.scanner

import android.content.Intent
import android.os.Bundle
import android.support.v7.app.AppCompatActivity
import android.util.SparseArray
import android.widget.Toast
import com.google.android.gms.vision.barcode.Barcode
import hr.fer.oobl.iorder.iorder.R
import hr.fer.oobl.iorder.iorder.ui.main.MainActivity
import info.androidhive.barcode.BarcodeReader

/**
 * Created by mmihalic on 15.12.2017..
 */
class ScannerActivity : AppCompatActivity(), BarcodeReader.BarcodeReaderListener {

    private var barcodeReader: BarcodeReader? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.scanner_layout)

        barcodeReader = supportFragmentManager.findFragmentById(R.id.barcode_scanner) as BarcodeReader?
    }

    override fun onBitmapScanned(sparseArray: SparseArray<Barcode>?) {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun onScannedMultiple(barcodes: MutableList<Barcode>?) {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun onCameraPermissionDenied() {
        finish()
    }

    override fun onScanned(barcode: Barcode?) {
        barcodeReader?.playBeep()

        // ticket details activity by passing barcode
        val intent = Intent(this@ScannerActivity, MainActivity::class.java)
        intent.putExtra("code", barcode?.displayValue)
        startActivity(intent)
    }

    override fun onScanError(errorMessage: String?) {
        Toast.makeText(applicationContext, "Error occurred while scanning " + errorMessage, Toast.LENGTH_SHORT).show()
    }
}