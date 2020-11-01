package Model;

import java.util.ArrayList;

public class Semester {
	private String _name;
	private ArrayList<Subject> _subjects;
	
	public Semester(String name, ArrayList<Subject> subjects)
	{
		this._name = name;
		this._subjects = subjects;
	}
	
	public Double get_averageMark()
	{
		Double sum = 0.0;
		for(Subject subject : this._subjects)
		{
			sum += subject.get_averageMark();
		}
		Long res = new Long(Math.round(sum / this._subjects.size()));
		
		return res.doubleValue();
	}
	
	public String get_name() {
		return _name;
	}
	public void set_name(String _name) {
		this._name = _name;
	}
	
	public ArrayList<Subject> get_subjects() {
		return _subjects;
	}
	public void set_subjects(ArrayList<Subject> _subjects) {
		this._subjects = _subjects;
	}
}
