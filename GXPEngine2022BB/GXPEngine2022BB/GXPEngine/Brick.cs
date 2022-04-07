using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


internal class Brick : EasyDraw
{
    Vec2 position;

    public Brick(int width, int height, Vec2 position) : base(width, height)
    {
        this.width = width;
        this.height = height;
        this.position = position;

        Draw();
        x = position.x;
        y = position.y;
    }

    void Draw()
    {
        Fill(23, 189, 200);
        Stroke(0, 0, 0);
        Rect(0, 0, width,height);
    }
}

