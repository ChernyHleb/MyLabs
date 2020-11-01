import java.util.Scanner;

public class View {
	private Scanner _scanner;
	
	public View()
	{
		this._scanner = new Scanner(System.in);
	}
	
	public void WriteText(String text)
	{
		System.out.println(text);
	}
	
	public String ReadString()
	{
		return this._scanner.nextLine();
	}
}
