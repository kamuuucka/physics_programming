using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;							// System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game
{
	
	public float border = 60;

	Ball ball;
	Platform platform;
	public Line leftXBoundary;
	public Line rightXBoundary;
	public Line topYBoundary;
	public Line diagonalLeftBoundary;
	public Line diagonalRightBoundary;

	public MyGame() : base(800, 600, false)		// Create a window that's 800x600 and NOT fullscreen
	{
		leftXBoundary = new Line(new Vec2(border, border+100), new Vec2(border, height - border));
		AddChild(leftXBoundary);
		rightXBoundary = new Line(new Vec2(width-border, border+100), new Vec2(width-border, height-border));
		AddChild(rightXBoundary);
		topYBoundary = new Line(new Vec2(border+100,border), new Vec2(width-border- 100, border));
		AddChild(topYBoundary);

		diagonalLeftBoundary = new Line(new Vec2(border,border+100), new Vec2(border+100, border));
		AddChild(diagonalLeftBoundary);
		diagonalRightBoundary = new Line(new Vec2(width - border - 100, border), new Vec2(width - border, border + 100));
		AddChild(diagonalRightBoundary);

		platform = new Platform(200, 10, new Vec2(width / 2, height - border));
		AddChild(platform);

		ball = new Ball(10, new Vec2(width/2, height/2), platform);
		AddChild(ball);

		



	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		ball.Step();
		platform.Step();
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}




}