package Repository;

import java.net.URL;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.UUID;

import Model.CoolParent;
import Model.Human;
import Model.Nerd;
import Model.Student;
import Model.Parent;
import Services.FileIOService;

public class HumanRepository implements IRepository<Human>{

	@Override
	public Human LoadFromTextFile(UUID entityId, String FileName) {
		// TODO Auto-generated method 
		return null;
	}

	@Override
	public void SaveToTextFile(Human entity, String FileName) {
		URL url = getClass().getResource(FileName);
		String path = url.getPath();
		FileIOService.WriteToFile(path, entity.SerializeToString(), true);	
	}

	@Override
	public void SaveToTextFile(ArrayList<Human> entities, String FileName) {
		URL url = getClass().getResource(FileName);
		String path = url.getPath();
		
		ArrayList<String> serializedHumans = new ArrayList<String>();
		for(Human entity : entities) {
			serializedHumans.add(entity.SerializeToString());
		}
		FileIOService.WriteToFile(path, serializedHumans, true);
	}

	@Override
	public ArrayList<Human> LoadAllFromTextFile(String FileName) {
		URL url = getClass().getResource(FileName);
		String path = url.getPath();
		
		ArrayList<Human> people = new ArrayList<Human>();
		ArrayList<String> fileData = FileIOService.ReadFromFile(path);
		
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
	public void Delete(UUID entityId, String FileName) {
		ArrayList<Human> people = LoadAllFromTextFile(FileName);
		for(int i = 0; i < people.size(); i++) {
			if(people.get(i).get_id().equals(entityId)) {
				people.remove(i);
				break;
			}
		}
		DeleteAll(FileName);
		SaveToTextFile(people, FileName);
	}

	@Override
	public void DeleteAll(String FileName) {
		URL url = getClass().getResource(FileName);
		String path = url.getPath();
		FileIOService.WriteToFile(path, "", false);
	}

}
