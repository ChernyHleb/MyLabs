package application;

import javafx.application.Application;
import javafx.stage.Stage;

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
	
	static {
		Tennis.width = 800;
		Tennis.height = 600;
		Tennis.player_height = 100;
		Tennis.player_width = 15;
		Tennis.ball_radius = 15;
	}
	
	@Override
	public void init() throws Exception {
		this.ball_XSpeed = 1;
		this.ball_YSpeed = 1;
		this.ball_XPosition =  Tennis.
		
		this.player1_XPosition = 0;
		this.player1_YPosition = Tennis.height / 2;
		this.player1_score = 0;
		
		this.player2_XPosition = Tennis.width - Tennis.player_width;
		this.player2_YPosition = Tennis.height / 2;
		this.player2_score = 0;
		
		
		
		super.init();
	}
	
	@Override
	public void start(Stage arg0) throws Exception {
		// TODO Auto-generated method stub
		
	}
}
