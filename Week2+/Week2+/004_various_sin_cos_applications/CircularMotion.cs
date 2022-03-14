using System;
using System.Drawing;

namespace GXPEngine
{
	public class CircularMotion:Game
	{
		private Sprite _ball;

		private float _radians;
		private float _radius;

		public CircularMotion ():base (800,600, false,false)
		{
			_ball = new Sprite ("../../../assets/ball_large.png");
			_ball.SetOrigin (_ball.width / 2, _ball.height / 2);
			AddChild (_ball);

			_radians = 0;
		}

		void Update () {

			//Print the calculated x and y for a radius of 100 and the current amount of radians

			//change this number to increase circle size
			_radius = 100;

			//change this number to go faster/slower
			_radians += 0.05f;

			//multiply _radians for weird effects
			float myX = _radius * Mathf.Cos (_radians);
			float myY = _radius * Mathf.Sin (_radians);

			//if (false)
			Console.WriteLine (
				"   RADIUS:"	  					+ _radius +
				" \t| RADIANS:  " 					+ _radians.ToString("F") +
				" \t| X = radius * cos (radians):" 	+ myX.ToString("F5") +
				" \t| Y = radius * sin (radians):"	+ myY.ToString("F5")
			);

			/**/
			//moves ball in a circle with _radius around the origin
			_ball.x = myX;
			_ball.y = myY;

			//moves ball in a circle with _radius around screen center:
			/**/

			_ball.x += game.width/2;
			_ball.y += game.height/2;

			/**
			//What if you want to go round in a specific number of steps?
			float numberOfSteps = 8;
			float increasePerStep = (2 * Mathf.PI) / numberOfSteps;

			if (Input.GetKeyDown (Key.SPACE)) {
				_radians += increasePerStep;

				Console.WriteLine ("Direction: {0}, {1}", Mathf.Cos (_radians), Mathf.Sin (_radians));
			}
			/**/
		}

	}
}