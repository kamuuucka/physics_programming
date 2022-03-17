using GXPEngine;

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

	public Tank(float px, float py) : base("assets/bodies/t34.png") 
	{
		_position.x = px;
		_position.y = py;
		barrel = new Barrel();

		SetOrigin(width/2, height/2);

		AddChild (barrel);
	}

	void Controls() 
	{
		if (Input.GetKey (Key.LEFT)) 
		{
			rotation++;
		}
		if (Input.GetKey (Key.RIGHT)) 
		{
			rotation--;
		}
		if (Input.GetKey (Key.UP)) 
		{
			velocity += new Vec2 (0.1f, 0);
		}
		if (Input.GetKey (Key.DOWN)) 
		{
			velocity += new Vec2 (-0.1f, 0);
		}
	}

	void Shoot() {
		if (Input.GetKeyDown (Key.SPACE)) 
		{
			AddChild (new Bullet (new Vec2 (0, 0), new Vec2 (1, 0)));
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
