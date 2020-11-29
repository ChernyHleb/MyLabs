package Services;

public class ErrorHandleService {
	private static long errorCounter;

	public static void ShowError(Exception ex) {
		errorCounter ++;
		String output = "ERROR: " + ex.getMessage();
		LoggerService.WriteToLog(output);
	}
	
	public static long getErrorCounter() {
		return errorCounter;
	}
	
}
