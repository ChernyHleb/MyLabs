package application;

import java.io.IOException;

import javafx.fxml.FXMLLoader;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.TextArea;
import javafx.scene.layout.VBox;

public class Controller {
	public Button insertButton;
	public TextArea mainTextArea;
	public ComboBox<String> humanTypeComboBox;
	public VBox insertHumanViewVBox;
	
	public void handleInsertButtonClick() {
		System.out.println("insert Button Clicked");
		mainTextArea.setText(mainTextArea.getText() + " CLICK!");
	}
	
	public void handleHumanTypeComboBoxChoose() throws IOException{
		this.switchHumanType(humanTypeComboBox.getValue());
	}
	
	private void switchHumanType(String humanType) throws IOException{
		VBox newVBox = null;
		
		switch(humanType) {
		case("Student"):
			newVBox = FXMLLoader.load(getClass().getResource("insertStudent.fxml"));
			break;
		case("Parent"):
			newVBox = FXMLLoader.load(getClass().getResource("insertParent.fxml"));
			break;
		case("Nerd"):
			break;
		case("CoolParent"):
			break;
		}
		
		insertHumanViewVBox.getChildren().setAll(newVBox);
	}
}
