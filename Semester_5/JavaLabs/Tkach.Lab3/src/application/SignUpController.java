package application;

import Model.User;
import Model.UserType;
import Repository.UserRepository;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

public class SignUpController implements IController{
	public Button SignUpButton;
	public TextField loginTextField;
	public PasswordField passwordField;
	public ComboBox<String> userTypeComboBox;
	
	public void handleSignUpButtonClick() {
		UserRepository repo = new UserRepository();
		repo.SaveToTextFile(this.getUser());
		
		Stage stage = (Stage)this.SignUpButton.getScene().getWindow();
		stage.close();
	}
	
	protected User getUser() {
		User user = null;
		String login = this.loginTextField.getText();
		String password = this.passwordField.getText();
		UserType type = UserType.valueOf(this.userTypeComboBox.getValue());
		
		user = new User(login, password, type);
		return user;
	}
}
