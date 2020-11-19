package application;

import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

public class LoginController implements IController{
	public Button logInButton;
	public Button signUpButton;
	public TextField loginTextField;
	public PasswordField passwordField;
	
	public void handleLogInButtonClick() {
		
	}
	
	public void handleSignUpButtonClick() {
		try {
			FXMLLoader loader = new FXMLLoader(getClass().getResource("signUpView.fxml"));
			Parent parent = loader.load();
			
			Stage stage = new Stage();
			stage.setTitle("SignUp");
			Scene scene = new Scene(parent);
			stage.setScene(scene);
			stage.show();
		} catch(Exception e) {
			e.printStackTrace();
		}
	}
}
