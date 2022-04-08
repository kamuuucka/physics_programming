using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


public class Brick : EasyDraw
{
    public Vec2 position;
    Ball ball;
    public bool brickColided = false;

    public Brick(int width, int height, Vec2 position, Ball ball) : base(width, height)
    {
        this.width = width;
        this.height = height;
        this.position = position;
        this.ball = ball;

        Draw();
        x = position.x;
        y = position.y;
    }

    void Draw()
    {
        Clear(50);
        Fill(23, 189, 200);
        Stroke(0, 0, 0);
        ShapeAlign(CenterMode.Min, CenterMode.Min);

        Rect(0, 0, width,height);
    }

    void Update()
    {
        if (brickColided)
        {
            this.Destroy();
        }
    }
}

