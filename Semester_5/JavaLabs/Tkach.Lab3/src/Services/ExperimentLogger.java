package Services;

public class ExperimentLogger {
	private static String pathToLog;
	private static String currentDirectory;
	
	public ExperimentLogger(String logName) {
		currentDirectory = System.getProperty("user.dir");
		pathToLog = currentDirectory + "/src/Services/" + logName;
	}
	
	public void WriteToLog(String operation, int id, double time) {
		
			String output = String.format(
					"%s %d %f", 
					operation,
					id,
					time
					);
			FileIOService.WriteToFile(pathToLog, output, true);					
	}
}
