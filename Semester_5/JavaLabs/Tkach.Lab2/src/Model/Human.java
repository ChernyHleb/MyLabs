package Model;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
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
	
	protected String _humanType;
	
	public Human()
	{
		this._id = UUID.randomUUID();
		this._birthDate = Randomiser.rndDate();
		this._gender = Randomiser.rndGender();
		this._firstName = Randomiser.rndName(this._gender);
		this._lastName = Randomiser.rndLastName();
		this._patronymic = Randomiser.rndPatronymic();
		this._moneyAmount = Randomiser.rndDouble(1000000);
	}
	
	public Human(UUID id ,String firstName, String lastName, String patronymic, 
			Date birthday, Gender gender, Double moneyAmount)
	{
		this._id = id;
		this._birthDate = birthday;
		this._firstName = firstName;
		this._lastName = lastName;
		this._patronymic = patronymic;
		this._gender = gender;
		this._moneyAmount = moneyAmount;
	}
	
	public Human(String str) throws ParseException
	{
		String[] data = str.split(" ");
		this._id = UUID.fromString(data[1]);
		this._firstName = data[2];
		this._lastName = data[3];
		this._patronymic = data[4];
		this._birthDate = (new SimpleDateFormat("dd-MM-yyyy HH:mm:ss")).parse(data[5].replaceAll("%", " "));
		this._gender = Gender.valueOf(data[6]);
		this._moneyAmount = Double.parseDouble(data[7].replaceAll(",", "."));
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
	
	public String SerializeToString()
	{
		String birthdayAsString = (new SimpleDateFormat("dd-MM-yyyy HH:mm:ss")).format(_birthDate);
		String result = String.format("%s %s %s %s %s %s %f",
				_id.toString(),
				_firstName,
				_lastName,
				_patronymic,
				birthdayAsString.replaceAll(" ", "%"),
				_gender.toString(),
				_moneyAmount
				);
		return result;
	}

	public String get_firstName() {
		return _firstName;
	}

	public void set_firstName(String _firstName) {
		this._firstName = _firstName;
	}

	public int GetAge() {
		Date today = new Date();
		long diff = today.getTime() - this._birthDate.getTime();
		int years = (int)(diff / (365 * 24 * 60 * 60 * 1000));
		return years;
	}

	public String get_lastName() {
		return _lastName;
	}

	public void set_lastName(String _lastName) {
		this._lastName = _lastName;
	}

	public Date get_birthDate() {
		return _birthDate;
	}

	public void set_birthDate(Date _birthDate) {
		this._birthDate = _birthDate;
	}
	
	public Gender get_gender() {
		return _gender;
	}

	public void set_gender(Gender _gender) {
		this._gender = _gender;
	}
	
	public Double get_moneyAmount() {
		return _moneyAmount;
	}

	public void set_moneyAmount(Double _moneyAmount) {
		this._moneyAmount = _moneyAmount;
	}
	
	public String get_patronymic() {
		return _patronymic;
	}

	public void set_patronymic(String _patronymic) {
		this._patronymic = _patronymic;
	}
	
	public UUID get_id() {
		return _id;
	}

	public void set_id(UUID _id) {
		this._id = _id;
	}

	public String get_humanType() {
		return _humanType;
	}

	public void set_humanType(String _humanType) {
		this._humanType = _humanType;
	}

}
