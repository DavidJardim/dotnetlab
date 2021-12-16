using Ficha4;

public class Triangle
{
    private Point a;
    private Point b;
    private Point c;

    public Triangle()
    {
        this.a = new Point();
        this.b = new Point();
        this.c = new Point();
    }

    public Triangle(Point a, Point b, Point c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public Point A
    {
        get { return a; }
        set { a = value; }
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
        return a.DistanceTo(b);
    }

    public double Height()
    {
        return a.DistanceTo(c);
    }

    public double Area()
    {
        return (Base() * Height()) / 2;
    }
}