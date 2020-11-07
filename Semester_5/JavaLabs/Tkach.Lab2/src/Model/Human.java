package Model;

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
	
	public Human()
	{
		this._birthDate = Randomiser.rndDate();
		this._gender = Randomiser.rndGender();
		this._firstName = Randomiser.rndName(this._gender);
		this._lastName = Randomiser.rndLastName();
		this._patronymic = Randomiser.rndPatronymic();
		this._moneyAmount = Randomiser.rndDouble(1000000);
	}
	
	public Human(String firstName, String lastName, String patronymic, 
			Date birthday, Gender gender, Double moneyAmount)
	{
		this._birthDate = birthday;
		this._firstName = firstName;
		this._lastName = lastName;
		this._patronymic = patronymic;
		this._gender = gender;
		this._moneyAmount = moneyAmount;
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
}
