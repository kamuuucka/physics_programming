using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


internal class BrickPlacement : EasyDraw
{
    int brickWidth;
    int brickHeight;
    public BrickPlacement(Vec2 positionStart, Vec2 positionEnd, int width, int height) : base(width, height)
    {
        x = 10;
        y = 10;
        this.width = width;
        this.height = height;
        brickHeight = height;
        brickWidth = width;
        //width = (int)(positionEnd.x);
       // height = (int)(positionEnd.y);
        Draw();
        Console.WriteLine("BP: x: " + x + " y: " + y + " w: " + brickWidth + " h: " + brickHeight);
    }

    void Draw()
    {
        brickWidth *= 1;
        brickHeight *= 1;
        Fill(0, 255, 0);
        Stroke(0, 0, 0);
        Rect(0, 0, brickWidth, brickHeight);
    }
}

