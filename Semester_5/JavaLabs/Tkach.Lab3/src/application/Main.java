package application;
	
import java.io.IOException;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.stage.Stage;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.layout.BorderPane;

public class Main extends Application {
	
	public Stage mainWindow;
	public Scene insertStudentScene;
	public Scene insertParentScene;
	
	@Override
	public void start(Stage primaryStage) {
		try {
			mainWindow = primaryStage;
			mainWindow.setTitle("Lab 3");
			//setMainView();
			setLoginView();
		} catch(Exception e) {
			e.printStackTrace();
		}
	}
	
	public void setLoginView() {
		try {
			Parent root;
			root = FXMLLoader.load(getClass().getResource("loginView.fxml"));
			Scene scene = new Scene(root, 300, 100);
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
	
	public static void main(String[] args) {
		launch(args);
	}
}
