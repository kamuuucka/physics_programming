using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

internal class Platform : EasyDraw
{
    public Vec2 position;
    public Vec2 direction = new Vec2(0, 0);
    Shooting shooting;
    public bool touched;
    private float speed = 5;

    public Platform(int width, int height, Vec2 position) : base(width, height)
    {
        this.width = width;
        this.height = height;
        this.position = position;
       
        SetOrigin(this.width / 2, this.height / 2);
        Console.WriteLine("WIDTH: " + this.width / 2 + " HEIGHT: " + this.height / 2);
        DrawPlatform();

        shooting = new Shooting(new Vec2(x, y), this);
        AddChild(shooting);
        UpdateScreenPosition();
        
    }

    public void SetTouched(bool state)
    {
        touched = state;
    }

    private void DrawPlatform()
    {
        Clear(50);
        Fill(255, 255, 0);
        Stroke(0, 0, 0);
        ShapeAlign(CenterMode.Min, CenterMode.Min);
        Rect(0, 0, width, height);

    }

    void FollowMouse()
    {
        if (!touched)
        {
            position.SetXY(Input.mouseX, y);
        }
        
    }

    void Move()
    {
        if (!touched)
        {
            if (Input.GetKey(Key.A))
            {
                position.x -= speed;
            }
            else if (Input.GetKey(Key.D))
            {
                position.x += speed;
            }
        }
       
    }

    public void UpdateScreenPosition()
    {
        MyGame myGame = (MyGame)game;
       
        if (position.x - width/ 2 < myGame.border)
        {
            position.x = myGame.border + width/2;
        } else if (position.x > myGame.width - myGame.border)
        {
            position.x = myGame.width - myGame.border;
        }

        x = position.x;
        y = position.y;

        direction = shooting.direction;
        
    }

    public void Step()
    {
        // FollowMouse();
        Move();
        UpdateScreenPosition();
    }
}

