package application;

import java.time.ZoneId;

import Model.Human;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.DatePicker;
import javafx.scene.control.TextField;

public class EditHumanController implements IController{
	public TextField firstNameTextField, 
	 lastNameTextField,
	 patrobymicTextField,
	 moneyTextField;

	public ComboBox<String> genderComboBox;
	public ComboBox<String> humanTypeComboBox;
	
	public DatePicker birthdayDatePicker;
	
	public Button randomiseButton,
	 cleanButton,
	 addHumanButton,
	 cancelButton;
	
	public void setHumanForEditing(Human human) {
		this.firstNameTextField.setText(human.get_firstName());
		this.lastNameTextField.setText(human.get_lastName());
		this.patrobymicTextField.setText(human.get_patronymic());
		this.moneyTextField.setText(human.get_moneyAmount().toString());
		this.genderComboBox.setValue(human.get_gender().toString());
		this.humanTypeComboBox.setValue(human.get_humanType());
		this.birthdayDatePicker.setValue(human.get_birthDate().toInstant().atZone(ZoneId.systemDefault()).toLocalDate());
	}
}
