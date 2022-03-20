using GXPEngine;
using System;

class Barrel : Sprite 
{
	public Vec2 direction;
	Vec2 mouse;
	Vec2 position;
	float targetAngle;
	public Barrel(float px, float py) : base("assets/barrels/t34.png") 
	{
        position.x = px;
        position.y = py;
        SetOrigin(width/3, height/2);
		
		Console.WriteLine(x + " " + y);
		rotation = 90;
	}

	public void Update() 
	{
		targetAngle = DeltaMouse().GetAngleDegrees();
		
		rotation = targetAngle;
		direction = Vec2.GetUnitVectorDeg(rotation);
    }

	private Vec2 DeltaMouse()
    {
		Vec2 delta;
		mouse = new Vec2(Input.mouseX, Input.mouseY);
		delta = mouse - position;
		delta.Normalized();
        return delta;
	}
}
