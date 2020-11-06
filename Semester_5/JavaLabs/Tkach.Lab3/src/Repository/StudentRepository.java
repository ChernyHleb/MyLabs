package Repository;

import java.util.ArrayList;
import java.util.UUID;

import Model.Student;

public class StudentRepository implements IRepository<Student>{

	@Override
	public Student Load(UUID entityId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void Save(Student entity) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void Save(ArrayList<Student> entities) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public ArrayList<Student> LoadAll() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public ArrayList<String> readFromDBFile() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void writeToDBFile(ArrayList<Student> data) {
		// TODO Auto-generated method stub
		
	}
}
