package application;

import java.time.ZoneId;
import java.util.ArrayList;
import java.util.Date;
import java.util.UUID;

import Model.CoolParent;
import Model.Gender;
import Model.Human;
import Model.Nerd;
import Model.Parent;
import Model.Semester;
import Model.Student;
import Repository.HumanRepository;
import Services.Randomiser;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.DatePicker;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

public class addHumanController implements IController {
	public TextField firstNameTextField, 
					 lastNameTextField,
					 patrobymicTextField,
					 moneyTextField;
	
	public ComboBox<String> genderComboBox;
	public ComboBox<String> humanTypeComboBox;
	
	public DatePicker birthdayDatePicker;
	
	public Button randomiseButton,
				  cleanButton,
				  submitButton,
				  cancelButton;
	
	public void handleRandomiseButtonPressed() {
		Human human = Randomiser.rndHuman();
		setHumanForAdding(human);
	}
	
	public void setHumanForAdding(Human human) {
		this.firstNameTextField.setText(human.get_firstName());
		this.lastNameTextField.setText(human.get_lastName());
		this.patrobymicTextField.setText(human.get_patronymic());
		this.moneyTextField.setText(human.get_moneyAmount().toString());
		this.genderComboBox.setValue(human.get_gender().toString());
		this.humanTypeComboBox.setValue(human.get_humanType());
		this.birthdayDatePicker.setValue(human.get_birthDate().toInstant().atZone(ZoneId.systemDefault()).toLocalDate());
	}
	
	public void handleCleanButtonClick() {
		this.firstNameTextField.setText("");
		this.lastNameTextField.setText("");
		this.patrobymicTextField.setText("");
		this.moneyTextField.setText("");
	}
	
	public void handleCancelButtonClick()
	{
		Stage stage = (Stage) cancelButton.getScene().getWindow();
	    stage.close();
	}
	
	public void handleSubmitButtonClick() {
		Human human = getHuman();
		HumanRepository repo = new HumanRepository();
		repo.SaveToTextFile(human);
		Stage stage = (Stage) submitButton.getScene().getWindow();
	    stage.close();
	}
	
	private Human getHuman() {
		Human human = null;
		
		String firstName = this.firstNameTextField.getText();
		String lastName = this.lastNameTextField.getText();
		String patronymic = this.patrobymicTextField.getText();
		Double money = Double.parseDouble(this.moneyTextField.getText());
		Gender gender = Gender.valueOf(this.genderComboBox.getValue());
		Date birthday = Date.from(this.birthdayDatePicker.getValue().atStartOfDay(ZoneId.systemDefault()).toInstant());
	
		switch(this.humanTypeComboBox.getValue().toUpperCase()) {
		case "STUDENT":
			human = new Student(
					UUID.randomUUID(),
					firstName,
					lastName,
					patronymic,
					birthday,
					gender,
					money,
					new ArrayList<Semester>());
			break;
		case "PARENT":
			human = new Parent(
					UUID.randomUUID(),
					firstName,
					lastName,
					patronymic,
					birthday,
					gender,
					money);
			break;
		case "NERD":
			human = new Nerd(
					UUID.randomUUID(),
					firstName,
					lastName,
					patronymic,
					birthday,
					gender,
					money,
					new ArrayList<Semester>());
			break;
		case "COOLPARENT":
			human = new CoolParent(
					UUID.randomUUID(),
					firstName,
					lastName,
					patronymic,
					birthday,
					gender,
					money);
			break;
		}
		
		return human;
	}
}

