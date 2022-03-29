using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{	

	static void Main() {
		new MyGame().Start();
	}

	Ball _ball;

	EasyDraw _text;

	NLineSegment _lineSegment;

	public MyGame () : base(800, 600, false,false)
	{
		_ball = new Ball (30, new Vec2 (width / 2, height / 2));
		AddChild (_ball);

		_text = new EasyDraw (250,25);
		_text.TextAlign (CenterMode.Min, CenterMode.Min);
		AddChild (_text);

		_lineSegment = new NLineSegment (new Vec2 (500, 500), new Vec2 (100, 200), 0xff00ff00, 3);
		AddChild(_lineSegment);
	}

	void Update () {
		// For now: this just puts the ball at the mouse position:
		_ball.Step ();

		//TODO: calculate correct distance from ball center to line
		float ballDistance = 10000;   //HINT: it's NOT 10000

		//compare distance with ball radius
		if (ballDistance < _ball.radius) {
			_ball.SetColor (1, 0, 0);
		} else {
			_ball.SetColor (0, 1, 0);
		}

		_text.Clear (Color.Transparent);
		_text.Text("Distance to line: "+ballDistance, 0, 0);
	}
}

