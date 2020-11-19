package Repository;

import java.util.ArrayList;
import java.util.UUID;

import Model.CoolParent;
import Model.Human;
import Model.Nerd;
import Model.Student;
import Model.Parent;
import Services.FileIOService;
import Services.LoggerService;

public class HumanRepository implements IRepository<Human>{
	private String currentDir;
	private String databaseFilePath;
	private String databaseFileName;
	
	public HumanRepository() {
		this.databaseFileName = "humanDataBase.txt";
		this.currentDir = System.getProperty("user.dir");
		this.databaseFilePath = currentDir + "/src/Repository/" + this.databaseFileName;
	}

	@Override
	public Human LoadFromTextFile(UUID entityId) {
		// TODO Auto-generated method 
		return null;
	}

	@Override
	public void SaveToTextFile(Human entity) {
		LoggerService.WriteToLog(String.format("%s %s", "Write to", databaseFileName));
		FileIOService.WriteToFile(databaseFilePath, entity.SerializeToString(), true);	
	}

	@Override
	public void SaveToTextFile(ArrayList<Human> entities) {
		LoggerService.WriteToLog(String.format("%s %s", "Write to", databaseFileName));
		ArrayList<String> serializedHumans = new ArrayList<String>();
		for(Human entity : entities) {
			serializedHumans.add(entity.SerializeToString());
		}
		FileIOService.WriteToFile(databaseFilePath, serializedHumans, true);
	}

	@Override
	public ArrayList<Human> LoadAllFromTextFile() {
		LoggerService.WriteToLog(String.format("%s %s", "Read from", databaseFileName));
		ArrayList<Human> people = new ArrayList<Human>();
		ArrayList<String> fileData = FileIOService.ReadFromFile(databaseFilePath);
		
		try {
			for(String str : fileData) {
				switch(str.split(" ")[0]) {
				case("STUDENT"):
					people.add(new Student(str));
					break;
				case("NERD"):
					people.add(new Nerd(str));
					break;
				case("PARENT"):
					people.add(new Parent(str));
					break;
				case("COOLPARENT"):
					people.add(new CoolParent(str));
					break;
				}
			}
		} 
		catch(Exception e) {
			
		}
		
		return people;
	}

	@Override
	public void Delete(UUID entityId) {
		LoggerService.WriteToLog(String.format("%s %s", "Deleting from", databaseFileName));
		ArrayList<Human> people = LoadAllFromTextFile();
		for(int i = 0; i < people.size(); i++) {
			if(people.get(i).get_id().equals(entityId)) {
				people.remove(i);
				break;
			}
		}
		DeleteAll();
		SaveToTextFile(people);
	}

	@Override
	public void DeleteAll() {
		LoggerService.WriteToLog(String.format("%s %s", "Deleting all data from", databaseFileName));
		FileIOService.WriteToFile(databaseFilePath, "", false);
	}

}
