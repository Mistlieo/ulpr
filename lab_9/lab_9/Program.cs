using System;

interface IShape
{
    double Area();
}

// Базовый абстрактный класс Фигура
abstract class Figure : IShape
{
    // Абстрактный метод для расчёта площади
    public abstract double Area();

    // Виртуальный метод для вывода информации о фигуре
    public virtual void DisplayInfo()
    {
        Console.WriteLine("Фигура");
    }
}

// Класс 4-х угольник, наследуется от Фигура
class Quadrilateral : Figure
{
    // Конструктор
    public Quadrilateral(double side1, double side2)
    {
        Side1 = side1;
        Side2 = side2;
    }

    // Свойства
    public double Side1 { get; set; }
    public double Side2 { get; set; }

    // Реализация метода для расчёта площади
    public override double Area()
    {
        return Side1 * Side2;
    }

    // Переопределение метода для вывода информации о 4-х угольнике
    public override void DisplayInfo()
    {
        Console.WriteLine("4-х угольник");
        Console.WriteLine("Сторона 1: " + Side1);
        Console.WriteLine("Сторона 2: " + Side2);
        Console.WriteLine("Площадь: " + Area());
    }
}

// Класс Круг, наследуется от Фигура
class Circle : Figure
{
    // Конструктор
    public Circle(double radius)
    {
        Radius = radius;
    }

    // Свойство
    public double Radius { get; set; }

    // Реализация метода для расчёта площади
    public override double Area()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    // Переопределение метода для вывода информации о круге
    public override void DisplayInfo()
    {
        Console.WriteLine("Круг");
        Console.WriteLine("Радиус: " + Radius);
        Console.WriteLine("Площадь: " + Area());
    }
}

// Класс Квадрат, наследуется от 4-х угольника
class Square : Quadrilateral
{
    // Конструктор
    public Square(double side) : base(side, side)
    {
    }

    // Переопределение метода для вывода информации о квадрате
    public override void DisplayInfo()
    {
        Console.WriteLine("Квадрат");
        Console.WriteLine("Сторона: " + Side1);
        Console.WriteLine("Площадь: " + Area());
    }
}

// Класс Ромб, наследуется от 4-х угольника
class Rhombus : Quadrilateral
{
    // Конструктор
    public Rhombus(double side, double height) : base(side, height)
    {
    }

    // Переопределение метода для вывода информации о ромбе
    public override void DisplayInfo()
    {
        Console.WriteLine("Ромб");
        Console.WriteLine("Сторона: " + Side1);
        Console.WriteLine("Высота: " + Side2);
        Console.WriteLine("Площадь: " + Area());
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание объектов каждого класса
        Figure[] figures = new Figure[4];

        Console.WriteLine("Введите стороны квадрата:");
        double side = double.Parse(Console.ReadLine());
        figures[0] = new Square(side);

        Console.WriteLine("Введите радиус круга:");
        double radius = double.Parse(Console.ReadLine());
        figures[1] = new Circle(radius);

        Console.WriteLine("Введите стороны прямоугольника:");
        double side1 = double.Parse(Console.ReadLine());
        double side2 = double.Parse(Console.ReadLine());
        figures[2] = new Quadrilateral(side1, side2);

        Console.WriteLine("Введите сторону и высоту ромба:");
        double rhombusSide = double.Parse(Console.ReadLine());
        double rhombusHeight = double.Parse(Console.ReadLine());
        figures[3] = new Rhombus(rhombusSide, rhombusHeight);

        // Вывод информации о каждой фигуре
        foreach (var figure in figures)
        {
            figure.DisplayInfo();
            Console.WriteLine();
        }
    }
}
