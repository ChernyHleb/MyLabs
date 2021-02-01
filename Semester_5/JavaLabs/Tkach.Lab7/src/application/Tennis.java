package application;

import javafx.animation.KeyFrame;
import javafx.animation.Timeline;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;
import javafx.util.Duration;

public class Tennis extends Application{

	private static double width;
	private static double height;
	private static double player_height;
	private static double player_width;
	private static double ball_radius;
	
	private double ball_XSpeed;
	private double ball_YSpeed;
	private double ball_XPosition;
	private double ball_YPosition;
	
	private double player1_XPosition;
	private double player1_YPosition;
	private int player1_score = 0;
	
	private double player2_XPosition;
	private double player2_YPosition;
	private int player2_score = 0;
	
	private boolean game_started;
	
	static {
		Tennis.width = 800;
		Tennis.height = 600;
		Tennis.player_height = 100;
		Tennis.player_width = 15;
		Tennis.ball_radius = 15;
	}
	
	@Override
	public void init() throws Exception {
		// инициализация переменных
		this.ball_XSpeed = 1;
		this.ball_YSpeed = 1;
		this.ball_XPosition =  Tennis.width / 2;
		this.ball_YPosition = Tennis.height / 2;
		
		this.player1_XPosition = 0;
		this.player1_YPosition = Tennis.height / 2;
		this.player1_score = 0;
		
		this.player2_XPosition = Tennis.width - Tennis.player_width;
		this.player2_YPosition = Tennis.height / 2;
		this.player2_score = 0;
		
		this.game_started = false;
		
		super.init();
	}
	
	@Override
	public void start(Stage stage) throws Exception {
		stage.setTitle("Lab7");
		Canvas canvas = new Canvas(width, height);
		GraphicsContext  graphicsContext = canvas.getGraphicsContext2D();
		Timeline timeLine = new Timeline(new KeyFrame(Duration.millis(10), e->run(graphicsContext)));
		timeLine.setCycleCount(Timeline.INDEFINITE);
		
		// контроль мышки
		canvas.setOnMouseMoved(e -> player1_YPosition = e.getY());
		canvas.setOnMouseClicked(e -> game_started = true);
		stage.setScene(new Scene(new StackPane(canvas)));
		stage.show();
		timeLine.play();
	}
	
	private void run(GraphicsContext graphicsContext) {
		
	}
}
