package Model;

import java.util.Date;

interface ICoolParent{
	void giveMoney(Student student, Double money);
}

public class CoolParent extends Parent implements ICoolParent{

	public CoolParent(String firstName, String lastName,String patronymic,
			Date birthday, Gender gender,Double moneyAmount) {
		super(firstName, lastName, patronymic, birthday, gender, moneyAmount);
	}

	public CoolParent()
	{
		super();
	}
	
	public String toString()
	{
		return String.format("~COOLPARENT %s", super.toString());
	}
	
	public void giveMoney(Student student, Double money) {
		try {
			
			if(this._moneyAmount - money < 0)
			{
				throw new Exception("Not enough money to give away!");
			}
			this._moneyAmount -= money;
			student.SetMoneyAmount(student.GetMoneyAmount() + money);
		} catch (Exception ex) {
			return;
		}
	}
	
	public Nerd GetPair(String firstName, String lastName, Date birthday, 
			Gender gender, Double moneyAmount) {
		Nerd nerd = new Nerd(firstName, lastName,this._firstName,
				birthday, gender, moneyAmount, 
				Randomiser.rndSemestersForNerd(this._moneyAmount));
		return nerd;
	}
	
	public Nerd GetPair()
	{
		Nerd nerd = new Nerd();
		nerd.SetFirstName(this._firstName);
		nerd.set_semesters(Randomiser.rndSemestersForNerd(this._moneyAmount));
		return nerd;
	}
	
}
