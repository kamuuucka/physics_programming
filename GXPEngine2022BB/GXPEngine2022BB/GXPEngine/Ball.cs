using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


public class Ball : EasyDraw
{
    public int radius;
    float speed = 2;

    public Vec2 position;
    private Vec2 oldPosition;
    private Vec2 velocity;
    private Vec2 oldVelocity;
    private Vec2 brickPosition;
    private CollisionInfo earliestCollision;
    private Platform platform;
    private List<Line> lines;
    private List<Brick> bricks;

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

        lines = ((MyGame)game).lines;
        bricks = ((MyGame)game).bricks;

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
        BrickCollision();
        Collision();
        Shooting();
    }

    private void PlatformCollision()
    {
        Vec2 platformLine = (platform.position - platform.position + new Vec2(platform.width, platform.position.y));
        Vec2 diffVectorPlatform = platform.position - position;
        float platformDistance = diffVectorPlatform.Dot(platformLine.Normal());

        if (position.y > platform.position.y
            && (position.x > platform.position.x - platform.width / 2)
            && (position.x < platform.position.x + platform.width /2)
            && !platformTouched)
        {
            SetColor(1, 0, 0);
            position -= platformLine.Normal() * (platformDistance - radius);
            velocity = new Vec2(0, 0);
            platformTouched = true;
        }
    }

    void DrawNormal(Vec2 lineStart, Vec2 lineEnd)
    {
        Vec2 center = (lineStart + lineEnd) * 0.5f;
        Vec2 normal = (lineEnd - lineStart).Normal();
        Gizmos.DrawArrow(center.x, center.y, normal.x * 20, normal.y * 20);
    }
    
    private void Collision()
    {
        foreach(Line nline in lines)
        {
            Vec2 diffVec = nline.start - position;
            Vec2 line1 = nline.start - nline.end;
            DrawNormal(nline.start, nline.end);

            float ballDistance = diffVec.Dot(line1.Normal());

            if (ballDistance < radius)
            {
                SetColor(1, 1, 0);
                position += line1.Normal() * (ballDistance - radius);
                velocity.Reflect(line1.Normal());
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

    private void BrickCollision()
    {
        foreach (Brick brick in bricks)
        {
            if (position.x > brick.position.x && position.x < brick.position.x + brick.width
                && position.y < brick.position.y && position.y < brick.position.y + brick.height)
            {
                brick.brickColided = true;
            }
        }
    }
}

