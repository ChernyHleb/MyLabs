package application;
	
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
			
			
			Parent root = FXMLLoader.load(getClass().getResource("mainView.fxml"));
			mainWindow.setTitle("Lab 3");
			Scene scene = new Scene(root, 900, 400);
			mainWindow.setScene(scene);
			mainWindow.show();
		} catch(Exception e) {
			e.printStackTrace();
		}
	}
	
	public static void main(String[] args) {
		launch(args);
	}
}
