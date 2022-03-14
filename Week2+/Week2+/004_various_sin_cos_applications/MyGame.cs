using System;
using System.Drawing;

namespace GXPEngine
{
	public class MyGame
	{
		static void Main() {

			// Choose your example here:

			//new CircularMotion ().Start ();			//Shows different ways to generate circular motion
			//new PhaseOffset ().Start (); 				//Shows ways to use multiple objects and phase shifts between them
			//new OtherProperties ().Start ();			//Shows ways to use trig functions to update other properties
			new SwingingBlade().Start();				//Shows different ways of implementing a pendulum motion 
			//new PrintSinusOutput().Start();				//Just prints sine values to console and draws a sine wave
		}

	}
}

