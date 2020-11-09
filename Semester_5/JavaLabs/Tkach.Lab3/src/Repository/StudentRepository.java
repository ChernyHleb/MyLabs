package Repository;

import java.io.File;
import java.lang.reflect.Array;
import java.net.URL;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.UUID;

import Model.Student;
import Services.DataFilterService;
import Services.FileIOService;

public class StudentRepository implements IRepository<Student>{

	@Override
	public Student LoadFromTextFile(UUID entityId, String FileName) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void SaveToTextFile(Student entity, String FileName) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void SaveToTextFile(ArrayList<Student> entities, String FileName) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public ArrayList<Student> LoadAllFromTextFile(String FileName) {
		URL url = getClass().getResource(FileName);
		String path = url.getPath();
		
		ArrayList<Student> result = new ArrayList<Student>();
		
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
