package Repository;

import java.lang.reflect.Array;
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
		ArrayList<Student> result = new ArrayList<Student>();
		
		ArrayList<String> data =
			DataFilterService.FilterData(
					FileIOService.ReadFromFile(FileName),
					"STUDENT"
			);
		
		for(String str : data) {
			result.add(StringToEntity(str));
		}
		
		return result;
	}

	@Override
	public Student StringToEntity(String str) {
		ArrayList<String> attributes = new ArrayList<String>(Arrays.asList(str.split(" ")));
		
		Student student = new Student();
		
		return student;
	}

	
}
