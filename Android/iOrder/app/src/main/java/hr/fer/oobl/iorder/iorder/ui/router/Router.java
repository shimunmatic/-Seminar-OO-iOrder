package hr.fer.oobl.iorder.iorder.ui.router;


public interface Router {

    void showSignUp();

    void showMainScreen();

    void showScanner();

    void showHistory(long id, String name);
}
