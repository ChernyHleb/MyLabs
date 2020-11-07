package Model;

import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.UUID;

interface IStudent {
	Parent GetPair(UUID id, String lastName, Date birthday, 
			String patronymic, Gender gender, Double moneyAmount);
	Double get_lastSessionAverageMark();
}

public class Student extends Human implements IStudent {
	protected ArrayList<Semester> _semesters;

	public Student(UUID id, String firstName, String lastName, String patronymic, Date birthday,
			Gender gender, Double moneyAmount, ArrayList<Semester> semesters) {
		super(id, firstName, lastName, patronymic, birthday, gender, moneyAmount);
		this._semesters = semesters;
	}
	
	public Student()
	{
		super();
		this._semesters = Randomiser.rndSemesters();
	}
	
	public Student(String str) throws ParseException
	{
		super(str);
	}
	
	public Double get_lastSessionAverageMark()
	{
		Semester lastSemester = this._semesters.get(this._semesters.size() - 1);
		return lastSemester.get_averageMark();
	}
	
	public String toString()
	{
		String output = String.format("~STUDENT %s AverageMark: '%f'", 
				super.toString(),
				this.get_lastSessionAverageMark()
			);
		return output;
	}
	
	public String SerializeToString()
	{
		String result = String.format("STUDENT %s",
				super.SerializeToString());
		/// add subjects
		return result;
	}
	
	public Parent GetPair(UUID id, String lastName, Date birthday,
			String patronymic, Gender gender, Double moneyAmount) {
		Parent parent = new Parent(id, this._patronymic ,lastName, patronymic, 
				birthday, gender, moneyAmount);
		return parent;
	}
	
	public Parent GetPair()
	{
		Parent parent = new Parent();
		parent.SetFirstName(this._patronymic);
		return parent;
	}
	
	public ArrayList<Semester> get_semesters() {
		return _semesters;
	}

	public void set_semesters(ArrayList<Semester> _semesters) {
		this._semesters = _semesters;
	}
}
