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
	public User LoadFromTextFile(UUID entityId, String FileName) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void SaveToTextFile(User entity, String FileName) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void SaveToTextFile(ArrayList<User> entities, String FileName) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public ArrayList<User> LoadAllFromTextFile(String FileName) {
		URL url = getClass().getResource(FileName);
		String path = url.getPath();
		
		ArrayList<User> users = new ArrayList<User>();
		ArrayList<String> fileData = FileIOService.ReadFromFile(path);
		
		try {
			for(String str : fileData) {
				users.add(new User(str));
			}
		} 
		catch(Exception e) {
			
		}
		return users;
	}

	@Override
	public void Delete(UUID entityId, String FileName) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void DeleteAll(String FileName) {
		// TODO Auto-generated method stub
		
	}

}
