using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.Collections.Generic;

public class MyGame : Game
{
	
	public float border = 60;

	Ball ball;
	Platform platform;
	Brick brick;
	public Line leftXBoundary;
	public Line rightXBoundary;
	public Line topYBoundary;
	public Line diagonalLeftBoundary;
	public Line diagonalRightBoundary;
	public List<Line> lines;
	public List<Brick> bricks;

	public MyGame() : base(800, 600, false)		// Create a window that's 800x600 and NOT fullscreen
	{

		//placement = new BrickPlacement(new Vec2(border + border, border + border), new Vec2(width, height), this.width, this.height);

		lines = new List<Line>();
		bricks = new List<Brick>();

		//Straigh borders
		leftXBoundary = new Line(new Vec2(border, height - border), new Vec2(border, border + 100));
		lines.Add(leftXBoundary);
		rightXBoundary = new Line(new Vec2(width-border, border+100), new Vec2(width-border, height-border));
		lines.Add(rightXBoundary);
		topYBoundary = new Line(new Vec2(border+100,border), new Vec2(width-border- 100, border));
		lines.Add(topYBoundary);
		//Diagonal borders
		diagonalLeftBoundary = new Line(new Vec2(border,border+100), new Vec2(border+100, border));
		lines.Add(diagonalLeftBoundary);
		diagonalRightBoundary = new Line(new Vec2(width - border - 100, border), new Vec2(width - border, border + 100));
		lines.Add(diagonalRightBoundary);

		foreach (Line line in lines)
        {
			AddChild(line);
        }


		platform = new Platform(100, 10, new Vec2(width / 2, height - border));
		AddChild(platform);

		ball = new Ball(10, new Vec2(width/2, height/2), platform);
		AddChild(ball);

		for (int i = 165; i < 600; i+=60)
        {
			for (int j = 100; j <300; j += 30)
            {
				brick = new Brick(50, 20, new Vec2(i, j), ball);
				bricks.Add(brick);
				AddChild(brick);
			}
		}
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