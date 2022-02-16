using Ficha4;

public class Triangle : Shape
{
    
    private Point b;
    private Point c;

    public Triangle()
    {
        this.position = new Point();
        this.b = new Point();
        this.c = new Point();
    }

    public Triangle(Point a, Point b, Point c)
    {
        this.position = a;
        this.b = b;
        this.c = c;
    }

    public Point A
    {
        get { return position; }
        set { position = value; }
    }
    public Point B
    {
        get { return b; }
        set { b = value; }
    }
    public Point C
    {
        get { return c; }
        set { c = value; }
    }

    public double Base()
    {
        return position.DistanceTo(b);
    }

    public double Height()
    {
        return position.DistanceTo(c);
    }

    public override double Area()
    {
        return (Base() * Height()) / 2;
    }

    public override double Perimeter()
    {
       /* double l1 = position.DistanceTo(b);
        double l2 = position.DistanceTo(c);
        double l3 = b.DistanceTo(c);

        double perimeter = l1 + l2 + l3;
        return perimeter;*/

        return position.DistanceTo(b) + position.DistanceTo(c) + b.DistanceTo(c);
    }
}