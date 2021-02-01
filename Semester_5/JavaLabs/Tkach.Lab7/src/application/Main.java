package application;

import java.util.Random;

import javafx.animation.KeyFrame;
import javafx.animation.Timeline;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.layout.StackPane;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;
import javafx.scene.text.TextAlignment;
import javafx.stage.Stage;
import javafx.util.Duration;

public class Main extends Application{

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
		Main.width = 800;
		Main.height = 600;
		Main.player_height = 100;
		Main.player_width = 15;
		Main.ball_radius = 15;
	}
	
	@Override
	public void init() throws Exception {
		// инициализация переменных
		this.ball_XSpeed = 1;
		this.ball_YSpeed = 1;
		this.ball_XPosition =  Main.width / 2;
		this.ball_YPosition = Main.height / 2;
		
		this.player1_XPosition = 0;
		this.player1_YPosition = Main.height / 2;
		this.player1_score = 0;
		
		this.player2_XPosition = Main.width - Main.player_width;
		this.player2_YPosition = Main.height / 2;
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
		// установка цвета фона
		graphicsContext.setFill(Color.BLACK);
		graphicsContext.fillRect(0, 0, Main.width, Main.height);
		
		// установка цвета текста
		graphicsContext.setFill(Color.WHITE);
		graphicsContext.setFont(Font.font(25));
		
		// логика игры
		if(game_started) {
			// установка движения мяча
			this.ball_XPosition += this.ball_XSpeed;
			this.ball_YPosition += this.ball_YSpeed;
			
			// комп
			if(this.ball_XPosition < Main.width - Main.width / 4) {
				this.player2_YPosition = this.ball_YPosition - this.player_height / 2;
			} else {
				this.player2_YPosition = this.ball_YPosition > this.player2_YPosition + this.player_height / 2 
						? this.player2_YPosition ++ 
						: this.player2_YPosition --;
			}
			// отрисовка мяча
			graphicsContext.fillOval(this.ball_XPosition, 
									 this.ball_YPosition, 
									 this.ball_radius,
									 this.ball_radius
									 );
		} else {
			// установка начального текста
			graphicsContext.setStroke(Color.WHITE);
			graphicsContext.setTextAlign(TextAlignment.CENTER);
			graphicsContext.strokeText("Click to start!", Main.width / 2, Main.height / 2);
		
			// начальная позиция мяча
			this.ball_XPosition = this.width / 2;
			this.ball_YPosition = this.height / 2;
			
			// скорость и направление
			this.ball_XSpeed = new Random().nextDouble() == 0 ? 1 : -1;
			this.ball_YSpeed = new Random().nextDouble() == 0 ? 1 : -1;
		}
		
	}
}

