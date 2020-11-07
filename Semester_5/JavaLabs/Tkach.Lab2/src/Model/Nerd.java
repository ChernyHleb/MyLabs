package Model;

import java.util.ArrayList;
import java.util.Date;
import java.util.UUID;

public class Nerd extends Student {
	
	public Nerd(UUID id, String firstName, String lastName,String patronymic,
			Date birthday, Gender gender, Double moneyAmount,
			ArrayList<Semester> semesters) {
		super(id, firstName, lastName, patronymic, birthday, gender, 
				moneyAmount, semesters);
	}
	
	public Nerd()
	{
		super();
	}
	
	public String toString()
	{
		String output = String.format("~NERD %s", 
				super.toString());
		return output;
	}
	
	public String SerializeToString()
	{
		String result = super.SerializeToString().replaceFirst("^STUDENT", "NERD");
		return result;
	}

	public CoolParent GetPair(UUID id, String lastName, Date birthday,
			String patronymic, Gender gender) {
		Double moneyAmount = Math.pow(10, Math.round(this.get_lastSessionAverageMark()));
		CoolParent parent = new CoolParent(id, this._patronymic, lastName, 
				patronymic, birthday, gender, moneyAmount);
		
		return parent;
	}
	
	public CoolParent GetPair()
	{
		Double moneyAmount = Math.pow(10, Math.round(super.get_lastSessionAverageMark()));
		CoolParent parent = new CoolParent();
		parent.SetFirstName(this._patronymic);
		parent.SetMoneyAmount(moneyAmount);
		
		return parent;
	}
}
