package application;

import java.util.UUID;

import Model.Human;
import Repository.HumanRepository;
import javafx.stage.Stage;

public class EditHumanController extends addHumanController implements IController{
	private UUID oldHumanId = null; 
	
	@Override
	public void handleSubmitButtonClick() {
		Human human = getHuman();
		human.set_id(oldHumanId);
		HumanRepository repo = new HumanRepository();
		repo.Delete(oldHumanId);
		repo.SaveToTextFile(human);
		Stage stage = (Stage) submitButton.getScene().getWindow();
	    stage.close();
	}

	public UUID getOldHumanId() {
		return oldHumanId;
	}

	public void setOldHumanId(UUID oldHumanId) {
		this.oldHumanId = oldHumanId;
	}
}
