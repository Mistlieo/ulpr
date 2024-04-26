using System;

namespace lab_8_1
{
    public interface IDate
    {
        void InputDate();
        void OutputDate();
        void AddDays(int days);
        void SubtractDays(int days);
        bool IsLeapYear();
        int GetYear();
        int GetMonth();
        int GetDay();
        int CompareTo(IDate other);
        int DaysBetween(IDate other);
    }

    // Абстрактный класс, реализующий базовые методы работы с датами
    public abstract class DateBase : IDate
    {
        protected int year;
        protected int month;
        protected int day;

        public abstract void InputDate();
        public abstract void OutputDate();

        public virtual void AddDays(int days)
        {
            DateTime dt = new DateTime(GetYear(), GetMonth(), GetDay());
            dt = dt.AddDays(days);
            year = dt.Year;
            month = dt.Month;
            day = dt.Day;
        }

        public virtual void SubtractDays(int days)
        {
            DateTime dt = new DateTime(GetYear(), GetMonth(), GetDay());
            dt = dt.AddDays(-days);
            year = dt.Year;
            month = dt.Month;
            day = dt.Day;
        }

        public virtual bool IsLeapYear()
        {
            return DateTime.IsLeapYear(GetYear());
        }

        public int GetYear()
        {
            return year;
        }

        public int GetMonth()
        {
            return month;
        }

        public int GetDay()
        {
            return day;
        }

        public virtual int CompareTo(IDate other)
        {
            DateBase otherDate = (DateBase)other;
            DateTime thisDate = new DateTime(GetYear(), GetMonth(), GetDay());
            DateTime thatDate = new DateTime(otherDate.GetYear(), otherDate.GetMonth(), otherDate.GetDay());
            return thisDate.CompareTo(thatDate);
        }

        public virtual int DaysBetween(IDate other)
        {
            DateBase otherDate = (DateBase)other;
            DateTime startDate = new DateTime(GetYear(), GetMonth(), GetDay());
            DateTime endDate = new DateTime(otherDate.GetYear(), otherDate.GetMonth(), otherDate.GetDay());
            TimeSpan span = endDate - startDate;
            return span.Days;
        }

        ~DateBase()
        {
            Console.WriteLine("Подчищено.");
        }
    }

    // Класс, реализующий операции работы с датами
    public class Date : DateBase
    {
        public override void InputDate()
        {
            Console.Write("Введите год: ");
            year = int.Parse(Console.ReadLine());

            Console.Write("Введите месяц: ");
            month = int.Parse(Console.ReadLine());

            Console.Write("Введите день: ");
            day = int.Parse(Console.ReadLine());
        }

        public override void OutputDate()
        {
            Console.WriteLine($"Дата: {GetYear()}.{GetMonth()}.{GetDay()}");
        }

        public override bool IsLeapYear()
        {
            return (GetYear() % 4 == 0 && (GetYear() % 100 != 0 || GetYear() % 400 == 0));
        }

        public override int CompareTo(IDate other)
        {
            DateBase otherDate = (DateBase)other;
            if (GetYear() != otherDate.GetYear())
                return GetYear().CompareTo(otherDate.GetYear());
            if (GetMonth() != otherDate.GetMonth())
                return GetMonth().CompareTo(otherDate.GetMonth());
            return GetDay().CompareTo(otherDate.GetDay());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Date date1 = new Date();
            Date date2 = new Date();

            Console.WriteLine("Введите первую дату:");
            date1.InputDate();

            Console.WriteLine("Введите вторую дату:");
            date2.InputDate();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Вычисление даты через заданное количество дней от указанной");
                Console.WriteLine("2. Вычитание заданного количества дней из даты");
                Console.WriteLine("3. Определение високосного года");
                Console.WriteLine("4. Просмотр года, месяца и дня");
                Console.WriteLine("5. Сравнение дат");
                Console.WriteLine("6. Вычисление количества дней между датами");
                Console.WriteLine("7. Выйти");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите количество дней для добавления к первой дате: ");
                        int daysToAdd = int.Parse(Console.ReadLine());
                        date1.AddDays(daysToAdd);
                        date1.OutputDate();
                        break;
                    case 2:
                        Console.Write("Введите количество дней для вычитания из второй даты: ");
                        int daysToSubtract = int.Parse(Console.ReadLine());
                        date2.SubtractDays(daysToSubtract);
                        date2.OutputDate();
                        break;
                    case 3:
                        if (date1.IsLeapYear())
                            Console.WriteLine("Первый год является високосным.");
                        else
                            Console.WriteLine("Первый год не является високосным.");
                        if (date2.IsLeapYear())
                            Console.WriteLine("Второй год является високосным.");
                        else
                            Console.WriteLine("Второй год не является високосным.");
                        break;
                    case 4:
                        Console.WriteLine($"Год первой даты: {date1.GetYear()}");
                        Console.WriteLine($"Месяц первой даты: {date1.GetMonth()}");
                        Console.WriteLine($"День первой даты: {date1.GetDay()}");
                        Console.WriteLine($"Год второй даты: {date2.GetYear()}");
                        Console.WriteLine($"Месяц второй даты: {date2.GetMonth()}");
                        Console.WriteLine($"День второй даты: {date2.GetDay()}");
                        break;
                    case 5:
                        int result = date1.CompareTo(date2);
                        if (result < 0)
                            Console.WriteLine("Первая дата меньше второй.");
                        else if (result > 0)
                            Console.WriteLine("Первая дата больше второй.");
                        else
                            Console.WriteLine("Даты равны.");
                        break;
                    case 6:
                        Console.WriteLine($"Дней между датами: {date1.DaysBetween(date2)}");
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор операции.");
                        break;
                }
            }
        }
    }
}