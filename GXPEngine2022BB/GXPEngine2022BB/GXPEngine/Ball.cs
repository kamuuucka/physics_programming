using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


internal class Ball : EasyDraw
{
    public int radius;
    float speed = 2;

    public Vec2 position;
    private Vec2 oldPosition;
    private Vec2 velocity;
    private Vec2 oldVelocity;
    private CollisionInfo earliestCollision;
    private Platform platform;

    public bool platformTouched = false;

    public static float bounciness = 0.98f;

    public Ball (int radius, Vec2 position, Platform platform, float speed = 5) : base (radius*2 + 1, radius * 2 + 1)
    {
        this.radius = radius;
        this.position = position;   
        this.speed = speed;
        this.platform = platform;

        oldPosition = new Vec2(0,0);
        velocity = new Vec2(-speed,speed/2);

        SetOrigin(radius, radius);

        Draw(255, 255, 255);
    }

    private void Draw(byte red, byte green, byte blue)
    {
        Fill(red, green, blue);
        Stroke(red, green, blue);
        Ellipse(radius, radius, radius * 2, radius * 2);
    }

    private void FollowMouse()
    {
        position.SetXY(Input.mouseX, Input.mouseY);
    }

    public void UpdateScreenPosition()
    {
        if (platformTouched)
        {
            oldVelocity = velocity;
            //position.x = platform.position.x - platform.width/4;
            velocity = new Vec2(0, 0);
        }
        x = position.x;
        y = position.y; 
    }

    public void Step()
    {
        oldPosition = position;
        //FollowMouse();
        Move();
        UpdateScreenPosition();
        platform.SetTouched(platformTouched);
    }

    private void Move()
    {
        earliestCollision = null;
        //velocity += acceleration;
        position += velocity;
        PlatformCollision();
        Collision();

        if (earliestCollision != null)
        {
            ResolveCollision(earliestCollision);
        }


        Shooting();
    }
    void ResolveCollision(CollisionInfo collision)
    {
        position = oldPosition + collision.timeOfImpact * velocity;

        if (collision.normal.x != 0)
        {
            velocity.x = -bounciness * velocity.x;
        }

        if (collision.normal.y != 0)
        {
            velocity.y = -bounciness * velocity.y;
        }
    }

    private void PlatformCollision()
    {
        //Console.WriteLine("Platform position: {0}     Ball position: {1}", platform.position.ToString(), position.ToString());
        if ((position.y + radius > platform.position.y - platform.height/2)
            && (position.x > platform.position.x - platform.width / 2)
            && (position.x < platform.position.x + platform.width /2)
            && !platformTouched)
        {
            SetColor(1, 0, 0);

            Vec2 platformLine = (platform.position + new Vec2(platform.width, 0)) - platform.position;
            Vec2 diffVectorPlatform = platform.position - position;


            float platformDistance = diffVectorPlatform.Dot(platformLine.Normal());


            position -= platformLine.Normal() * (platformDistance - radius);
            //velocity.Reflect(platformLine.Normal());
            velocity = new Vec2(0, 0);
            platformTouched = true;
        }
    }

    private void Collision()
    {
        MyGame myGame = (MyGame)game;
        float impactY;
        float impactX;
        float time;

        Vec2 diffVectorRight = myGame.diagonalRightBoundary.start - position;
        Vec2 line = myGame.diagonalRightBoundary.start - myGame.diagonalRightBoundary.end;

        Vec2 diffVectorLeft = position - myGame.diagonalLeftBoundary.start;
        Vec2 lineLeft = myGame.diagonalLeftBoundary.end - myGame.diagonalLeftBoundary.start;

        float ballDistance = diffVectorRight.Dot(line.Normal());
        float ballDistanceLeft = diffVectorLeft.Dot(lineLeft.Normal());

        //update ball position
        if (ballDistance < radius)
        {
            SetColor(1, 1, 0);
            position += line.Normal() * (ballDistance - radius);
            velocity.Reflect(line.Normal());
        }
        if (ballDistanceLeft < radius)
        {
            SetColor(1, 0, 1);
            position += line.Normal() * (ballDistanceLeft - radius);
            velocity.Reflect(lineLeft.Normal());
        }

        if (position.x - radius < myGame.leftXBoundary.GetX())
        {
            SetColor(1, 0, 0);

            impactX = myGame.leftXBoundary.GetX() + radius;
            time = (impactX - oldPosition.x) / (position.x - oldPosition.x);

            if (earliestCollision == null || earliestCollision.timeOfImpact > time)
            {
                earliestCollision = new CollisionInfo(new Vec2(1, 0), null, time, velocity);
            }
        }
        else if (position.x + radius > myGame.rightXBoundary.GetX())
        {
            SetColor(0, 1, 0);

            impactX = myGame.rightXBoundary.GetX() - radius;
            time = (impactX - oldPosition.x) / (position.x - oldPosition.x);

            if (earliestCollision == null || earliestCollision.timeOfImpact > time)
            {
                earliestCollision = new CollisionInfo(new Vec2(-1, 0), null, time, velocity);
            }            
        }

        if (position.y - radius < myGame.topYBoundary.GetY())
        {
            SetColor(0, 0, 1);

            impactY = myGame.topYBoundary.GetY() + radius;
            time = (impactY - oldPosition.y) / (position.y - oldPosition.y);

            if (earliestCollision == null || earliestCollision.timeOfImpact > time)
            {
                earliestCollision = new CollisionInfo(new Vec2(0, 1), null, time, velocity);
            }
            
        }
        

        
    }

    private void Shooting()
    {
        if (Input.GetKey(Key.SPACE))
        {
            velocity = oldVelocity;
            velocity = speed * platform.direction;
            platformTouched = false;
        }
    }
}

