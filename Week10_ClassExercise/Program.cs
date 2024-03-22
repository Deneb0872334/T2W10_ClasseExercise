using System;

class Point
{
    private double _xCoord;
    private double _yCoord;

    public Point(double xCoord, double yCoord)
    {
        this._xCoord = xCoord;
        this._yCoord = yCoord;
    }

    public double XCoord
    {
        get { return this._xCoord; }
        set { this._xCoord = value; }
    }

    public double YCoord
    {
        get { return this._yCoord; }
        set { this._yCoord = value; }
    }
}

class Circle
{
    private Point vPoint;
    private double iRadius;

    public Circle(Point tempPoint, double tempRadius)
    {
        this.vPoint = tempPoint;
        this.iRadius = tempRadius;
    }

    public Point Point
    {
        get { return this.vPoint; }
        set { this.vPoint = value; }
    }

    public double Radius
    {
        get { return this.iRadius; }
        set { this.iRadius = value; }
    }

    public double getArea()
    {
        return 2 * (iRadius * iRadius);
    }

    public double getCircumference()
    {
        return (2 * 3.1416) * iRadius;
    }
}

internal class Program
{ 
    private static void Main(string[] args)
    {
        Circle[] arrCircles;
        initCircleArray();
        displayDetails();
        checkPointFromUser(getPointFromUser());

        void initCircleArray()
        {
            Console.Write("Please enter the number of circles to be stored: ");
            int iCircleCount = Convert.ToInt16(Console.ReadLine());
            arrCircles = new Circle[iCircleCount];

            for (int i = 0; i < iCircleCount; i++)
            {
                Console.Write("Please enter the X-coordinate of the circle: ");
                double xCoord = Convert.ToDouble(Console.ReadLine());
                Console.Write("Please enter the Y-coordinate of the circle: ");
                double yCoord = Convert.ToDouble(Console.ReadLine());
                Console.Write("Please enter the radius of the circle: ");
                double dRadius = Convert.ToDouble(Console.ReadLine());

                Point vPoint = new Point(xCoord, yCoord);
                Circle vCircle = new Circle(vPoint, dRadius);

                arrCircles[i] = vCircle;
            }
        }

        void displayDetails()
        {
            for (int iLoop = 0; iLoop < arrCircles.Length; iLoop++)
            {
                String strOutput = String.Format("****** Circle {0} ******", iLoop + 1);
                Console.WriteLine(strOutput);
                strOutput = String.Format("Coordinates: ({0},{1})", arrCircles[iLoop].Point.XCoord, arrCircles[iLoop].Point.YCoord);
                Console.WriteLine(strOutput);
                strOutput = String.Format("Radius: {0}", arrCircles[iLoop].Radius);
                Console.WriteLine(strOutput);
                strOutput = String.Format("Circumference: {0}", arrCircles[iLoop].getCircumference());
                Console.WriteLine(strOutput);
                strOutput = String.Format("Radius: {0}", arrCircles[iLoop].getArea());
                Console.WriteLine(strOutput);
            }
        }

        Point getPointFromUser()
        {
            Point tempPoint;
            Console.Write("Please enter the X-coordinate of the circle: ");
            double xCoord = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter the Y-coordinate of the circle: ");
            double yCoord = Convert.ToDouble(Console.ReadLine());
            tempPoint = new Point(xCoord, yCoord);

            return tempPoint;
        }

        void checkPointFromUser(Point paramPoint)
        {
            for (int iLoop = 0; iLoop < arrCircles.Length; iLoop++)
            {
                Point tempPoint = arrCircles[iLoop].Point;
                double tempRadius = arrCircles[iLoop].Radius;
                // Check if the user's point is within each circle by checking the value against the point + radius
                if (((paramPoint.XCoord >= tempPoint.XCoord) && (paramPoint.XCoord <= (tempPoint.XCoord + tempRadius))) && ((paramPoint.YCoord >= tempPoint.YCoord) && (paramPoint.YCoord <= (tempPoint.YCoord + tempRadius))))
                {
                    String strOutput = String.Format("The point ({0},{1}) is inside Circle {2}", paramPoint.XCoord, paramPoint.YCoord, iLoop + 1);
                    Console.WriteLine(strOutput);
                } else
                {
                    Console.WriteLine("Point is not in any of the circles");
                }
            }
        }
    }
}