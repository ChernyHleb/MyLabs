package Repository;

import java.util.ArrayList;
import java.util.UUID;

import Model.CoolParent;
import Model.Human;
import Model.Nerd;
import Model.Student;
import Model.Parent;
import Services.FileIOService;

public class HumanRepository implements IRepository<Human>{
	private String currentDir;
	private String databaseFilePath;
	
	public HumanRepository() {
		this.currentDir = System.getProperty("user.dir");
		this.databaseFilePath = currentDir + "/src/Repository/humanDataBase.txt";
	}

	@Override
	public Human LoadFromTextFile(UUID entityId) {
		// TODO Auto-generated method 
		return null;
	}

	@Override
	public void SaveToTextFile(Human entity) {
		FileIOService.WriteToFile(databaseFilePath, entity.SerializeToString(), true);	
	}

	@Override
	public void SaveToTextFile(ArrayList<Human> entities) {
		ArrayList<String> serializedHumans = new ArrayList<String>();
		for(Human entity : entities) {
			serializedHumans.add(entity.SerializeToString());
		}
		FileIOService.WriteToFile(databaseFilePath, serializedHumans, true);
	}

	@Override
	public ArrayList<Human> LoadAllFromTextFile() {
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
		FileIOService.WriteToFile(databaseFilePath, "", false);
	}

}
