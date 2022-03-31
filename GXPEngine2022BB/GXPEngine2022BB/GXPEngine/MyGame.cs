using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;							// System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game
{
	
	float border = 60;

	Ball ball;
	Line leftXBoundary;

	public MyGame() : base(800, 600, false)		// Create a window that's 800x600 and NOT fullscreen
	{
		leftXBoundary = new Line(new Vec2(border, border), new Vec2(border, height - border));
		AddChild(leftXBoundary);
		Line rightXBoundary = new Line(new Vec2(width-border, border), new Vec2(width-border, height-border));
		AddChild(rightXBoundary);
		Line topYBoundary = new Line(new Vec2(border,border), new Vec2(width-border, border));
		AddChild(topYBoundary);

		ball = new Ball(30, new Vec2(width/2, height/2));
		AddChild(ball);

	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		ball.Step();
		float ballDistance = 0;   //HINT: it's NOT 10000

		Vec2 diffVector = ball.position - leftXBoundary.start;
		Vec2 line = leftXBoundary.start - leftXBoundary.end;
		ballDistance = diffVector.Dot(line.Normal());

		//update ball position
		if (ballDistance < ball.radius)
		{
			ball.SetColor(1, 0, 0);
			ball.position -= line.Normal() * (ballDistance - ball.radius);
		}
		else
        {
			ball.SetColor(0, 1, 0);
        }

		ball.UpdateScreenPosition();
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}




}