using System;

// Абстрактный класс
abstract class BinaryBase
{
    public abstract void Input();
    public abstract void Display();
    public abstract double ToDecimal();
}

// Интерфейс
interface IBinaryOperations
{
    string Sum(Binary1 other);
    string Multiply(Binary1 other);
}

class Binary1 : BinaryBase, IBinaryOperations
{
    private string integerPart;
    private string fractionalPart;

    public Binary1()
    {
        integerPart = "";
        fractionalPart = "";
    }

    public override void Input()
    {
        Console.WriteLine("Введите целую часть двоичного числа:");
        integerPart = Console.ReadLine();

        Console.WriteLine("Введите дробную часть двоичного числа:");
        fractionalPart = Console.ReadLine();
    }

    public override void Display()
    {
        Console.WriteLine($"Двоичное число: {integerPart}.{fractionalPart}");
    }

    public override double ToDecimal()
    {
        double integerPartDecimal = 0;
        for (int i = integerPart.Length - 1, j = 0; i >= 0; i--, j++)
        {
            if (integerPart[i] == '1')
                integerPartDecimal += Math.Pow(2, j);
        }

        double fractionalPartDecimal = 0;
        for (int i = 0; i < fractionalPart.Length; i++)
        {
            if (fractionalPart[i] == '1')
                fractionalPartDecimal += Math.Pow(2, -(i + 1));
        }

        return integerPartDecimal + fractionalPartDecimal;
    }

    public string Sum(Binary1 other)
    {
        double result = this.ToDecimal() + other.ToDecimal();
        return ConvertDecimalToBinary(result);
    }

    public string Multiply(Binary1 other)
    {
        double result = this.ToDecimal() * other.ToDecimal();
        return ConvertDecimalToBinary(result);
    }

    // Десятичное число в двоичное
    private string ConvertDecimalToBinary(double decimalNumber)
    {
        int intPart = (int)decimalNumber;
        double fractionalPart = decimalNumber - intPart;

        string binaryIntPart = Convert.ToString(intPart, 2);

        string binaryFractionalPart = "";
        while (fractionalPart > 0)
        {
            fractionalPart *= 2;
            if (fractionalPart >= 1)
            {
                binaryFractionalPart += "1";
                fractionalPart -= 1;
            }
            else
            {
                binaryFractionalPart += "0";
            }
        }

        return binaryFractionalPart.Length > 0 ? binaryIntPart + "." + binaryFractionalPart : binaryIntPart;
    }

    // Деструктор
    ~Binary1()
    {
        Console.WriteLine("Подчищено.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите первое двоичное число:");
        Binary1 binary1 = new Binary1();
        binary1.Input();

        Console.WriteLine("Введите второе двоичное число:");
        Binary1 binary2 = new Binary1();
        binary2.Input();

        Console.WriteLine("\nВведенные числа:");
        binary1.Display();
        binary2.Display();

        Console.WriteLine("\nСумма чисел: " + binary1.Sum(binary2));
        Console.WriteLine("Произведение чисел: " + binary1.Multiply(binary2));
    }
}
