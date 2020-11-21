package Services;

import java.io.FileInputStream;
import java.io.IOException;
import java.util.Properties;

public class ProgramSettingsService {
	private static String currentDir;
	private static String settingsFilePath;
	private static String settingsFileName;
	private static FileInputStream fis;
    private static Properties properties = new Properties();

	public static Properties getProperties() {
		return properties;
	}

	static {
		settingsFileName = "appSettings.properties";
		currentDir = System.getProperty("user.dir");
		settingsFilePath = currentDir + "/src/Services/" + settingsFileName;
	}
	
	public static void LoadProperties() {
		try {
            fis = new FileInputStream(settingsFilePath);
            properties.load(fis);

        } catch (IOException e) {
            System.err.println("ERROR: There is no such file!");
        }
	}
	
	public static void ImplementSettings() {
		String logging = properties.getProperty("main.logging");
        String tests = properties.getProperty("main.tests");
        
		if(logging.equals("1"))
        	LoggerService.Enable();
        else
        	LoggerService.Disable();
	}
}
