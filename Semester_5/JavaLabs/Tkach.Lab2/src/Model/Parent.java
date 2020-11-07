package Model;

import java.util.ArrayList;
import java.util.Date;

public class Parent extends Human {

	public Parent(String firstName, String lastName, String patronymic, 
			Date birthday, Gender gender, Double moneyAmount) {
		super(firstName, lastName,  patronymic, birthday, gender, moneyAmount);
		
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
		 Student student = new Student(firstName, lastName, patronymic, birthday, gender,
					moneyAmount, semesters);
		 return student;
	}
	
	public Student GetPair()
	{
		String patronymic = this._firstName;
		Student student = new Student();
		student.SetPatronymic(patronymic);
		
		return student;
	}
}
