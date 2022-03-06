﻿using System;
using GXPEngine;

public class Ball : EasyDraw
{
	public Vec2 position {
		get {
			return _position;
		}
	}
	public Vec2 velocity;

	int _radius;
	Vec2 _position;
	float _speed;

	public Ball (int pRadius, Vec2 pPosition, float pSpeed=5) : base (pRadius*2 + 1, pRadius*2 + 1)
	{
		_radius = pRadius;
		_position = pPosition;
		_speed = pSpeed;

		UpdateScreenPosition ();
		SetOrigin (_radius, _radius);

		Draw (150, 0, 255);
	}

	void Draw(byte red, byte green, byte blue) {
		Fill (red, green, blue);
		Stroke (red, green, blue);
		Ellipse (_radius, _radius, 2*_radius, 2*_radius);
	}

	void KeyControls() {
		velocity.x = 0;
		velocity.y = 0;

		if (Input.GetKey (Key.RIGHT)) {
			velocity.x += _speed;
		} else if (Input.GetKey (Key.LEFT)) {
			velocity.x -= _speed;
		} 

		if (Input.GetKey (Key.UP)) {
			velocity.y -= _speed;
		} else if (Input.GetKey (Key.DOWN)) {
			velocity.y += _speed;
		}

		//Fixes the speed of ball while it's moving diagonally
		if (velocity.Length() > 5)
        {
			velocity = velocity.Normalized() * 5;
        }
	}

	void UpdateScreenPosition() {
		x = _position.x;
		y = _position.y;
	}

	public void Step () {
		KeyControls ();

		_position += velocity;
		

		UpdateScreenPosition();
	}
}
