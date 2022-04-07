using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

internal class Shooting : EasyDraw
{
    Vec2 position;
    public Vec2 direction;

    public Shooting(Vec2 position, Platform plat) : base("arrow_long2.png")
    {
        this.position = position;
        SetOrigin(position.x,height/2);
        x = position.x;
        y = position.y;
        rotation = -90;
        
        Console.WriteLine(x + " " + y);
        
    }

    private void Turn()
    {
        if (Input.GetKey(Key.LEFT))
        {

            rotation--;
            Console.WriteLine(rotation);

        }
        else if (Input.GetKey(Key.RIGHT))
        {
            rotation++;
            Console.WriteLine(rotation);
        }

       if (rotation < -160) rotation = -160;
       if (rotation > -20) rotation = -20;

        direction = Vec2.GetUnitVectorDeg(rotation);
    }



    void Update()
    {
        Turn();
        x = position.x;
        y = position.y;
    }

}
