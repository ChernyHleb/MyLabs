package Model;

import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.UUID;

public class Parent extends Human {

	public Parent(UUID id, String firstName, String lastName, String patronymic, 
			Date birthday, Gender gender, Double moneyAmount) {
		super(id, firstName, lastName,  patronymic, birthday, gender, moneyAmount);
		this._humanType = "PARENT";
	}
	
	public Parent()
	{
		super();
		this._humanType = "PARENT";
	}
	
	public Parent(String str) throws ParseException
	{
		super(str);
		this._humanType = "PARENT";
	}
	
	public String toString()
	{
		return String.format("~PARENT %s", super.toString());
	}
	
	public String SerializeToString()
	{
		String result = String.format("PARENT %s",
				super.SerializeToString());
		return result;
	}
	
	public Student GetPair(UUID id, String firstName, String lastName, Date birthday, Gender gender,
			Double moneyAmount, ArrayList<Semester> semesters) {
		 String patronymic = this._firstName;
		 Student student = new Student(id, firstName, lastName, patronymic, birthday, gender,
					moneyAmount, semesters);
		 return student;
	}
	
	public Student GetPair()
	{
		String patronymic = this._firstName;
		Student student = new Student();
		student.set_patronymic(patronymic);
		
		return student;
	}
}
