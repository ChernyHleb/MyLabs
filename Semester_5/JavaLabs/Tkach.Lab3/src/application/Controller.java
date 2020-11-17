package application;

import java.io.IOException;
import java.util.ArrayList;

import Repository.StudentRepository;
import javafx.fxml.FXMLLoader;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.TextArea;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.VBox;
import Model.Student;

public class Controller implements IController{
	public Button insertButton;
	public TextArea mainTextArea;
	public ComboBox<String> humanTypeComboBox;
	public GridPane insertHumanGridPane;
	
	public IController humanIOController;
	
	public StudentRepository studentRepo = new StudentRepository();
	
	public void handleRefreshButtonClick() {
		ArrayList<Student> students = studentRepo.LoadAllFromTextFile("humanDataBase.txt");
		String text = "";
		for(Student student:students) {
			text += student.SerializeToString() + "\n";
		}
		mainTextArea.setText(text);
	}
	
	public void handleHumanTypeComboBoxChoose() throws IOException{
		this.switchHumanType(humanTypeComboBox.getValue());
	}
	
	private void switchHumanType(String humanType) throws IOException{
		/*GridPane newGridPane = null;
		
		switch(humanType) {
		case("Nerd"):
		case("Student"):
			newGridPane = FXMLLoader.load(getClass().getResource("insertStudent.fxml"));
			humanIOController = new insertStudentController();
			break;
		case("CoolParent"):
		case("Parent"):
			newGridPane = FXMLLoader.load(getClass().getResource("insertParent.fxml"));
			humanIOController = new insertStudentController();
			break;
		}
		
		insertHumanGridPane.getChildren().setAll(newGridPane);*/
	}
}
