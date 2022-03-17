using System;
using System.Drawing;
using GXPEngine;

public class RotatingSpaceship : Game
{
	Sprite _spaceship;
	EasyDraw _text;
	bool _autoRotate=false;
	bool _move=false;

	public RotatingSpaceship ():base (800,600, false, false)
	{
		_spaceship = new Sprite ("../../../assets/spaceship.png");
		_spaceship.SetOrigin (_spaceship.width / 2, _spaceship.height / 2);
		_spaceship.SetXY (width / 2, height / 2);
		AddChild (_spaceship);

		_spaceship.rotation = 0;

		_text = new EasyDraw (200,20);
		_text.TextAlign (CenterMode.Min, CenterMode.Min);
		_text.Text ("Rotation: 0",0,0);
		AddChild (_text);
	}

	void Update () {
		if (Input.GetKeyDown (Key.F1)) {
			_autoRotate ^= true;
		}
		if (Input.GetKeyDown (Key.F2)) {
			_move ^= true;
		}

		if (Input.GetKeyDown (Key.SPACE)) {
			_spaceship.rotation += 45;
		}

		if (_autoRotate) {
			_spaceship.rotation++;
		} 

		// move in current direction:
		if (_move) {
			_spaceship.Move (1, 0);
		}

		_text.Clear (Color.Transparent);
		_text.Text("Rotation:" + _spaceship.rotation,0,0);
	}

	static void Main() {
		new RotatingSpaceship ().Start ();
	}
}