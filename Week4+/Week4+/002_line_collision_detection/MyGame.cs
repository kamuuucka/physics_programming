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

		//TEST Reflect()
		Vec2 v = new Vec2(-3,4);
		Vec2 n = new Vec2(6, 0);
		v.Reflect(n.Normal());
		Console.WriteLine(v.ToString());

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
		float ballDistance = 0;   //HINT: it's NOT 10000

		Vec2 diffVector = _ball.position - _lineSegment.start;
		Vec2 line = _lineSegment.end - _lineSegment.start;
		ballDistance = diffVector.Dot(line.Normal());

		//update ball position
		if (ballDistance < _ball.radius)
        {
			_ball.position -= line.Normal() * (ballDistance - _ball.radius);
			_ball.velocity.Reflect(line.Normal());
        }

		//compare distance with ball radius
		if (ballDistance < _ball.radius) {
			_ball.SetColor (1, 0, 0);
		} else {
			_ball.SetColor (0, 1, 0);
		}

		_ball.UpdateScreenPosition();

		_text.Clear (Color.Transparent);
		_text.Text("Distance to line: "+ballDistance, 0, 0);
	}
}
