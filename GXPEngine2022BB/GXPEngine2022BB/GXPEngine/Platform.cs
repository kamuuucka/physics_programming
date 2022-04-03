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

    public Platform(int width, int height, Vec2 position) : base(width, height)
    {
        this.width = width;
        this.height = height;
        this.position = position;
       
        SetOrigin(this.width / 2, this.height / 2);
        DrawPlatform();
        UpdateScreenPosition();
    }

    private void DrawPlatform()
    {
        Fill(255, 255, 0);
        Stroke(0, 0, 0);
        Rect(0, 0, width, height);

    }

    void FollowMouse()
    {
        position.SetXY(Input.mouseX, y);
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
    }

    public void Step()
    {
        FollowMouse();
        UpdateScreenPosition();
    }
}

