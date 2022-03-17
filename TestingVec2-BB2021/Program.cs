using System;

class MainClass
{
	/// <summary>
	/// A helper method for unit testing:
	/// Returns true if and only if both coordinates of the Vec2s a and b are 
	/// within the given errorMargin of each other.
	/// </summary>
	public static bool Approximate(Vec2 a, Vec2 b, float errorMargin=0.01f) {
		return Approximate (a.x, b.x, errorMargin) && Approximate (a.y, b.y, errorMargin); 
	}

	/// <summary>
	/// A helper method for unit testing:
	/// Returns true if and only if [a] and [b] differ by at most [errorMargin].
	/// </summary>
	public static bool Approximate(float a, float b, float errorMargin=0.01f) {
		return Math.Abs (a - b) < errorMargin;
	}

	public static void Main (string[] args)
	{
		Console.WriteLine("Testing Vec2 struct...");
		// Add your unit tests here:

		// Week 1:

		// test v.Length
		// test v.Normalize
		// test v.Normalized

		// Week 2 static:

		// test Vec2.Deg2Rad
		// test Vec2.Rad2Deg
		// test Vec2.GetUnitVectorDegrees
		// test Vec2.GetUnitVectorRadians

		// Week 2 instance:

		// test v.GetAngleDegrees
		// test v.GetAngleRadians
		// test v.SetAngleDegrees
		// test v.SetAngleRadians

		// test v.RotateDegrees
		// test v.RotateRadians
		// test v.RotateAroundDegrees
		// test v.RotateAroundRadians

		// Week 4:

		// test v.Normal
		// test v.Dot
		// test v.Reflect

		Console.ReadLine ();
	}
}

