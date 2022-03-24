using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{
    static void DoTest()
    {

        float n = 0;
        for (int i=0;i<10;i++)
        {
            n += 0.1f;
        }
        Console.WriteLine("Test: 1=1? {0}",(n==1));


        Console.WriteLine("Convertion (deg to rad) ok? {0} It shoul be 0,349", Vec2.Deg2Rad(20));
        Console.WriteLine("Conversion (rad to deg) ok? {0} It should be 1145,915", Vec2.Rad2Deg(20));
        Console.WriteLine("New vector pointing in the direction (deg) ok? {0} Should be (0,939692 , 0,342020)", Vec2.GetUnitVectorDeg(20));
        Console.WriteLine("New vector pointing in the direction (rad) ok? {0} Should be (0,408082 , 0,912945)", Vec2.GetUnitVectorRad(20));
        Console.WriteLine("Generating random unit vector ok? {0}", Vec2.RandomUnitVector());

        Vec2 v1 = new Vec2(3, 4);
        Vec2 v2 = new Vec2(3, 4);
        v1.SetAngleDegrees(180);
        Console.WriteLine("Setting angle in degrees. Length stays the same. Ok? {0}", v1);
        v2.SetAngleRadians(20);
        Console.WriteLine("Setting angle in radians. Length stays the same. Ok? {0}", v2);
        Console.WriteLine("Angle in degrees ok? {0} Should be 200", v1.GetAngleDegrees());
        Console.WriteLine("Angle in radians ok? {0} Should be 20", v2.GetAngleRadians());
        float rad = 20;
        while (rad > Mathf.PI) rad -= 2 * Mathf.PI;
        Console.WriteLine("...or {0}, which is also okay",rad);

        Vec2 v3 = new Vec2(4, 5);
        Vec2 v4 = new Vec2(4, 5);
        v3.RotateDegrees(10);
        Console.WriteLine("Rotation ok? {0} Should be (3,07099 , 5,61863)", v3);
        v4.RotateRadians(10);
        Console.WriteLine("Rotation ok? {0} Should be (-0,6361805 , -6,3714420)", v4);

        Vec2 v5 = new Vec2(3, 4);
        Vec2 v6 = new Vec2(3, 4);
        Vec2 point = new Vec2(6, 4);
        v5.RotateAroundDegrees(point, 90);
        Console.WriteLine("Rotation around point ok? {0} Should be (6 , 1)", v5);
        v6.RotateAroundRadians(point, Mathf.PI / 2);
        Console.WriteLine("Rotation around point ok? {0} Should be (6 , 1)", v6);
    }
    static void Main()
    {
        new MyGame().Start();

    }

    public MyGame() : base(800, 600, false, false)
    {
        // background:
        AddChild(new Sprite("assets/desert.png"));
        // tank:
        AddChild(new Tank(width / 2, height / 2));

        DoTest();
    }


}