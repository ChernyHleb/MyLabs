import Model.Student;
import Model.CoolParent;
import Model.Nerd;
import Model.Parent;

public class TestProjectController {
	public View _view;
	
	public TestProjectController()
	{
		this._view = new View();
	}
	
	public void run()
	{
		this._view.WriteText(String.format("STUDENT TEST:\n%s\n", this.test_student()));
		this._view.WriteText(String.format("NERD TEST:\n%s\n", this.test_nerd()));
		this._view.WriteText(String.format("PARENT TEST:\n%s\n", this.test_parent()));
		this._view.WriteText(String.format("COOLPARENT TEST:\n%s\n", this.test_coolParent()));
		this._view.WriteText(this.test_SerializeToStringMethod());
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
}
