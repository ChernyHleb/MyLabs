package Model;

import java.text.ParseException;
import java.util.Date;
import java.util.UUID;

interface ICoolParent{
	void giveMoney(Student student, Double money);
}

public class CoolParent extends Parent implements ICoolParent{

	public CoolParent(UUID id, String firstName, String lastName,String patronymic,
			Date birthday, Gender gender,Double moneyAmount) {
		super(id, firstName, lastName, patronymic, birthday, gender, moneyAmount);
		this._humanType = "COOLPARENT";
	}

	public CoolParent()
	{
		super();
		this._humanType = "COOLPARENT";
	}
	
	public CoolParent(String str) throws ParseException
	{
		super(str);
		this._humanType = "COOLPARENT";
	}
	
	public String toString()
	{
		return String.format("~COOLPARENT %s", super.toString());
	}
	
	public String SerializeToString()
	{
		String result = super.SerializeToString().replaceFirst("^PARENT", "COOLPARENT");
		return result;
	}
	
	public void giveMoney(Student student, Double money) {
		try {
			
			if(this._moneyAmount - money < 0)
			{
				throw new Exception("Not enough money to give away!");
			}
			this._moneyAmount -= money;
			student.set_moneyAmount(student.get_moneyAmount() + money);
		} catch (Exception ex) {
			return;
		}
	}
	
	public Nerd GetPair(UUID id, String firstName, String lastName, Date birthday, 
			Gender gender, Double moneyAmount) {
		Nerd nerd = new Nerd(id, firstName, lastName,this._firstName,
				birthday, gender, moneyAmount, 
				Randomiser.rndSemestersForNerd(this._moneyAmount));
		return nerd;
	}
	
	public Nerd GetPair()
	{
		Nerd nerd = new Nerd();
		nerd.set_firstName(this._firstName);
		nerd.set_semesters(Randomiser.rndSemestersForNerd(this._moneyAmount));
		return nerd;
	}
	
}
