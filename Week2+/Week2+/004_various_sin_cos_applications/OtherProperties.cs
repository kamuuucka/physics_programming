using System;
using System.Drawing;

namespace GXPEngine
{
	public class OtherProperties:Game
	{
		private float _radians;
		private float _radius;

		private Sprite _spaceship;

		public OtherProperties ():base (800,600, false,false)
		{
			_spaceship = new Sprite ("../../../assets/spaceship.png");
			_spaceship.SetOrigin (_spaceship.width / 2, _spaceship.height / 2);
			_spaceship.SetXY (width / 2, height / 2);
			AddChild (_spaceship);
		}

		void Update() {
			float scale = 0;

			/**

			//update the scale based on cos
			//scale from -1 to 1
			_radius = 1;
			scale = _radius * Mathf.Cos (_radians);
			_spaceship.SetScaleXY (scale, scale);

			/**

			//scale from 0 to 1 with bounce
			_radius = 1;
			scale = _radius * Math.Abs (Mathf.Cos (_radians));
			_spaceship.SetScaleXY (scale, scale);

			/**

			//scale from 0.5 to 1 with bounce
			_radius = 0.5f;
			scale = 0.5f + _radius * Math.Abs (Mathf.Cos (_radians));
			_spaceship.SetScaleXY (scale, scale);

			/**/

			//scale from 0.5 to 1 without bounce
			_radius = 0.05f;
			scale = (1-_radius) + _radius * Mathf.Cos (_radians);
			_spaceship.SetScaleXY (scale, scale);

			/**/

			//color magic
			float r = Mathf.Abs (Mathf.Cos (Time.time/700.0f));
			float g = Mathf.Abs (Mathf.Cos (Time.time/1100.0f));
			float b = Mathf.Abs (Mathf.Cos (Time.time/1700.0f));
			_spaceship.SetColor (r, g, b);

			/**/

			//speed of the effect
			_radians += 0.1f;
		}



	}
}