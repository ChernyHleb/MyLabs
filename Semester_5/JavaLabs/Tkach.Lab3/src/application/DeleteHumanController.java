package application;

import Model.Human;
import Repository.HumanRepository;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.stage.Stage;

public class DeleteHumanController implements IController{
	public Label humanLabel;
	public Button submitButton,
		          cancelButton;
	public Human chosedHuman;
	
	public void handleSubmitButtonClick()
	{
		new HumanRepository().Delete(chosedHuman.get_id());
		Stage stage = (Stage) submitButton.getScene().getWindow();
	    stage.close();
	}
	
	public void handleCancelButtonClick()
	{
		Stage stage = (Stage) submitButton.getScene().getWindow();
	    stage.close();
	}
}
