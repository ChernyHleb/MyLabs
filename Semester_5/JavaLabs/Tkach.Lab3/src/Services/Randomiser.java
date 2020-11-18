package Services;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.Random;

import Model.CoolParent;
import Model.Gender;
import Model.Human;
import Model.HumanType;
import Model.Nerd;
import Model.Parent;
import Model.Semester;
import Model.Student;
import Model.Subject;
import Model.User;
import Model.UserType;

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
	private static ArrayList<String> userNames = new ArrayList<String>(Arrays.asList(
			"catto", "doggo", "elPepe", "EteSech", "PinkGuy", "FilthyFrank", "wizardCatto", 
			"bread"));
	
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
		return subjectNames.get((int)rndDouble(subjectNames.size()));
	}
	
	public static String rndPatronymic()
	{
		return maleNames.get((int)rndDouble(Randomiser.maleNames.size()));
	}
	
	public static String rndLastName()
	{
		return lastNames.get((int)rndDouble(Randomiser.lastNames.size() - 1));
	}
	
	public static String rndName(Gender gender)
	{
		if(gender == Gender.Male)
		{
			return Randomiser.maleNames.get((int)rndDouble(Randomiser.maleNames.size()));
		}
		else
		{
			return Randomiser.femaleNames.get((int)rndDouble(Randomiser.femaleNames.size()));
		}
	}
	
	public static Gender rndGender()
	{	
		if((int)rndDouble(2) == 1)
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
	
	public static User rndUser()
	{
		String name = userNames.get((int)rndDouble(userNames.size()));
		String password = rndString(10);
		UserType type = UserType.values()[(int)rndDouble(UserType.values().length)];
		return new User(name, password, type);
	}
	
	public static String rndString(int length) {
	    int leftLimit = (int)'a';
	    int rightLimit = (int)'z' ;
	    
	    Random random = new Random();
	 
	    String generatedString = random.ints(leftLimit, rightLimit + 1)
	      .limit(length)
	      .collect(StringBuilder::new, StringBuilder::appendCodePoint, StringBuilder::append)
	      .toString();
	 
	    return generatedString;
	}
	
	public static Human rndHuman() {
		HumanType type = HumanType.values()[(int)rndDouble(HumanType.values().length)];
		Human human = null;
		
		switch(type) {
		case STUDENT:
			human = new Student();
			break;
		case PARENT:
			human = new Parent();
			break;
		case NERD:
			human = new Nerd();
			break;
		case COOLPARENT:
			human = new CoolParent();
			break;
		}
		
		return human;
	}
	
	public static ArrayList<String> getUserNames() {
		return userNames;
	}
	public static void setUserNames(ArrayList<String> userNames) {
		Randomiser.userNames = userNames;
	}
}
