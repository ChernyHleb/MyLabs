package application;
	
import java.io.IOException;

import Services.LoggerService;
import Services.ProgramSettingsService;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.stage.Stage;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.image.Image;

public class Main extends Application {
	
	public Stage mainWindow;
	public Scene insertStudentScene;
	public Scene insertParentScene;
	
	@Override
	public void start(Stage primaryStage) {
		try {
			ProgramSettingsService.LoadProperties();
			ProgramSettingsService.ImplementSettings();
			mainWindow = primaryStage;
			mainWindow.setTitle("Lab 4,5");
			setLoginView();
		} catch(Exception e) {
			e.printStackTrace();
		}
	}
	
	public void setLoginView() {
		try {
			Parent root;
			root = FXMLLoader.load(getClass().getResource("loginView.fxml"));
			Scene scene = new Scene(root, 300, 120);
			mainWindow.setScene(scene);
			mainWindow.show();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public void setMainView() {
		try {
			Parent root;
			root = FXMLLoader.load(getClass().getResource("mainView.fxml"));
			Scene scene = new Scene(root, 900, 400);
			mainWindow.setScene(scene);
			mainWindow.show();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	@Override
	public void stop(){
	    LoggerService.WriteToLog("APPLICAITON STOPPED\n~~~\n");
	    ProgramSettingsService.SaveProperties();
	}
	
	public static void main(String[] args) {
		launch(args);
	}
}
