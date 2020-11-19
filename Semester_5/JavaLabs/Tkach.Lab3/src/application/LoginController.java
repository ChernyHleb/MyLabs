package application;

import Services.Validator;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

public class LoginController implements IController{
	public Button logInButton;
	public Button signUpButton;
	public TextField loginTextField;
	public PasswordField passwordField;
	public Label alertLabel;
	
	public void handleLogInButtonClick() {
		if(Validator.LogInValidation(loginTextField.getText(), passwordField.getText())) {
			this.loadMainWindow();
			Stage stage = (Stage) logInButton.getScene().getWindow();
		    stage.close();
		}
		else {
			alertLabel.setText("incorrect login or password!");
		}
	}
	
	protected void loadMainWindow( ) {
		try {
			FXMLLoader loader = new FXMLLoader(getClass().getResource("mainView.fxml"));
			Parent parent = loader.load();
			
			Stage stage = new Stage();
			stage.setTitle("Lab 3");
			Scene scene = new Scene(parent);
			stage.setScene(scene);
			stage.show();
		} catch(Exception e) {
			e.printStackTrace();
		}
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
