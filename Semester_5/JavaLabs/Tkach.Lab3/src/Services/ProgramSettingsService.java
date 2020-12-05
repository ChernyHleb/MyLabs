package Services;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Properties;

public class ProgramSettingsService {
	private static String currentDir;
	private static String settingsFilePath;
	private static String settingsFileName;
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
			FileInputStream fis = new FileInputStream(settingsFilePath);
            properties.load(fis);
            fis.close();
            
        } catch (IOException e) {
            System.err.println("ERROR: There is no such file!");
        }
	}
	
	public static void SaveProperties() {
		try {
			FileOutputStream fos = new FileOutputStream(settingsFilePath);
            properties.store(fos, null);
            fos.close();
            
        } catch (IOException e) {
            System.err.println("ERROR: There is no such file!");
        }
	}
	
	public static void ImplementSettings() {
		String logging = properties.getProperty("main.logging");
        
		if(logging.equals("1"))
        	LoggerService.Enable();
        else
        	LoggerService.Disable();
	}
}
