using GXPEngine;

class SpaceShip : Sprite 
{
	public Vec2 position 
	{
		get {
			return _position;
		}
	}
	Vec2 _velocity;
	Vec2 _acceleration;

	Vec2 _position;

	float _accelerationStrength=0.3f;
	float _friction=0.02f;

	public SpaceShip(float pX, float pY) : base("../../../assets/spaceship.png") 
	{
		SetOrigin (width / 2, height / 2);
		_position.x = pX;
		_position.y = pY;
		UpdateScreenPosition ();
	}

	void UpdateScreenPosition() 
	{
		x = _position.x;
		y = _position.y;
	}

	// Aim at mouse (without using Vec2 - fix this!)
	void Aim() 
	{
		// Get the delta vector to mouse:
		float dx = Input.mouseX - _position.x;
		float dy = Input.mouseY - _position.y;

		// Get angle to mouse, convert from radians to degrees:
		float targetAngle = Mathf.Atan2(dy,dx) * 180 / Mathf.PI;

		if (!(Input.GetKey(Key.LEFT_SHIFT) || Input.GetKey(Key.RIGHT_SHIFT))) 
		{ // Shift not pressed: Directly aim at mouse
			rotation = targetAngle;
		} else 
		{ // Shift pressed: Ease towards mouse position - but not in a good way! (Solve this for assignment 2)
			if (targetAngle > rotation+0.5f) 
			{
				rotation++;
			} else if (targetAngle<rotation-0.5f) 
			{
				rotation--;
			}
		}
	}

	// Use keyboard input to turn
	void Turn() 
	{
		if (Input.GetKey (Key.LEFT)) 
		{
			rotation--;
		}
		if (Input.GetKey (Key.RIGHT)) 
		{
			rotation++;
		}
	}

	// Accelerate in current direction if forward is pressed, and apply friction to velocity to slow down.
	void Move() 
	{
		if (Input.GetKey (Key.UP)) 
		{ 
			// move in the direction we're currently facing
			float angleRadians = rotation * Mathf.PI / 180;

			_acceleration = new Vec2(Mathf.Cos(angleRadians) * _accelerationStrength, Mathf.Sin(angleRadians) * _accelerationStrength);			
		} else {
			_acceleration = new Vec2(0, 0);
		}

		// friction: "accelerate" in the opposite direction of the current velocity:
		_acceleration += _velocity * -_friction;
	}

	public void Update() 
	{
		if (Input.GetMouseButton(0)) 
		{
			Aim ();
		} else 
		{
			Turn ();
		}
		Move ();

		// Euler integration with acceleration:
		_velocity += _acceleration;
		_position += _velocity;

		UpdateScreenPosition ();
	}
}
