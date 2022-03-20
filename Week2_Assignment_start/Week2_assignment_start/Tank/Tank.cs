using GXPEngine;
using System;

// TODO: Fix this mess! - see Assignment 2.2
class Tank : Sprite 
{
	// public fields & properties:
	public Vec2 position 
	{
		get 
		{
			return _position;
		}
	}
	public Vec2 velocity;

	// private fields:
	Vec2 _position;
	Barrel barrel;
	float speed;
	float speed_max = 5f;
	Vec2 direction = new Vec2(0, 0);

	public Tank(float px, float py) : base("assets/bodies/t34.png") 
	{
		_position.x = px;
		_position.y = py;
		SetOrigin(width/2, height/2);
		barrel = new Barrel(px, py);
		AddChild (barrel);
	}

	void Controls() 
	{
		if (speed!=0) // never do float comparisons!
        {
			if (Input.GetKey(Key.LEFT))
			{
				rotation+=speed*0.3f;
			}
			if (Input.GetKey(Key.RIGHT))
			{
				rotation-=speed*0.3f;
			}
		}
		
		if (Input.GetKey(Key.UP)) 
		{
			speed += 0.1f;
			
		}
		else if (Input.GetKey (Key.DOWN)) 
		{
			speed -= 0.1f;
			
		}
        else
        {
			if (speed > 0)
            {
				speed -= 0.1f;
				
			}
            else if (speed < 0)
            {
                speed += 0.1f;
				
			} 
        }

		if (speed >= speed_max) speed = speed_max;
		if (speed <= -speed_max) speed = -speed_max;

		direction = Vec2.GetUnitVectorDeg(rotation);
		velocity = direction * speed;

	}

	void Shoot() {
		if (Input.GetKeyDown (Key.SPACE)) 
		{
			AddChild (new Bullet (barrel.direction*20, barrel.direction));
		}
	}

	void UpdateScreenPosition() 
	{
		x = _position.x;
		y = _position.y;
	}

	public void Update() 
	{
		Controls ();
		// Basic Euler integration:
		_position += velocity;
		Shoot ();
		UpdateScreenPosition ();
	}
}
