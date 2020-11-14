package Repository;

import java.net.URL;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.UUID;

import Model.Human;
import Model.Student;
import Services.DataFilterService;
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
		
		ArrayList<Human> result = new ArrayList<Human>();
		
		ArrayList<String> data =
			DataFilterService.FilterData(
					FileIOService.ReadFromFile(path),
					"STUDENT"
			);
		
		for(String str : data) {
			try {
				result.add(new Student(str));
			} catch (ParseException e) {
				e.printStackTrace();
			}
		}
		
		return result;
	}

}
