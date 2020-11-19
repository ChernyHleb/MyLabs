package Services;

import java.time.LocalDate;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;

public class LoggerService {
	private static boolean enabled;
	private static String pathToLog;
	private static String currentDirectory;
	
	static {
		setEnabled(true);
		currentDirectory = System.getProperty("user.dir");
		pathToLog = currentDirectory + "/src/Services/Log.txt";
	}
	
	public static void WriteToLog(String str) {
		LocalTime time = LocalTime.now();
		LocalDate date = LocalDate.now();
		String output = String.format(
				"%s %s %s", 
				date.format(DateTimeFormatter.ofPattern("dd.MM.yyyy")),
				time.format(DateTimeFormatter.ofPattern("H:mm:ss")),
				str
				);
		FileIOService.WriteToFile(pathToLog, output, true);					
	}

	public static boolean isEnabled() {
		return enabled;
	}

	public static void setEnabled(boolean enabled) {
		LoggerService.enabled = enabled;
	}
}
