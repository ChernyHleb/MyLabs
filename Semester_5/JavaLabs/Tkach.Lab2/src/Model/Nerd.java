package Model;

import java.util.ArrayList;
import java.util.Date;

public class Nerd extends Student {
	
	public Nerd(String firstName, String lastName, Date birthday,
			String patronymic, Gender gender, Double moneyAmount,
			ArrayList<Semester> semesters,
			ArrayList<Human> parents, ArrayList<Human> children) {
		super(firstName, lastName, birthday, patronymic, gender, 
				moneyAmount, semesters, parents, children);
	}
	
	public Nerd()
	{
		super();
	}
	
	public String toString()
	{
		String output = String.format("~NERD %s AverageMark: '%f'", 
				super.toString(),
				this.get_lastSessionAverageMark()
			);
		return output;
	}

	public CoolParent GetPair(String lastName, Date birthday,
			String patronymic, Gender gender) {
		Double moneyAmount = Math.pow(10, Math.round(this.get_lastSessionAverageMark()));
		CoolParent parent = new CoolParent(this._patronymic, lastName, birthday, patronymic, gender, moneyAmount
				, new ArrayList<Human>(), new ArrayList<Human>());
		
		this._parents.add(parent);
		return parent;
	}
	
	public CoolParent GetPair()
	{
		Double moneyAmount = Math.pow(10, Math.round(super.get_lastSessionAverageMark()));
		CoolParent parent = new CoolParent();
		parent.SetFirstName(this._patronymic);
		parent.SetMoneyAmount(moneyAmount);
		
		this._parents.add(parent);
		return parent;
	}
}
