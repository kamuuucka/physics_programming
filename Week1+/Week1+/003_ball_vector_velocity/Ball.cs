using System;
using GXPEngine;

public class Ball : EasyDraw
{
    public Vec2 position
    {
        get
        {
            return _position;
        }
    }

    public Vec2 velocity;

    int _radius;
    Vec2 _position;
    float _speed;
    Vec2 _delta;
    Vec2 mouse;
    bool gameActive = true;

    public float timer;

    public Ball(int pRadius, Vec2 pPosition, float pSpeed = 5) : base(pRadius * 2 + 1, pRadius * 2 + 1)
    {
        _radius = pRadius;
        _position = pPosition;
        _speed = pSpeed;

        UpdateScreenPosition();
        SetOrigin(_radius, _radius);

        Draw(150, 0, 255);
    }

    void Draw(byte red, byte green, byte blue)
    {
        Fill(red, green, blue);
        Stroke(red, green, blue);
        Ellipse(_radius, _radius, 2 * _radius, 2 * _radius);
    }

    void KeyControls()
    {
        velocity.x = 0;
        velocity.y = 0;

        if (Input.GetKey(Key.RIGHT))
        {
            velocity.x += _speed;
        }
        else if (Input.GetKey(Key.LEFT))
        {
            velocity.x -= _speed;
        }

        if (Input.GetKey(Key.UP))
        {
            velocity.y -= _speed;
        }
        else if (Input.GetKey(Key.DOWN))
        {
            velocity.y += _speed;
        }

        //Fixes the speed of ball while it's moving diagonally
        if (velocity.Length() > _speed)
        {
            velocity = velocity.Normalized() * _speed;
        }
    }

    void Movement()
    {
        velocity.x = 0;
        velocity.y = 0;

        //Count the distance between mouse and ball
        mouse = new Vec2(Input.mouseX, Input.mouseY);
        _delta = mouse - _position;

        //Normalize delta vector (distance) to get the value 1 but keep pointing in the direction of the target
        //Multiply the delta vector with speed so lenght is equal to speed
        //Assign it to velocity, so ball will move with desired speed
        velocity = _delta.Normalized() * _speed;

        //If length of velocity is bigger than speed, fix it. Used to fix the diagonal movement
        if (velocity.Length() > _speed)
        {
            velocity = velocity.Normalized() * _speed;
        }

        //Every frame make the speed bigger
        _speed += 0.05f;
        GameOver();
    }

    public bool GameOver()
    {
        //Checks the collision with mouse
        if (_delta.Length() <= _radius)
        {
            gameActive = false;
            return true;
        }
        else
        {
            
            return false;
        }

    }

    float Timer()
    {
        if (gameActive)
        {
            return timer += Time.deltaTime / 1000.0f;
        }
        return timer;
    }

    void UpdateScreenPosition()
    {
        x = _position.x;
        y = _position.y;
    }

    public void Step()
    {
        //KeyControls ();

        _position += velocity;


        UpdateScreenPosition();
        Movement();
        Timer();
    }
}
