using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
public class Square : EasyDraw
{
    Vec2 position;
    Vec2 velocity = new Vec2(1,1);
    Vec2 direction;
    float angle;
    public Square(Vec2 position) : base("colors.png")
    {
        this.position = position;
        SetOrigin(width / 2, height / 2);
        x = position.x;
        y = position.y;

        //angle = position.GetAngleDegrees();
        
    }

    void Update()
    {
        if (Input.GetKey(Key.LEFT))
        {
            position.RotateAroundDegrees(x - position.x, 1);
        }
        
        //position += direction;

        
        x = position.x;
        y = position.y;
    }
}

