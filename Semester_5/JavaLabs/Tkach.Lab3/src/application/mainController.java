package application;

import java.io.IOException;
import java.util.Date;

import Model.Gender;
import Model.Human;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXMLLoader;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;

public class mainController implements IController {
	public ComboBox<String> humanTypeComboBox;
	public Button addHumanButton;
	public Button editHumanButton;
	public Button deleteHumanButton;
	public Button infoHumanButton;
	
	public TableView<Human> dataTableView;
	public TableColumn<Human, String> humanTypeTableColumn;
	public TableColumn<Human, String> humanNameTableColumn;
	public TableColumn<Human, String> humanLastNameTableColumn;
	public TableColumn<Human, String> humanPatronymicTableColumn;
	public TableColumn<Human, Date> humanBirthdayTableColumn;
	public TableColumn<Human, Gender> humanGenderTableColumn;
	public TableColumn<Human, Double> humanMoneyAmountTableColumn;
	
	public ObservableList<Human> people;
	
	public ObservableList<Human> getHumans(){
		ObservableList<Human> people = FXCollections.observableArrayList();
		
		return people;
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
		
		insertHumanGridPane.getChildren().setAll(newGridPane);
		*/
	}
}
