package hr.fer.oobl.iorder.data.util;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;
import java.util.concurrent.TimeUnit;

public final class DateUtils {

    private static final String DATE_FORMAT_INPUT = "yyyy-MM-dd'T'HH:mm:ss";
    private static final String DATE_FORMAT_OUTPUT = "MMMM dd, yyyy HH:mm aaa";

    private static final String HOURS_AGO = " hours, ";
    private static final String MINUTES_AGO = " minutes ago";
    private static final String SECONDS_AGO = " seconds ago";

    private static final long DAY = 24L;
    private static final long ZERO = 0L;
    private static final long MINUTES = 60L;

    public static String parseDate(final String publishDate) {
        final SimpleDateFormat simpleDateFormat = new SimpleDateFormat(DATE_FORMAT_INPUT, Locale.US);
        Date date = null;
        try {
            date = simpleDateFormat.parse(publishDate);
        } catch (final ParseException e) {
            e.printStackTrace();
        }

        long seconds;
        long minutes;
        long hours;
        if (date != null) {
            final long time = date.getTime();
            final long currentTime = new Date().getTime();
            final long diff = currentTime - time;

            seconds = TimeUnit.MILLISECONDS.toSeconds(diff);
            minutes = TimeUnit.MILLISECONDS.toMinutes(diff);
            hours = TimeUnit.MILLISECONDS.toHours(diff);

            return formatTime(hours, minutes, seconds, date);

        }
        return Constants.EMPTY_STRING;
    }

    private static String formatTime(final long hours, final long minutes, final long seconds, final Date date) {
        final SimpleDateFormat output = new SimpleDateFormat(DATE_FORMAT_OUTPUT, Locale.US);
        String formattedTime;
        if (hours >= DAY) {
            formattedTime = output.format(date);
        } else if (hours != ZERO) {
            if(minutes != ZERO) {
                formattedTime = String.valueOf(hours) + HOURS_AGO +
                        String.valueOf(minutes - hours * MINUTES) + MINUTES_AGO;
            } else {
                formattedTime = String.valueOf(hours) + HOURS_AGO;
            }
        } else {
            if (minutes != ZERO) {
                formattedTime = String.valueOf(minutes) + MINUTES_AGO;
            } else {
                formattedTime = String.valueOf(seconds) + SECONDS_AGO;
            }
        }
        return formattedTime;
    }
}
