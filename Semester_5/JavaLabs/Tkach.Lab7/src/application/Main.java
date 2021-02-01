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

	public static volatile Double width;
	public static volatile Double height;
	public static volatile Double player_height;
	public static volatile Double player_width;
	public static volatile Double ball_radius;
	
	public static volatile Double ball_XSpeed;
	public static volatile Double ball_YSpeed;
	public static volatile Double ball_XPosition;
	public static volatile Double ball_YPosition;
	
	public static volatile Double player1_XPosition;
	public static volatile Double player1_YPosition;
	public static volatile Integer player1_score = 0;
	
	public static volatile Double player2_XPosition;
	public static volatile Double player2_YPosition;
	public static volatile Integer player2_score = 0;
	
	public static volatile Boolean game_started;
	
	static {
		Main.width = 800.0;
		Main.height = 600.0;
		Main.player_height = 100.0;
		Main.player_width = 15.0;
		Main.ball_radius = 15.0;
		
		Main.ball_XSpeed = 1.0;
		Main.ball_YSpeed = 1.0;
		Main.ball_XPosition =  Main.width / 2;
		Main.ball_YPosition = Main.height / 2;
		
		Main.player1_XPosition = 0.0;
		Main.player1_YPosition = Main.height / 2;
		Main.player1_score = 0;
		
		Main.player2_XPosition = Main.width - Main.player_width;
		Main.player2_YPosition = Main.height / 2;
		Main.player2_score = 0;
		
		Main.game_started = false;
	}
	
	@Override
	public void start(Stage stage) throws Exception {
		stage.setTitle("Lab7");
		Canvas canvas = new Canvas(width, height);
		GraphicsContext  graphicsContext = canvas.getGraphicsContext2D();
		
		Timeline timeLine = new Timeline(new KeyFrame(Duration.millis(10), e->{run(graphicsContext);}));
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
			// установка движени€ м€ча
			this.ball_XPosition += this.ball_XSpeed;
			this.ball_YPosition += this.ball_YSpeed;
			
			// комп
			if(this.ball_XPosition < Main.width - Main.width / 4) {
				this.player2_YPosition = this.ball_YPosition - this.player_height / 2;
			} else {
				this.player2_YPosition = this.ball_YPosition > this.player2_YPosition + this.player_height / 2
						? this.player2_YPosition + Math.abs(this.ball_YSpeed)
						: this.player2_YPosition - Math.abs(this.ball_YSpeed);
			}
			// отрисовка м€ча
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
		
			// начальна€ позици€ м€ча
			this.ball_XPosition = this.width / 2;
			this.ball_YPosition = this.height / 2;
			
			// скорость и направление
			this.ball_XSpeed = new Random().nextInt(2) == 0 ? 1.0 : -1.0;
			this.ball_YSpeed = new Random().nextInt(2) == 0 ? 1.0 : -1.0;
		}
		// м€ч должен оставатьс€ на канвасе
		if (this.ball_YPosition > this.height ||
			this.ball_YPosition < 0) {
			this.ball_YSpeed *= -1;
		}
			
		// если м€ч упущен то комп получает очко
		if(this.ball_XPosition < this.player1_XPosition - this.player_width) {
			this.player2_score ++;
			this.game_started = false;
		}
			
		// игрок получает очко
		if(this.ball_XPosition > this.player2_XPosition + this.player_width) {
			this.player1_score ++;
			this.game_started = false;
		}
			
		
			
		// увеличить скорость м€ча
		if(((this.ball_XPosition + this.ball_radius > this.player2_XPosition) &&
			this.ball_YPosition >= this.player2_YPosition &&
			this.ball_YPosition <= this.player2_YPosition + this.player_height)
			||
			  ((this.ball_XPosition < this.player1_XPosition + this.player_width) &&
			this.ball_YPosition >= this.player1_YPosition &&
			this.ball_YPosition <= this.player1_YPosition + this.player_height)) {
				
			this.ball_YSpeed += 0.5 * Math.signum(this.ball_YSpeed);
			this.ball_XSpeed += 0.5 * Math.signum(this.ball_XSpeed);
			//this.ball_YSpeed *= -1;
			this.ball_XSpeed *= -1;
		}
			
		// отрисовка очков
		graphicsContext.fillText(this.player1_score + "\t\t\t\t" + "Speed:" + Math.abs(this.ball_YSpeed) + "\t\t\t\t" + this.player2_score, 
								 this.width / 2, 
								 100);
		// отрисовка игроков
		graphicsContext.fillRect(this.player1_XPosition, 
								 this.player1_YPosition, 
								 this.player_width,
								 this.player_height
								 );
		graphicsContext.fillRect(this.player2_XPosition, 
				 				 this.player2_YPosition, 
				 				 this.player_width,
				 				 this.player_height
				 				);
		
	}
	
	@Override
	public void stop(){
		
	}
}

