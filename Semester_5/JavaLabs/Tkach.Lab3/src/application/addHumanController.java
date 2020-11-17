package application;

import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.DatePicker;
import javafx.scene.control.TextField;

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
				  addHumanButton,
				  cancelButton;
	
}

