package application;

public class Ball extends Thread{
	public Ball() {
		
	}
	
	public void run() {
		
		while(true) {
			try {
				this.sleep(100);
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			if(Main.game_started) {
				if(((Main.ball_XPosition + Main.ball_radius > Main.player2_XPosition) &&
						Main.ball_YPosition >= Main.player2_YPosition &&
						Main.ball_YPosition <= Main.player2_YPosition + Main.player_height)
						||
						((Main.ball_XPosition < Main.player1_XPosition + Main.player_width) &&
								Main.ball_YPosition >= Main.player1_YPosition &&
								Main.ball_YPosition <= Main.player1_YPosition + Main.player_height)) {
					
					Main.ball_YSpeed += 0.5 * Math.signum(Main.ball_YSpeed);
					Main.ball_XSpeed += 0.5 * Math.signum(Main.ball_XSpeed);
					//this.ball_YSpeed *= -1;
					Main.ball_XSpeed *= -1;
				}
			}
		}
	}
}
