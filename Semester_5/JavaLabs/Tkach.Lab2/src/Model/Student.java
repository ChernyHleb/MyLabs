package Model;

import java.util.ArrayList;
import java.util.Date;

interface IStudent {
	Parent GetPair(String lastName, Date birthday, 
			String patronymic, Gender gender, Double moneyAmount);
	Double get_lastSessionAverageMark();
}

public class Student extends Human implements IStudent {
	protected ArrayList<Semester> _semesters;

	public Student(String firstName, String lastName, Date birthday, String patronymic, Gender gender,
			Double moneyAmount, ArrayList<Semester> semesters, 
			ArrayList<Human> parents, ArrayList<Human> children) {
		super(firstName, lastName, birthday, patronymic, gender, moneyAmount, parents, children);
		this._semesters = semesters;
	}
	
	public Student()
	{
		super();
		this._semesters = Randomiser.rndSemesters();
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
	
	public Parent GetPair(String lastName, Date birthday,
			String patronymic, Gender gender, Double moneyAmount) {
		Parent parent = new Parent(this._patronymic ,lastName, birthday, patronymic, gender, moneyAmount, new ArrayList<Human>(), new ArrayList<Human>());
		this._parents.add(parent);
		return parent;
	}
	
	public Parent GetPair()
	{
		Parent parent = new Parent();
		parent.SetFirstName(this._patronymic);
		this._parents.add(parent);
		return parent;
	}
	
	public ArrayList<Semester> get_semesters() {
		return _semesters;
	}

	public void set_semesters(ArrayList<Semester> _semesters) {
		this._semesters = _semesters;
	}
}
