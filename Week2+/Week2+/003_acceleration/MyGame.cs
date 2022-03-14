using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	Sprite _spaceship;
	EasyDraw _text;

	public MyGame ():base (800,600, false, false)
	{
		_spaceship = new SpaceShip (width / 2, height / 2);
		AddChild (_spaceship);

		_text = new EasyDraw (200,20);
		_text.TextAlign (CenterMode.Min, CenterMode.Min);
		_text.Text ("Rotation: 0",0,0);
		AddChild (_text);
	}

	void Update () 
	{
		_text.Clear (Color.Transparent);
		_text.Text("Rotation:" + _spaceship.rotation,0,0);
	}

	static void Main() 
	{
		Console.WriteLine ("Instructions:\n Use arrow keys to turn/move forward.\n Press the left mouse button to aim at the mouse.\n Press shift + left mouse button to ease towards the mouse.");

		new MyGame ().Start ();
	}
}