using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Line : GameObject
{
    private EasyDraw line;

    public Vec2 start;
    public Vec2 end;
    public Line(Vec2 start, Vec2 end)
    {
        line = new EasyDraw(game.width, game.height);
        this.start = start;
        this.end = end;
        DrawLine();
        game.AddChild(line);
    }

    public void DrawLine()
    {
        line.Line(start.x, start.y, end.x, end.y);
        line.SetColor(34, 234, 186);
        //Console.WriteLine("Line drawn {0}, {1}", start, end);
    }

    public float GetX()
    {
        return start.x;
    }

    public float GetY()
    {
        return start.y;
    }
}

