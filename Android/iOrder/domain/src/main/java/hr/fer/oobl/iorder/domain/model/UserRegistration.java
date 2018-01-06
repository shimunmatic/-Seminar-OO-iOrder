package hr.fer.oobl.iorder.domain.model;

public final class UserRegistration {

    private final String username;
    private final String firstName;
    private final String surname;
    private final String email;
    private final String password;

    public String getUsername() {
        return username;
    }

    public String getFirstName() {
        return firstName;
    }

    public String getSurname() {
        return surname;
    }

    public String getEmail() {
        return email;
    }

    public String getPassword() {
        return password;
    }

    public UserRegistration(final String username, final String firstName, final String surname, final String email, final String password) {

        this.username = username;
        this.firstName = firstName;
        this.surname = surname;
        this.email = email;
        this.password = password;
    }
}
