package Model;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.UUID;

public abstract class Human {
	
	protected UUID _id;
	protected String _firstName;
	protected String _lastName;
	protected String _patronymic;
	protected Date _birthDate;
	protected Gender _gender;
	protected Double _moneyAmount;
	protected ArrayList<Human> _parents;
	protected ArrayList<Human> _children;
	
	public Human()
	{
		this._birthDate = Randomiser.rndDate();
		this._gender = Randomiser.rndGender();
		this._firstName = Randomiser.rndName(this._gender);
		this._lastName = Randomiser.rndLastName();
		this._patronymic = Randomiser.rndPatronymic();
		this._moneyAmount = Randomiser.rndDouble(1000000);
		//this.set_parents(randomHuman._parents);
		//this.set_children(randomHuman._children);
	}
	
	public Human(String firstName, String lastName, Date birthday,
			String patronymic, Gender gender, Double moneyAmount,
			ArrayList<Human> parents, ArrayList<Human> children)
	{
		this._birthDate = birthday;
		this._firstName = firstName;
		this._lastName = lastName;
		this._patronymic = patronymic;
		this._gender = gender;
		this._moneyAmount = moneyAmount;
		this.set_parents(parents);
		this.set_children(children);
	}
	
	public String toString()
	{
		String output = String.format("Name: '%s' LastName: '%s' Patronymic: '%s'"
				+ " Age: '%d' Gender: '%s' Money: '%f'", 
				this._firstName,
				this._lastName,
				this._patronymic,
				this.GetAge(),
				this._gender.toString(),
				this._moneyAmount
			);
		return output;
	}

	public String GetFirstName() {
		return _firstName;
	}

	public void SetFirstName(String _firstName) {
		this._firstName = _firstName;
	}

	public int GetAge() {
		Date today = new Date();
		long diff = today.getTime() - this._birthDate.getTime();
		int years = (int)(diff / (365 * 24 * 60 * 60 * 1000));
		return years;
	}

	public String GetLastName() {
		return _lastName;
	}

	public void SetLastName(String _lastName) {
		this._lastName = _lastName;
	}

	public Date GetBirthDate() {
		return _birthDate;
	}

	public void SetBirthDate(Date _birthDate) {
		this._birthDate = _birthDate;
	}
	
	public String GetPatronymic() {
		return _patronymic;
	}

	public void SetPatronymic(String _patronymic) {
		this._patronymic = _patronymic;
	}
	
	public Gender GetGender() {
		return _gender;
	}

	public void SetGender(Gender _gender) {
		this._gender = _gender;
	}
	
	public Double GetMoneyAmount() {
		return _moneyAmount;
	}

	public void SetMoneyAmount(Double _moneyAmount) {
		this._moneyAmount = _moneyAmount;
	}

	public ArrayList<Human> get_parents() {
		return _parents;
	}

	public void set_parents(ArrayList<Human> _parents) {
		this._parents = _parents;
	}

	public ArrayList<Human> get_children() {
		return _children;
	}

	public void set_children(ArrayList<Human> _children) {
		this._children = _children;
	}
	
	public void add_child(Human child)
	{
		this._children.add(child);
	}
}
