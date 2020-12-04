package Services;

import Model.ExperimentResult;

public class ExperimentLogger {
	private static String pathToLog;
	private static String currentDirectory;
	
	public ExperimentLogger(String logName) {
		currentDirectory = System.getProperty("user.dir");
		pathToLog = currentDirectory + "/src/Services/" + logName;
	}
	
	public void WriteToLog(String operation, int idnex, long time) {
			String output = String.format(
					"%s %d %f", 
					operation,
					idnex,
					time
					);
			FileIOService.WriteToFile(pathToLog, output, true);					
	}
	
	public void WriteToLog(ExperimentResult result) {
		String output = result.ToString();
		FileIOService.WriteToFile(pathToLog, output, true);	
	}
}
