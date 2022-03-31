using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


internal class Ball : EasyDraw
{
    public int radius;
    float speed;

    public Vec2 position;

    public Ball (int radius, Vec2 position, float speed = 5) : base (radius*2 + 1, radius * 2 + 1)
    {
        this.radius = radius;
        this.position = position;   
        this.speed = speed;

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
        x = position.x;
        y = position.y;
    }

    public void Step()
    {
        FollowMouse();
        UpdateScreenPosition();
    }
}

