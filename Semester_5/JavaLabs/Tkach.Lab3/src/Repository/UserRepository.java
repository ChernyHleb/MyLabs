package Repository;

import java.util.ArrayList;
import java.util.UUID;

import Model.User;
import Services.FileIOService;

public class UserRepository implements IRepository<User>{
	private String currentDir;
	private String databaseFilePath;
	
	public UserRepository() {
		this.currentDir = System.getProperty("user.dir");
		this.databaseFilePath = currentDir + "/src/Repository/userDataBase.txt";
	}
	@Override
	public User LoadFromTextFile(UUID entityId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void SaveToTextFile(User entity) {
		FileIOService.WriteToFile(databaseFilePath, entity.ToString(), true);
	}

	@Override
	public void SaveToTextFile(ArrayList<User> entities) {
		// TODO Auto-generated method stub
		ArrayList<String> serializedUsers = new ArrayList<String>();
		for(User entity : entities) {
			serializedUsers.add(entity.ToString());
		}
		FileIOService.WriteToFile(databaseFilePath, serializedUsers, true);
	}

	@Override
	public ArrayList<User> LoadAllFromTextFile() {
		ArrayList<User> users = new ArrayList<User>();
		ArrayList<String> fileData = FileIOService.ReadFromFile(databaseFilePath);
		
		for(String str : fileData) {
			users.add(new User(str));
		}
		
		return users;
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
