using System;

public class TriangularPrismPaternCustum
{
    static void Main()
    {
        Triangular_Prism triangular_Prism = new Triangular_Prism(0, 0, 0);
        Console.WriteLine("三角柱");
        Console.WriteLine("計算方法を選択してください\n1.三辺と高さで求める\n2.底面の底辺と高さと三角柱の高さで求める(1-2)");
        switch (InputInt(1, 2))
        {
            case 1:
                triangular_Prism = new Triangular_Prism(Inputfloat("底面の三角形のh辺aを入力"), Inputfloat("底面の三角形の辺bを入力"), Inputfloat("底面の三角形の辺cを入力"), Inputfloat("三角柱の高さを入力"));
                break;
            case 2:
                triangular_Prism = new Triangular_Prism(Inputfloat("底面の三角形の底辺を入力して下さい"), Inputfloat("底面の三角形の高さを入力して下さい"), Inputfloat("三角柱の高さを入力して下さい"));
                break;
        }
        Console.WriteLine("表面積は" + triangular_Prism.GetSurface());
        Console.WriteLine("体積は" + triangular_Prism.GetVolume());
    }

    static float Inputfloat(string outputstring)
    {
        float input;
        while (true)
        {
            Console.WriteLine(outputstring);
            if (float.TryParse(Console.ReadLine(), out input))
            {
                return input;
                Console.WriteLine("エラー");
            }
        }
    }
    static int InputInt(int min, int max)
    {
        int input;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out input))
            {
                if (input >= min && input <= max)
                {
                    return input;
                }
            }
        }
    }
}

class Triangular_Prism
{
    float Triangular_side1, Triangular_side2, Triangular_side3, Triangular_Height, Height;
    float Triangular_bottom, Triangular_side;
    public Triangular_Prism(float triangular_side1, float triangular_side2, float triangular_side3, float height)
    {
        this.Triangular_side1 = triangular_side1;
        this.Triangular_side2 = triangular_side2;
        this.Triangular_side3 = triangular_side3;
        this.Height = height;
        float temp = (triangular_side1 + triangular_side2 + triangular_side3) / 2.0f;
        Triangular_bottom = (float)Math.Sqrt(temp * (temp - triangular_side1) * (temp - triangular_side2) * (temp - triangular_side3));
        Triangular_side = (triangular_side1 + triangular_side2 + triangular_side3) * height;
    }
    public Triangular_Prism(float triangular_side1, float triangular_height, float height)
    {
        this.Triangular_side1 = triangular_side1;
        this.Triangular_Height = triangular_height;
        this.Height = height;
        Triangular_bottom = this.Triangular_side1 * this.Triangular_Height / 2.0f;
        Triangular_side = (float)(triangular_side1 + triangular_height + Math.Sqrt(triangular_side1 * triangular_side1 + triangular_height * triangular_height)) * height;
    }
    public double GetSurface()
    {
        return Triangular_bottom * 2 + Triangular_side;
    }
    public float GetVolume()
    {
        return Triangular_bottom * Height;
    }
}