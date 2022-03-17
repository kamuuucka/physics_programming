using System;
using System.Drawing;
using System.Collections.Generic;

namespace GXPEngine
{
	public class PhaseOffset:Game
	{
		private List<Sprite> _balls;

		private float cosTime = 500;
		private float sinTime = 500;
		private float cosOffset = 0.1f;
		private float sinOffset = 0.1f;

		private float frameCounter = 0;

		private Random rnd = new Random();

		public PhaseOffset ():base (800,600, false,false)
		{
			EasyDraw canvas = new EasyDraw(200, 50);
			canvas.Fill(100);
			canvas.Text("Press SPACE\n to randomize",0,canvas.height);
			canvas.SetOrigin(100, 25);
			canvas.SetXY(game.width/2, game.height/2);
			AddChild(canvas); 


			_balls = new List<Sprite> ();
			for (int i = 0; i < 80; i++) {
				_balls.Add (createBall ());
			}
		}

		Sprite createBall ()
		{
			Sprite ball = new Sprite ("../../../assets/ball_large.png");
			ball.SetOrigin (ball.width / 2, ball.height / 2);
			AddChild (ball);
			return ball;
		}

		void Update () {
			frameCounter++;

			for (int i = 0; i < 80; i++) {
				_balls[i].x = game.width/2 + (float)(0.5f * (game.width-100) * Math.Cos (frameCounter/cosTime + cosOffset*i*2*Math.PI)); 
				_balls[i].y = game.height/2 + (float)(0.5f * (game.height-100) * Math.Sin(frameCounter/sinTime + sinOffset*i*2*Math.PI)); 
			}

			if (Input.GetKeyDown (Key.SPACE)) {
				cosTime = rnd.Next (50, 100);
				sinTime = rnd.Next (50, 100);
				cosOffset = rnd.Next(1,8)/80.0f;
				sinOffset = rnd.Next(1,8)/80.0f;
			}
		}

	}
}