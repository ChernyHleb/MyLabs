package application;
	
import java.beans.Expression;
import java.io.IOException;
import java.util.ArrayList;

import Services.LoggerService;
import Services.ProgramSettingsService;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.stage.Stage;
import javafx.scene.Parent;
import javafx.scene.Scene;

public class Main extends Application {
	
	public Stage mainWindow;
	public Scene insertStudentScene;
	public Scene insertParentScene;
	//!!!! TRY TO MAKE LAMBDA CHANGE LIST
	public void lol(Expression e) {
		try {
			e.execute();
		} catch (Exception e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}
	}
	
	@Override
	public void start(Stage primaryStage) {
		try {
			/////!!! TRY TO PASS LAMBDA
			ArrayList<String> jojo = new ArrayList<String> ();
			jojo.add("ses");
			lol((jojo)->jojo.add("kok"));
			
			
			ProgramSettingsService.LoadProperties();
			ProgramSettingsService.ImplementSettings();
			mainWindow = primaryStage;
			mainWindow.setTitle("Lab 3");
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
	}
	
	public static void main(String[] args) {
		launch(args);
	}
}
