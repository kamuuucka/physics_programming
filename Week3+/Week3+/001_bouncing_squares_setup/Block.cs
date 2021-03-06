using System;
using GXPEngine;


public class Block : EasyDraw
{
	/******* PUBLIC FIELDS AND PROPERTIES *********************************************************/

	// These four public static fields are changed from MyGame, based on key input (see Console):
	public static bool drawDebugLine = false;
	public static bool wordy = false;
	public static float bounciness = 0.98f;
	// For ease of testing / changing, we assume every block has the same acceleration (gravity):
	public static Vec2 acceleration = new Vec2 (0, 0);

	public readonly int radius;

	// Mass = density * volume.
	// In 2D, we assume volume = area (=all objects are assumed to have the same "depth")
	public float Mass {
		get {
			return 4 * radius * radius * _density;
		}
	}

	public Vec2 position {
		get {
			return _position;
		}
	}

	public Vec2 velocity;

	/******* PRIVATE FIELDS *******************************************************************/

	Vec2 _position;
	Vec2 _oldPosition;

	float _red = 1;
	float _green = 1;
	float _blue = 1;

	float _density = 1;

	const float _colorFadeSpeed = 0.025f;

	/******* PUBLIC METHODS *******************************************************************/

	public Block (int pRadius, Vec2 pPosition, Vec2 pVelocity) : base (pRadius*2, pRadius*2)
	{
		radius = pRadius;
		_position = pPosition;
		velocity = pVelocity;

		SetOrigin (radius, radius);
		Draw ();
		UpdateScreenPosition();
		_oldPosition = new Vec2(0,0);
	}

	public void SetFadeColor(float pRed, float pGreen, float pBlue) {
		_red = pRed;
		_green = pGreen;
		_blue = pBlue;
	}

	public void Update() {
		// For extra testing flexibility, we call the Step method from MyGame instead:
		//Step();
		Gizmos.DrawArrow(_position.x, _position.y, velocity.x * 10, velocity.y * 10);
	}

	public void Step() {
		_oldPosition=_position;

		// No need to make changes in this Step method (most of it is related to drawing, color and debug info). 
		// Work in Move instead.
		Move();

		UpdateColor();
		UpdateScreenPosition();
		ShowDebugInfo();
	}

	/******* PRIVATE METHODS *******************************************************************/

	/******* THIS IS WHERE YOU SHOULD WORK: ***************************************************/

	CollisionInfo earliestCollision;

	void Move() {
		earliestCollision = null;
		// TODO: implement Assignment 3 here (and in methods called from here).
		velocity += acceleration;
		_position += velocity;

		// Example methods (replace/extend):
		CheckBoundaryCollisions();
		

		//CheckBlockOverlaps();

		// TIP: You can use the CollisionInfo class to pass information between methods, e.g.:
		//
		//CollisionInfo firstCollision=FindEarliestCollision();
		if (earliestCollision!=null)
			ResolveCollision(earliestCollision);
	}

	void ResolveCollision(CollisionInfo collision)
	{
		_position = _oldPosition + collision.timeOfImpact * velocity;

		if (collision.normal.x != 0)
        {
			velocity.x = -bounciness * velocity.x;
		}

		if (collision.normal.y != 0)
        {
			velocity.y = -bounciness * velocity.y;
		}
	}

