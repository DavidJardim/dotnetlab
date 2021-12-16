using Ficha4;

Point p1 = new Point();
Point p2 = new Point(0,10);
Point p3 = new Point(10, 10);

Console.WriteLine("x: " + p1.X);

p1.X = 10;

Console.WriteLine("x: " + p1.X);

double distance = p1.DistanceTo(p2);
Console.WriteLine("Distance: " + distance);

Triangle t1 = new Triangle();
Triangle t2 = new Triangle(p1, p2, p3);

double baseT = t2.Base();
double heightT = t2.Height();
double area = t2.Area();

Console.WriteLine("Base: " + baseT);
Console.WriteLine("Height: " + heightT);
Console.WriteLine("Area: " + area);
