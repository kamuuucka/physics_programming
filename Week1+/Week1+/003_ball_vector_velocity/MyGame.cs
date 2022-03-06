using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{	
	/// <summary>
	/// Method used to test all the functionalities of Vec2 struct
	/// </summary>
	static void DoTest()
    {
		Vec2 v = new Vec2(-8, 6);
		Console.WriteLine("Length ok? {0}", v.Length() == 10);
		Console.WriteLine("Length ok? length = {0} should be 10", v.Length());

		Vec2 myVec = new Vec2(2, 3);
		Vec2 result = myVec * 3;
		Console.WriteLine("Scalar multiplication right ok ?: " + (result.x == 6 && result.y == 9 && myVec.x == 2 && myVec.y == 3));
		Vec2 result1 = 4 * myVec;
		Console.WriteLine("Scalar multiplication left ok ?: " + (result1.x == 8 && result1.y == 12 && myVec.x == 2 && myVec.y == 3));

		Console.WriteLine("Subtraction ok? value = {0} should be -10,3", v - myVec);

		myVec.SetXY(5, 6);
		Console.WriteLine("Setting new values ok? values{0} should be 5,6", myVec);


		Console.WriteLine("Normalization ok? value = {0} should be (-0,8 , 0,6)", v.Normalized());
		Console.WriteLine("Vector value not changed: {0}", v);
		v.Normalize();
		Console.WriteLine("Normalization with change ok? value = {0} should be (-0,8 , 0,6) ",v);
	}

	static void Main() {
		DoTest();
		new MyGame().Start();
		
	}

	private Ball ball;

	private EasyDraw velocityCounter;
	private EasyDraw gameOverText;
	private EasyDraw timerText;

	public MyGame () : base(800, 600, false,false)
	{
		ball = new Ball (30, new Vec2 (width / 2, height / 2));
		AddChild (ball);

		velocityCounter = new EasyDraw (200,25);
		velocityCounter.TextAlign (CenterMode.Min, CenterMode.Min);
		AddChild (velocityCounter);

		gameOverText = new EasyDraw(400, 50);
		gameOverText.TextAlign(CenterMode.Min, CenterMode.Min);
		AddChild(gameOverText);

		timerText = new EasyDraw(400, 50);
		timerText.TextAlign (CenterMode.Min,CenterMode.Min);
		timerText.SetXY(width - 200, 0);
		AddChild (timerText);

	}

	void Update () {
		ball.Step ();

		velocityCounter.Clear (Color.Transparent);
		velocityCounter.Text("Velocity: "+ball.velocity, 0, 0);

		timerText.Clear(Color.Transparent);
		timerText.Text("TIME: " + (int)ball.timer);

		if (ball.GameOver())
        {
			ball.Destroy();
			velocityCounter.Destroy();
			gameOverText.Text("GAME OVER");
			gameOverText.SetXY(width / 2-100, height / 2);
			timerText.SetXY(width / 2-100, height / 2 + 30);
        }
	}
}

