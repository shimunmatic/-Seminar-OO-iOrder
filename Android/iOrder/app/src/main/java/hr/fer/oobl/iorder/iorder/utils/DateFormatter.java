package hr.fer.oobl.iorder.iorder.utils;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class DateFormatter {

    private DateFormat formatter;

    public DateFormatter() {
        formatter = new SimpleDateFormat("dd/MM/yyyy hh:mm");
    }

    public String getCurrentDate() {
        return formatter.format(new Date());
    }
}
