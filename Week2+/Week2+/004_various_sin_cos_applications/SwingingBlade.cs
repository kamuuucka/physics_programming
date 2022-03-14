using System;
using GXPEngine;
using System.Drawing;

public class SwingingBlade : Game
{	
	private Sprite _blade1 = null;
	private Sprite _blade2 = null;
	private Sprite _blade3 = null;

	private float _direction = 1;

	public SwingingBlade () : base(800, 600, false, false)
	{
		_blade1 = new Sprite ("../../../assets/pendulum.png");
		_blade1.SetOrigin (_blade1.width / 2, 0);
		AddChild (_blade1);
		_blade1.x = width / 4;
		_blade1.y = height -250;
		_blade1.rotation = -50;

		_blade2 = new Sprite ("../../../assets/pendulum.png");
		_blade2.SetOrigin (_blade2.width / 2, 0);
		AddChild (_blade2);
		_blade2.x = width / 2;
		_blade2.y = 50;
		_blade2.rotation = -50;

		_blade3 = new Sprite("../../../assets/pendulum.png");
		_blade3.SetOrigin(_blade3.width / 2, 0);
		AddChild(_blade3);
		_blade3.x = 3 * width / 4;
		_blade3.y = height -250;
		_blade3.rotation = -50;
	}

	void Update () {
		DoConstantRotation (_blade1);
		DoSinRotation (_blade2);
		DoGravityAcceleration (_blade3);
	}
		
	/**
	 * Uses direction -1 vs 1 to rotate the blade at a constant rate, switching direction at specific angle.
	 */
	void DoConstantRotation(Sprite target) {
		target.rotation += _direction;

		if (Math.Abs (target.rotation) > 50) {
			_direction *= -1;
		}
	}

	/**
	 */
	void DoSinRotation (Sprite target) {
		//radius * sin output, phase offset of mathf.pi is used to synch with the other implementation
		target.rotation = 40 * Mathf.Sin (Time.time / 200.0f);
	}


	float vr = 0.5f;

	/**
	 * This one is a little bit trickier and the subject of lecture 3.
	 * Basically we calculate the downward acceleration and set that as a rotational velocity.
	 */
	void DoGravityAcceleration (Sprite target) {
		//if we are rotated we have downward acceleration, if angle is 0, rotation velocity is 0
		float ar = -Mathf.Sin(target.rotation * Mathf.PI/180)/5;
		vr += ar;
		target.rotation += vr;
	}


}




















































