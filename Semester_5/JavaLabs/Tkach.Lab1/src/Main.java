
public class Main {

	public static void main(String[] args) {
		View TestView = new View();
		Controller testController = new Controller(new Model(100), TestView);
		int number = testController.GuessNumber();
		TestView.WriteText(Integer.toString(number));
	}

}
