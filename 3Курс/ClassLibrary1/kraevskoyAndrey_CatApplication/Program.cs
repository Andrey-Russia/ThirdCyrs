using KraevskoyAndrey_CatFramework;
using System.Text;

namespace KraevskoyAndrey_CatApplication
{
    internal class Program
    {
        private static readonly Random random = new Random();

        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            uint catCount;

            while (true)
            {
                Console.Write("Введите количество кошачьих: ");
                string? input = Console.ReadLine();

                if (input is null)
                {
                    return;
                }

                if (uint.TryParse(input, out catCount)
                    && catCount <= int.MaxValue)
                {
                    break;
                }

                Console.WriteLine($"Введите целое число от 0 до {int.MaxValue}.");
            }

            Cat[] cats = GenerateRandomCats(catCount);

            while (true)
            {
                Console.Write("Введите путь к файлу: ");
                string? path = Console.ReadLine();

                if (path is null)
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine("Путь не должен быть пустым.");
                    continue;
                }

                try
                {
                    DisplayCatInfo(cats, path);
                    Console.WriteLine("Результаты сохранены.");
                    break;
                }
                catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException || exception is ArgumentException || exception is NotSupportedException)
                {
                    Console.WriteLine($"Не удалось записать файл: {exception.Message}");
                }
            }
        }

        public static Cat[] GenerateRandomCats(uint count)
        {
            if (count > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(count),"Количество элементов не должно превышать Int32.MaxValue.");
            }

            Cat[] cats = new Cat[(int)count];

            for (int i = 0; i < cats.Length; i++)
            {
                bool createTiger = random.Next(0, 2) == 0;

                while (true)
                {
                    try
                    {
                        int fluffiness = random.Next(-20, 121);

                        if (createTiger)
                        {
                            double weight = random.Next(50, 161);

                            cats[i] = new Tiger(weight, fluffiness);
                        }
                        else
                        {
                            cats[i] = new CuteCat(fluffiness);
                        }

                        break;
                    }
                    catch (CatException exception)
                    {
                        Console.WriteLine(
                            $"Возникло исключение CatException: {exception.Message}");
                    }
                }
            }

            return cats;
        }

        public static void DisplayCatInfo(Cat[] catsArr, string path)
        {
            using (var writer = new StreamWriter(path, append: false,encoding: Encoding.UTF8))
            {
                foreach (Cat cat in catsArr)
                {
                    string fluffinessInfo = cat.FluffinessCheck();
                    string description = cat.ToString();

                    Console.WriteLine(fluffinessInfo);
                    Console.WriteLine(description);

                    writer.WriteLine(fluffinessInfo);
                    writer.WriteLine(description);
                }
            }
        }
    }
}