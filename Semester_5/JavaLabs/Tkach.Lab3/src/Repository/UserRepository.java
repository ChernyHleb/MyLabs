package Repository;

import java.util.ArrayList;
import java.util.UUID;

import Model.User;
import Services.FileIOService;
import Services.LoggerService;

public class UserRepository implements IRepository<User>{
	private String currentDir;
	private String databaseFilePath;
	private String databaseFileName;
	
	public UserRepository() {
		this.databaseFileName = "userDataBase.txt";
		this.currentDir = System.getProperty("user.dir");
		this.databaseFilePath = currentDir + "/src/Repository/" + databaseFileName;
	}
	@Override
	public User LoadFromTextFile(UUID entityId) {
		// TODO Auto-generated method stub
		return null;
	}
	
	public User LoadFromTextFile(String login) {
		LoggerService.WriteToLog(String.format("%s %s", "Read from", databaseFileName));
		ArrayList<User> users = LoadAllFromTextFile();
		for(User user : users) {
			if(user.getName().equals(login))
				return user;
		}
		return null;
	}

	@Override
	public void SaveToTextFile(User entity) {
		LoggerService.WriteToLog(String.format("%s %s", "Write to", databaseFileName));
		FileIOService.WriteToFile(databaseFilePath, entity.ToString(), true);
	}

	@Override
	public void SaveToTextFile(ArrayList<User> entities) {
		LoggerService.WriteToLog(String.format("%s %s", "Write to", databaseFileName));
		ArrayList<String> serializedUsers = new ArrayList<String>();
		for(User entity : entities) {
			serializedUsers.add(entity.ToString());
		}
		FileIOService.WriteToFile(databaseFilePath, serializedUsers, true);
	}

	@Override
	public ArrayList<User> LoadAllFromTextFile() {
		LoggerService.WriteToLog(String.format("%s %s", "Read from", databaseFileName));
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
