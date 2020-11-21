package Services;

import java.time.LocalDate;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;

public class LoggerService {
	private static boolean enabled;
	private static String pathToLog;
	private static String currentDirectory;
	
	static {
		Enable();
		currentDirectory = System.getProperty("user.dir");
		pathToLog = currentDirectory + "/src/Services/Log.txt";
	}
	
	public static void WriteToLog(String str) {
		if(enabled == true) {
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
	}

	public static boolean isEnabled() {
		return enabled;
	}

	public static void Enable() {
		WriteToLog("LOGGER ENABLED");
		LoggerService.enabled = true;
	}
	
	public static void Disable() {
		WriteToLog("LOGGER DISABLED");
		LoggerService.enabled = false;
	}
}
