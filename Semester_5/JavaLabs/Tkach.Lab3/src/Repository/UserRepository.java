package Repository;

import java.net.URL;
import java.util.ArrayList;
import java.util.UUID;

import Model.CoolParent;
import Model.Human;
import Model.Nerd;
import Model.Parent;
import Model.Student;
import Model.User;
import Services.FileIOService;

public class UserRepository implements IRepository<User>{

	@Override
	public User LoadFromTextFile(UUID entityId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void SaveToTextFile(User entity) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void SaveToTextFile(ArrayList<User> entities) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public ArrayList<User> LoadAllFromTextFile() {
		return null;
	}

	@Override
	public void Delete(UUID entityId) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void DeleteAll() {
		// TODO Auto-generated method stub
		
	}

}
