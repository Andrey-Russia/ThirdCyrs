using System;
using System.Globalization;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Учёт имущества налогоплательщика");
        Console.WriteLine();

        Console.Write("Введите ФИО владельца: ");
        string fullName = ReadNotEmptyString();

        Taxpayer taxpayer = new Taxpayer(fullName);

        bool programIsRunning = true;

        while (programIsRunning)
        {
            ShowMenu(taxpayer);

            int command = ReadInteger("Выберите пункт: ", 0, 4);

            switch (command)
            {
                case 1:
                    AddProperty(taxpayer);
                    break;

                case 2:
                    ShowAllProperties(taxpayer);
                    break;

                case 3:
                    ShowTotalTax(taxpayer);
                    break;

                case 4:
                    ShowTotalTaxWithDiscount(taxpayer);
                    break;

                case 0:
                    programIsRunning = false;
                    Console.WriteLine("Программа завершена.");
                    break;
            }
        }
    }

    private static void ShowMenu(Taxpayer taxpayer)
    {
        Console.WriteLine();
        Console.WriteLine($"Владелец: {taxpayer.FullName}");
        Console.WriteLine($"Количество объектов: {taxpayer.PropertyCount}/10");
        Console.WriteLine();
        Console.WriteLine("1 — Добавить имущество");
        Console.WriteLine("2 — Показать всё имущество");
        Console.WriteLine("3 — Рассчитать общий налог");
        Console.WriteLine("4 — Рассчитать общий налог с льготой");
        Console.WriteLine("0 — Выход");
        Console.WriteLine();
    }

    private static void AddProperty(Taxpayer taxpayer)
    {
        if (taxpayer.PropertyCount >= 10)
        {
            Console.WriteLine(
                "Добавлено максимальное количество объектов.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Выберите тип имущества:");
        Console.WriteLine("1 — Квартира");
        Console.WriteLine("2 — Дача");
        Console.WriteLine("3 — Автомобиль");
        Console.WriteLine("4 — Лодка");

        int type = ReadInteger("Тип имущества: ", 1, 4);
        decimal worth = ReadPositiveDecimal("Введите стоимость: ");

        Property property;

        switch (type)
        {
            case 1:
                {
                    decimal area = ReadPositiveDecimal("Введите площадь квартиры: ");

                    property = new Appartment(worth, area);
                    break;
                }

            case 2:
                {
                    decimal area = ReadPositiveDecimal("Введите площадь дачи: ");

                    property = new CountryHouse(worth, area);
                    break;
                }

            case 3:
                {
                    decimal engineVolume = ReadPositiveDecimal("Введите объём двигателя автомобиля: ");

                    property = new Car(worth, engineVolume);
                    break;
                }

            default:
                {
                    decimal engineVolume = ReadPositiveDecimal("Введите объём двигателя лодки: ");

                    property = new Boat(worth, engineVolume);
                    break;
                }
        }

        taxpayer.AddProperty(property);

        Console.WriteLine("Имущество успешно добавлено.");
    }

    private static void ShowAllProperties(Taxpayer taxpayer)
    {
        Console.WriteLine();
        Console.WriteLine($"Имущество владельца: {taxpayer.FullName}");

        if (taxpayer.PropertyCount == 0)
        {
            Console.WriteLine("Список имущества пуст.");
            return;
        }

        for (int i = 0; i < taxpayer.PropertyCount; i++)
        {
            Property property = taxpayer.GetProperty(i);
            Console.WriteLine($"{i + 1}. {property}");
        }
    }

    private static void ShowTotalTax(Taxpayer taxpayer)
    {
        decimal totalTax = taxpayer.CalculateTotalTax();

        Console.WriteLine();
        Console.WriteLine($"Общий налог: {totalTax:F2}");
    }

    private static void ShowTotalTaxWithDiscount(
        Taxpayer taxpayer)
    {
        decimal discount = ReadPercent("Введите размер льготы от 0 до 100%: ");

        decimal totalTax = taxpayer.CalculateTotalTax(discount);

        Console.WriteLine();
        Console.WriteLine($"Общий налог с льготой {discount:F2}%: " + $"{totalTax:F2}");
    }

    private static string ReadNotEmptyString()
    {
        while (true)
        {
            string? value = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(value))
                return value.Trim();

            Console.Write("Строка не может быть пустой. Повторите ввод: ");
        }
    }

    private static int ReadInteger(
        string message,
        int minimum,
        int maximum)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            bool isCorrect = int.TryParse(input,out int number);

            if (isCorrect && number >= minimum && number <= maximum)
            {
                return number;
            }

            Console.WriteLine($"Введите целое число от {minimum} до {maximum}.");
        }
    }

    private static decimal ReadPositiveDecimal(string message)
    {
        while (true)
        {
            Console.Write(message);

            string input = (Console.ReadLine() ?? "").Replace(',', '.');

            bool isCorrect = decimal.TryParse(input,NumberStyles.Number,CultureInfo.InvariantCulture,out decimal number);

            if (isCorrect && number > 0)
                return number;

            Console.WriteLine("Введите положительное число.");
        }
    }

    private static decimal ReadPercent(string message)
    {
        while (true)
        {
            Console.Write(message);

            string input = (Console.ReadLine() ?? "").Replace(',', '.');

            bool isCorrect = decimal.TryParse(input,NumberStyles.Number,CultureInfo.InvariantCulture,out decimal percent);

            if (isCorrect && percent >= 0 && percent <= 100)
                return percent;

            Console.WriteLine("Введите число от 0 до 100.");
        }
    }
}