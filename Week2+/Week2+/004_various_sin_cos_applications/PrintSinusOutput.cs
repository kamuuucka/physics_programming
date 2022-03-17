using System;
using System.Drawing;

namespace GXPEngine
{
	public class PrintSinusOutput:Game
	{
		private float currentFrame = 0;
		private float framesPer2PI = 300;

		EasyDraw canvas;

		public PrintSinusOutput ():base (800,600, false)
		{
			canvas = new EasyDraw(game.width, game.height);
			AddChild(canvas);
		}

		void Update () {
			float sinValue = Mathf.Sin((currentFrame++ / framesPer2PI) * 2 * Mathf.PI);

			canvas.Ellipse(currentFrame, game.height/2 - sinValue * 200, 1, 1);

			Console.WriteLine (
				currentFrame +" | "+framesPer2PI + " | "+ sinValue
			);
		}

	}
}
