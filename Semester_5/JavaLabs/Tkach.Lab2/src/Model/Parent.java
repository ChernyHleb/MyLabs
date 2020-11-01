package Model;

import java.util.ArrayList;
import java.util.Date;

public class Parent extends Human {

	public Parent(String firstName, String lastName, Date birthday, 
			String patronymic, Gender gender, Double moneyAmount, ArrayList<Human> parents, ArrayList<Human> children) {
		super(firstName, lastName, birthday, patronymic, gender, moneyAmount, parents, children);
		
	}
	
	public Parent()
	{
		super();
	}
	
	public String toString()
	{
		return String.format("~PARENT %s", super.toString());
	}
	
	public Student GetPair(String firstName, String lastName, Date birthday, Gender gender,
			Double moneyAmount, ArrayList<Semester> semesters) {
		 String patronymic = this._firstName;
		 Student student = new Student(firstName, lastName, birthday, patronymic, gender,
					moneyAmount, semesters, new ArrayList<Human>(), new ArrayList<Human>());
		 this._children.add(student);
		 return student;
	}
	
	public Student GetPair()
	{
		String patronymic = this._firstName;
		Student student = new Student();
		student.SetPatronymic(patronymic);
		
		this._children.add(student);
		return student;
	}
}
