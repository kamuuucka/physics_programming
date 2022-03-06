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

	// TODO: In the normalize check if the length is not 0

	public float Length() {
		return Mathf.Sqrt(x * x + y * y);
	}

	public Vec2 Normalized()
    {		
		return new Vec2(x / Length(), y / Length());
	}

	public void Normalize()
    {
		float l = Length();
		y = y / l;
		x = x / l;
		
	}

	public void SetXY(float x, float y)
    {
		this.x = x;
		this.y = y;
    }

	// TODO: Implement subtract, scale operators

	public static Vec2 operator+ (Vec2 left, Vec2 right) {
		return new Vec2(left.x+right.x, left.y+right.y);
	}

	public static Vec2 operator- (Vec2 left, Vec2 right)
	{
		return new Vec2(left.x - right.x, left.y - right.y);
	}

	public static Vec2 operator* (float k, Vec2 right)
    {
		return new Vec2(k*right.x, k*right.y);
    }

	public static Vec2 operator* (Vec2 left, float k)
    {
		return new Vec2(k*left.x, k*left.y);
    }

	public override string ToString () 
	{
		return String.Format ("({0},{1})", x, y);
	}
}

