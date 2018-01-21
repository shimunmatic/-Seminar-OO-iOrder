package hr.fer.oobl.iorder.iorder.ui.router;


public interface Router {

    void showSignUp();

    void showMainScreen(String displayValue);

    void showScanner();

    void showHistory(long id, String name);
}
