using System;
using GXPEngine; // Allows using Mathf functions

public struct Vec2 
{
	public float x;
	public float y;

	public Vec2 (float pX = 0, float pY = 0) 
	{
		x = pX;
		y = pY;
	}

	public static Vec2 operator+ (Vec2 left, Vec2 right) {
		return new Vec2(left.x+right.x, left.y+right.y);
	}

	public static Vec2 operator* (Vec2 left, float scalar) {
		return new Vec2(left.x * scalar, left.y * scalar);
	}

	public override string ToString () 
	{
		return String.Format ("({0},{1})", x, y);
	}
}

