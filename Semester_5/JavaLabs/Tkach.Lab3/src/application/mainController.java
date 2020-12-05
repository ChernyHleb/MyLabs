package application;

import java.io.IOException;
import java.util.Date;
import java.util.UUID;

import Model.Gender;
import Model.Human;
import Model.User;
import Model.UserType;
import Repository.HumanRepository;
import Services.LoggerService;
import Services.ProgramSettingsService;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.RadioButton;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.ToggleGroup;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.layout.HBox;
import javafx.stage.Stage;

public class mainController implements IController {
	public ComboBox<String> humanTypeComboBox;
	public Button addHumanButton,
				  editHumanButton,
				  deleteHumanButton,
			      infoHumanButton,
			      resetButton,
			      ExperimentButton;
	
	public TableView<Human> dataTableView;
	public TableColumn<Human, String> humanTypeTableColumn;
	public TableColumn<Human, String> humanNameTableColumn;
	public TableColumn<Human, String> humanLastNameTableColumn;
	public TableColumn<Human, String> humanPatronymicTableColumn;
	public TableColumn<Human, Date> humanBirthdayTableColumn;
	public TableColumn<Human, Gender> humanGenderTableColumn;
	public TableColumn<Human, Double> humanMoneyAmountTableColumn;
	public TableColumn<Human, UUID> uuidTableColumn;
	
	public ObservableList<Human> people;
	private User currentUser;
	
	public HumanRepository humanRepository = new HumanRepository();
	
	public Label userNameLabel,
				 userTypeLabel;
	
	public HBox rootFunctionsHBox;
	
	public ToggleGroup LoggingMode,
					   TestMode;
	
	public RadioButton LoggingOn,
					   LoggingOff,
					   TestsOn,
					   TestsOff;
	
	@FXML
	public void initialize()
	{
		this.ShowPeople();
		if(ProgramSettingsService.getProperties().getProperty("main.logging").equals("1")) {
			LoggingMode.selectToggle(LoggingOn);
		} else {
			LoggingMode.selectToggle(LoggingOff);
		}
		
		if(ProgramSettingsService.getProperties().getProperty("main.tests").equals("1")) {
			ExperimentButton.setVisible(true);
			TestMode.selectToggle(TestsOn);
		} else {
			ExperimentButton.setVisible(false);
			TestMode.selectToggle(TestsOff);
		}
	}
	
	// loading human collection from text file to observableList
	public ObservableList<Human> getHumans(){
		ObservableList<Human> people = FXCollections.observableArrayList();
		people.addAll(humanRepository.LoadAllFromTextFile());
		return people;
	}
	
	public void ShowPeople(){
		ObservableList<Human> list = this.getHumans();
		
		this.humanTypeTableColumn.setCellValueFactory(new PropertyValueFactory<Human, String>("_humanType"));
		this.humanNameTableColumn.setCellValueFactory(new PropertyValueFactory<Human, String>("_firstName"));
		this.humanLastNameTableColumn.setCellValueFactory(new PropertyValueFactory<Human, String>("_lastName"));
		this.humanPatronymicTableColumn.setCellValueFactory(new PropertyValueFactory<Human, String>("_patronymic"));
		this.humanBirthdayTableColumn.setCellValueFactory(new PropertyValueFactory<Human, Date>("_birthDate"));
		this.humanGenderTableColumn.setCellValueFactory(new PropertyValueFactory<Human, Gender>("_gender"));
		this.humanMoneyAmountTableColumn.setCellValueFactory(new PropertyValueFactory<Human, Double>("_moneyAmount"));
		this.uuidTableColumn.setCellValueFactory(new PropertyValueFactory<Human, UUID>("_id"));
		
		this.dataTableView.setItems(list);
	}
	
	public void handleEditButtonPressed() {
		Human selectedHuman = dataTableView.getSelectionModel().getSelectedItem();
		if(selectedHuman == null) {
			System.out.print("no human was selected for edition!");
			return;
		}
		else {
			EditHumanController controller = (EditHumanController)loadWindow("editHumanView.fxml", "Edit Human");
			controller.setHuman(selectedHuman);
			controller.setOldHumanId(selectedHuman.get_id());
		}
	}
	
	public void handleDeleteHumanButtonPressed() {
		Human selectedHuman = dataTableView.getSelectionModel().getSelectedItem();
		if(selectedHuman == null) {
			System.out.print("no human was selected for delete!");
			return;
		}
		else {
			DeleteHumanController controller = (DeleteHumanController)loadWindow("DeleteHumanView.fxml", "Delete Human");
		    controller.humanLabel.setText(
		    	String.format(
		    		"Do you really want to delete %s %s ?", 
		    		selectedHuman.get_firstName(), 
		    		selectedHuman.get_lastName()
		    	)
		    );
		    controller.chosedHuman = selectedHuman;
		}
	}
	
	public void handleAddHumanButtonPressed() {
		loadWindow("addHumanView.fxml", "Add Human");
	}
	
	//загружает окно и возвращает связанный с ним контроллер
	public IController loadWindow(String resource, String title){
		IController controller = null;
		try {
			FXMLLoader loader = new FXMLLoader(getClass().getResource(resource));
			Parent parent = loader.load();
			
			controller = (IController)loader.getController();
			
			Stage stage = new Stage();
			stage.setTitle(title);
			Scene scene = new Scene(parent);
			stage.setScene(scene);
			stage.show();
		} catch(Exception e) {
			e.printStackTrace();
			return null;
		}
		
		return controller;
	}
	
	public void handleResetButtonPressed() {
		this.ShowPeople();
	}
	
	public void handleHumanTypeComboBoxChoose() throws IOException{
		String humanType = humanTypeComboBox.getValue();
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
	
	

	public User getCurrentUser() {
		return currentUser;
	}

	public void setCurrentUser(User currentUser) {
		this.currentUser = currentUser;
		userNameLabel.setText(currentUser.getName());
		userTypeLabel.setText(currentUser.getType().toString());
		if(!currentUser.getType().equals(UserType.ROOT))
			this.rootFunctionsHBox.setVisible(false);
	}
	
	public void handleLoggingOnRadioButtonClick() {
		ProgramSettingsService.getProperties().setProperty("main.logging", "1");
		LoggerService.Enable();
	}
	
	public void handleLoggingOffRadioButtonClick() {
		ProgramSettingsService.getProperties().setProperty("main.logging", "0");
		LoggerService.Disable();
	}
	
	public void handleTestsOnRadioButtonClick() {
		ProgramSettingsService.getProperties().setProperty("main.tests", "1");
		ExperimentButton.setVisible(true);
	}
	
	public void handleTestsOffRadioButtonClick() {
		ProgramSettingsService.getProperties().setProperty("main.tests", "0");
		ExperimentButton.setVisible(false);
	}
	
	public void handleExperimentButtonClick() {
		System.out.println("kek");
	}
}
