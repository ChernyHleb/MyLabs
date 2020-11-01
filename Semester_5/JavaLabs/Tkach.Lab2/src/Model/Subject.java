package Model;

import java.util.ArrayList;

public class Subject {
	private String _name;
	private ArrayList<Double> _marks;
	
	public Subject(String name, ArrayList<Double> marks)
	{
		this._marks = marks;
		this._name = name;
	}
	
	public Double get_averageMark()
	{
		Double sum = (double) 0;
		for(Double mark : this._marks)
		{
			sum += mark;
		}
		
		return sum / this._marks.size();
	}
	

	public String get_name() {
		return _name;
	}

	public void set_name(String _name) {
		this._name = _name;
	}

	public ArrayList<Double> get_marks() {
		return _marks;
	}

	public void set_marks(ArrayList<Double> _marks) {
		this._marks = _marks;
	}
}
