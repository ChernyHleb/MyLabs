import Model.Student;

import java.text.ParseException;

import Model.CoolParent;
import Model.Nerd;
import Model.Parent;

public class TestProjectController {
	public View _view;
	
	public TestProjectController()
	{
		this._view = new View();
	}
	
	public void run() throws ParseException
	{
		this._view.WriteText(String.format("STUDENT TEST:\n%s\n", this.test_student()));
		this._view.WriteText(String.format("NERD TEST:\n%s\n", this.test_nerd()));
		this._view.WriteText(String.format("PARENT TEST:\n%s\n", this.test_parent()));
		this._view.WriteText(String.format("COOLPARENT TEST:\n%s\n", this.test_coolParent()));
		this._view.WriteText(this.test_SerializeToStringMethod());
		this._view.WriteText(this.test_ConstructorFromString());
	}
	
	private String test_student()
	{
		Student testStudent = new Student();
		String output = String.format("%s\n~GETPAIR %s", 
				testStudent.toString(), testStudent.GetPair().toString());
		return output;
	}
	
	private String test_nerd()
	{
		Nerd testNerd = new Nerd();
		String output = String.format("%s\n~GETPAIR %s", 
				testNerd.toString(), testNerd.GetPair().toString());
		return output;
		
	}
	
	private String test_parent()
	{
		Parent testParent = new Parent();
		String output = String.format("%s\n~GETPAIR %s", 
				testParent.toString(), testParent.GetPair().toString());
		return output;
	}
	
	private String test_coolParent()
	{
		CoolParent testCoolParent = new CoolParent();
		String output = String.format("%s\n~GETPAIR %s", 
				testCoolParent.toString(), testCoolParent.GetPair().toString());
		return output;
	}
	
	private String test_SerializeToStringMethod()
	{
		Student testStudent = new Student();
		Nerd testNerd = new Nerd();
		Parent testParent = new Parent();
		CoolParent testCoolParent = new CoolParent();
		
		String output = String.format("\n~SERIALIZE_TO_STRING:\n%s\n%s\n%s\n%s\n", 
				testStudent.SerializeToString(),
				testNerd.SerializeToString(),
				testParent.SerializeToString(),
				testCoolParent.SerializeToString()
				);
		return output;
	}
	
	private String test_ConstructorFromString() throws ParseException
	{
		String studentString = "STUDENT 2af239ab-c44b-4f07-a490-92475f75aaae Isabella Abler Noah 03-01-1980%04:59:18 Female 351818,618093";
		String nerdString = "NERD f55345bd-7265-49d2-b358-f9e256f4ebe6 Emma Abler James 29-12-1952%22:13:55 Female 526792,672987";
		String parentString = "PARENT 4b380242-f8a0-4499-9a49-899d5533256d Harper D’Antoni James 26-07-1969%02:29:26 Female 739715,930263";
		String coolParentString = "COOLPARENT 8c2e9ffd-fa5e-43c4-946e-73c9d5be9427 Ava Backer Oliver 21-06-1975%08:11:25 Female 11911,241751";
		
		
		Student testStudent = new Student(studentString);
		Nerd testNerd = new Nerd(nerdString);
		Parent testParent = new Parent(parentString);
		CoolParent testCoolParent = new CoolParent(coolParentString);
		
		String output = String.format("\n~CONSTRUCTOR_FROM_STRING:\n%s\n%s\n%s\n%s\n", 
				testStudent.SerializeToString(),
				testNerd.SerializeToString(),
				testParent.SerializeToString(),
				testCoolParent.SerializeToString()
				);
		return output;
	}
}
