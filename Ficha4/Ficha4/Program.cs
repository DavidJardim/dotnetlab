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

Rectangle r1 = new Rectangle();
Rectangle r2 = new Rectangle(new Point(0, 5), 5, 5);

double areaRect = r2.Area();
double perimRect = r2.Perimeter();

Console.WriteLine("Area Rectangle: " + areaRect);

Point point = new Point(1, 4);

Point point2 = new Point(6, 6);

Console.WriteLine(point.ToString());



bool contains = r2.Contains(point);
bool contains2 = r2.Contains(point2);

Console.WriteLine(contains2);

Circle c1 = new Circle();
Circle c2 = new Circle(new Point(5, 5), 5);

double areaC = c2.Area();
double perimeterC = c2.Perimeter();

Console.WriteLine("Area do circulo:" + areaC);
Console.WriteLine("Posição do círculo:" + c2.Position);

Console.WriteLine(c2.ToString());
Console.WriteLine(c1.ToString());




