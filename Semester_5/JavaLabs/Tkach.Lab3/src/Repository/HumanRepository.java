package Repository;

import java.net.URL;
import java.util.ArrayList;
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
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void SaveToTextFile(Human entity, String FileName) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void SaveToTextFile(ArrayList<Human> entities, String FileName) {
		// TODO Auto-generated method stub
		
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

}
