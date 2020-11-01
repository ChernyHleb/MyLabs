package Model;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.Random;

public class Randomiser {
	private static ArrayList<String> maleNames = new ArrayList<String>(Arrays.asList(
			"Liam", "Noah", "Oliver", "William", "Elijah", "James", 
			"Benjamin", "Lucas", "Mason", "Ethan"));
	private static ArrayList<String> femaleNames = new ArrayList<String>(Arrays.asList(
			"Olivia", "Emma", "Ava", "Sophia","Isabella", "Charlotte", 
			"Amelia", "Mia", "Harper", "Evelyn"));
	private static ArrayList<String> lastNames = new ArrayList<String>(Arrays.asList(
			"Abe", "Abell", "Abler", "Bach", "Backer", "Cabot", "Cady",
			"DТErrico", "DТAntoni", "Da Pra", "Eash", "Eaton", "Eakes",
			"Fabris", "Fagg"));
	private static ArrayList<String> subjectNames = new ArrayList<String>(Arrays.asList(
			"Maths", "English", "Java", "Physics", "Chemistry", "Geography",
			"History", "Art", "Economics", "Music"));
	
	/// сделать нормально
	public static ArrayList<Semester> rndSemestersForNerd(Double moneyAmount)
	{
		ArrayList<Semester> semesters = new ArrayList<Semester>(1);
		ArrayList<Subject> subjects = new ArrayList<Subject>(1);
		ArrayList<Double> marks = new ArrayList<Double>(3);
		Double AverageMark = Math.log10(moneyAmount) % 10;
		marks.add(AverageMark);
		marks.add(AverageMark);
		marks.add(AverageMark);
		subjects.add(new Subject(rndSubjectName(), marks));
		semesters.add(new Semester("1", subjects));
		
		return semesters;
	}
	/// сделать нормально
	public static ArrayList<Semester> rndSemesters()
	{
		ArrayList<Semester> semesters = new ArrayList<Semester>(1);
		ArrayList<Subject> subjects = new ArrayList<Subject>(1);
		ArrayList<Double> marks = new ArrayList<Double>(3);
		Double AverageMark = rndDouble(10);
		marks.add(AverageMark);
		marks.add(AverageMark);
		marks.add(AverageMark);
		subjects.add(new Subject(rndSubjectName(), marks));
		semesters.add(new Semester("1", subjects));
		
		return semesters;
	}
	
	public static String rndSubjectName()
	{
		return subjectNames.get((int)rndDouble(subjectNames.size() - 1));
	}
	
	public static String rndPatronymic()
	{
		return maleNames.get((int)rndDouble(Randomiser.maleNames.size() - 1));
	}
	
	public static String rndLastName()
	{
		return lastNames.get((int)rndDouble(Randomiser.lastNames.size() - 1));
	}
	
	public static String rndName(Gender gender)
	{
		if(gender == Gender.Male)
		{
			return Randomiser.maleNames.get((int)rndDouble(Randomiser.maleNames.size() - 1));
		}
		else
		{
			return Randomiser.femaleNames.get((int)rndDouble(Randomiser.femaleNames.size() - 1));
		}
	}
	
	public static Gender rndGender()
	{	
		if(rndDouble(1) == 1)
		{
			return Gender.Male;
		}
		else
		{
			return Gender.Female;
		}
	}
	
	public static double rndDouble(final double max)
	{
		return Math.random() * max;
	}
	
	public static Date rndDate()
	{
		Random  rnd = new Random();
		long    ms;

		// Get an Epoch value roughly between 1940 and 2010
		// -946771200000L = January 1, 1940
		// Add up to 70 years to it (using modulus on the next long)
		ms = -946771200000L + (Math.abs(rnd.nextLong()) % (70L * 365 * 24 * 60 * 60 * 1000));

		return new Date(ms);
	}
}