	// This method is just an example of how to check boundaries, and change color.
	void CheckBoundaryCollisions() {
		MyGame myGame = (MyGame)game;
		float impactY;
		float impactX;
		float time = 1;
		Vec2 poi;

		if (_position.x - radius < myGame.LeftXBoundary) {
			// move block from left to right boundary:
			//_position.x += myGame.RightXBoundary - myGame.LeftXBoundary - 2 * radius;
			//impactX = myGame.LeftXBoundary + radius;
			//t.x = (_oldPosition.x - impactX) / _oldPosition.x - _position.x;
			//_position.x = myGame.LeftXBoundary + radius;
			impactX = myGame.LeftXBoundary + radius;
			time = (impactX - _oldPosition.x) / (_position.x - _oldPosition.x);

			// Here we have a possible collision with TOI as calculated, with normal (1,0) and "other" = null. (boundaries don't count)
			if (earliestCollision == null || earliestCollision.timeOfImpact > time)
            {
				earliestCollision = new CollisionInfo(new Vec2(1, 0), null, time, velocity);
			}
			
			//_position.x = _oldPosition.x + t.x * velocity.x;
			SetFadeColor(1, 0.2f, 0.2f);
			if (wordy) {
				Console.WriteLine ("Left boundary collision");
			}
		} else if (_position.x + radius > myGame.RightXBoundary) {
			// move block from right to left boundary:
			//_position.x -= myGame.RightXBoundary - myGame.LeftXBoundary - 2 * radius;
			//impactX = myGame.RightXBoundary - radius;
			//t.x = (impactX - _oldPosition.x) / _position.x - _oldPosition.x;
			//_position.x = myGame.RightXBoundary - radius;
			impactX = myGame.RightXBoundary - radius;
			time = (impactX - _oldPosition.x) / (_position.x - _oldPosition.x);

			if (earliestCollision == null || earliestCollision.timeOfImpact > time)
			{
				earliestCollision = new CollisionInfo(new Vec2(-1, 0), null, time, velocity);
			}

			SetFadeColor(1, 0.2f, 0.2f);
			if (wordy) {
				Console.WriteLine ("Right boundary collision");
			}
		}
		if (_position.y - radius < myGame.TopYBoundary) {
			// move block from top to bottom boundary:
			//_position.y += myGame.BottomYBoundary - myGame.TopYBoundary - 2 * radius;
			//impactY = myGame.BottomYBoundary - radius;
			//t.y = (impactY - _oldPosition.y) / _position.y - _oldPosition.y;
			//_position.y = myGame.TopYBoundary + radius;

			impactY = myGame.TopYBoundary + radius;
			time = (impactY - _oldPosition.y) / (_position.y - _oldPosition.y);

			if (earliestCollision == null || earliestCollision.timeOfImpact > time)
			{
				earliestCollision = new CollisionInfo(new Vec2(0, 1), null, time, velocity);
			}
			SetFadeColor(0.2f, 1, 0.2f);
			if (wordy) {
				Console.WriteLine ("Top boundary collision");
			}
		} else if (_position.y + radius > myGame.BottomYBoundary) {
			// move block from bottom to top boundary:
			//_position.y -= myGame.BottomYBoundary - myGame.TopYBoundary - 2 * radius;
			//impactY = myGame.BottomYBoundary - radius;
			//t.y = (impactY - _oldPosition.y) / _position.y - _oldPosition.y;


			//_position.y = myGame.BottomYBoundary - radius;
			
			impactY = myGame.BottomYBoundary - radius;
			time = (impactY - _oldPosition.y) / (_position.y - _oldPosition.y);

			//newVelocity.y = -velocity.y;
			//poiY = _oldPosition.y + t.y * velocity.y;
			//_position.y = poiY;

			if (earliestCollision == null || earliestCollision.timeOfImpact > time)
			{
				earliestCollision = new CollisionInfo(new Vec2(0, -1), null, time, velocity); // only do this is earliestCol==null or if new time is better!
			}

			//_position.y = _oldPosition.y + t.y * velocity.y;
			SetFadeColor(0.2f, 1, 0.2f);
			if (wordy) {
				Console.WriteLine ("Bottom boundary collision");
			}
		}

		

		//_position = _oldPosition + new Vec2(t.x * velocity.x, t.y * velocity.y);
		
	}

	// This method is just an example of how to get information about other blocks in the scene.
	void CheckBlockOverlaps() {
		MyGame myGame = (MyGame)game;
		for (int i = 0; i < myGame.GetNumberOfMovers(); i++) {
			Block other = myGame.GetMover(i);
			if (other != this) {
				// TODO: improve hit test, move to method:
				if (Mathf.Abs(other.position.x - _position.x) < 25 &&
					Mathf.Abs(other.position.y - _position.y) < 25) {
					SetFadeColor(0.2f, 0.2f, 1);
					other.SetFadeColor(0.2f, 0.2f, 1);
					if (wordy) {
						Console.WriteLine ("Block-block overlap detected.");
					}
				}
			}
		}
	}

	/******* NO NEED TO CHANGE ANY OF THE CODE BELOW: **********************************************/

	void UpdateColor() {
		if (_red < 1) {
			_red = Mathf.Min (1, _red + _colorFadeSpeed);
		}
		if (_green < 1) {
			_green = Mathf.Min (1, _green + _colorFadeSpeed);
		}
		if (_blue < 1) {
			_blue = Mathf.Min (1, _blue + _colorFadeSpeed);
		}
		SetColor(_red, _green, _blue);
	}

	void ShowDebugInfo() {
		if (drawDebugLine) {
			((MyGame)game).DrawLine (_oldPosition, _position);
		}
	}

	void UpdateScreenPosition() {
		x = _position.x;
		y = _position.y;
	}

	void Draw() {
		Fill (200);
		NoStroke ();
		ShapeAlign (CenterMode.Min, CenterMode.Min);
		Rect (0, 0, width, height);
	}
}
