using System;
using System.Security.Principal;

public class Program
{
    public static void Main()
    {
        IntArrayList list = new IntArrayList();
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            PrintList(list);
            PrintMenu();

            int command = ReadInt("Выберите действие: ");
            Console.WriteLine();

            switch (command)
            {
                case 1:
                    {
                        int value = ReadInt("Введите число: ");
                        list.PushBack(value);

                        Console.WriteLine("Элемент добавлен.");
                        break;
                    }

                case 2:
                    {
                        if (list.Count == 0)
                            Console.WriteLine("Список уже пуст.");
                        else
                            list.PopBack();
                            Console.WriteLine("Последний элемент удалён.");

                        break;
                    }

                case 3:
                    {
                        int index = ReadInt("Введите индекс: ");
                        int value = ReadInt("Введите число: ");

                        bool result = list.TryInsert(index, value);

                        if (result)
                            Console.WriteLine("Элемент вставлен.");
                        else
                            Console.WriteLine("Недопустимый индекс.");

                        break;
                    }

                case 4:
                    {
                        int index = ReadInt("Введите индекс: ");

                        bool result = list.TryErase(index);

                        if (result)

                            Console.WriteLine("Элемент удалён.");
                        else
                            Console.WriteLine("Элемента с таким индексом нет.");

                        break;
                    }

                case 5:
                    {
                        int index = ReadInt("Введите индекс: ");
                        int value;

                        bool result = list.TryGetAt(index, out value);

                        if (result)
                            Console.WriteLine("Значение: " + value);
                        else
                            Console.WriteLine("Элемента с таким индексом нет.");

                        break;
                    }

                case 6:
                    {
                        int index = ReadInt("Введите индекс: ");
                        int oldValue;

                        if (list.TryGetAt(index, out oldValue))
                        {
                            int newValue = ReadInt("Введите новое значение: ");
                            list[index] = newValue;

                            Console.WriteLine("Значение " + oldValue + " заменено на " + newValue + "."
                            );
                        }
                        else
                            Console.WriteLine("Элемента с таким индексом нет.");

                        break;
                    }

                case 7:
                    {
                        int value = ReadInt("Введите число для поиска: ");
                        int index = list.Find(value);

                        if (index == -1)
                            Console.WriteLine("Такого числа в списке нет.");
                        else
                            Console.WriteLine("Первый найденный индекс: " + index);

                        break;
                    }

                case 8:
                    {
                        int newCapacity = ReadInt("Введите новую Capacity: ");

                        bool result = list.TryForceCapacity(newCapacity);

                        if (result)
                        {
                            Console.WriteLine("Размер буфера изменён.");

                            if (list.Count == list.Capacity)
                                Console.WriteLine("Если буфер был уменьшен, лишние элементы удалены.");
                        }
                        else
                            Console.WriteLine("Capacity не может быть отрицательной.");

                        break;
                    }

                case 9:
                    {
                        list.Clear();
                        Console.WriteLine("Список очищен.");
                        break;
                    }

                case 10:
                    {
                        PrintList(list);
                        break;
                    }

                case 0:
                    {
                        isRunning = false;
                        Console.WriteLine("Программа завершена.");
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Неизвестная команда.");
                        break;
                    }
            }

            if (isRunning)
            {
                Console.WriteLine();
                Console.WriteLine("Нажмите Enter, чтобы продолжить...");
                Console.ReadLine();
            }
        }
    }

    private static void PrintMenu()
    {
        Console.WriteLine("1  - Добавить элемент в конец");
        Console.WriteLine("2  - Удалить последний элемент");
        Console.WriteLine("3  - Вставить элемент по индексу");
        Console.WriteLine("4  - Удалить элемент по индексу");
        Console.WriteLine("5  - Получить элемент по индексу");
        Console.WriteLine("6  - Изменить элемент по индексу");
        Console.WriteLine("7  - Найти элемент");
        Console.WriteLine("8  - Изменить Capacity");
        Console.WriteLine("9  - Очистить список");
        Console.WriteLine("10 - Показать список");
        Console.WriteLine("0  - Завершить программу");
        Console.WriteLine();
    }

    private static void PrintList(IntArrayList list)
    {
        Console.Write("Элементы: [");

        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i]);

            if (i < list.Count - 1)
                Console.Write(", ");
        }

        Console.WriteLine("]");
        Console.WriteLine("Count: " + list.Count);
        Console.WriteLine("Capacity: " + list.Capacity);
        Console.WriteLine();
    }

    private static int ReadInt(string message)
    {
        int number;
        bool isNumber;

        do
        {
            Console.Write(message);
            string input = Console.ReadLine();

            isNumber = int.TryParse(input, out number);

            if (!isNumber)
                Console.WriteLine("Ошибка: введите целое число.");
        }
        while (!isNumber);

        return number;
    }
}

public class IntArrayList
{
    private int[] _buffer;
    private int _count;
    private int _capacity;
    private readonly int _defaultCapacity = 2;

    public int Count
    {
        get { return _count; }
    }

    public int Capacity
    {
        get { return _capacity;}
    }

    public int this[int index]
    {
        get { return _buffer[index]; }
        set { _buffer[index] = value; }
    }

    public IntArrayList()
    {
        _capacity = _defaultCapacity;
        _buffer = new int[_capacity];
        _count = 0;
    }

    public IntArrayList(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity));

        _capacity = capacity;
        _buffer = new int[_capacity];
        _count = 0;         
    }

    public void PushBack(int value)
    {
        if (_count == _capacity)
        {
            int newCapacity;

            if (_capacity == 0)
                newCapacity = _defaultCapacity;
            else
                newCapacity = _capacity * 2;

            int[] newBuffer = new int[newCapacity];

            for (int i = 0; i < _capacity; i++)
                newBuffer[i] = _buffer[i];

            _buffer = newBuffer;
            _capacity = newCapacity;
        }

        _buffer[_count] = value;
        _count++;
    }

    public void PopBack()
    {
        if (_count == 0)
            return;

        _count--;
        _buffer[_count] = 0;
    }

    public bool TryInsert(int index, int value)
    {
        if (index < 0 || index > _count)
            return false;

        if (index == _count)
        {
            PushBack(value);
            return true;
        }

        if (_count == _capacity)
        {
            int newCapacity;

            if (_capacity == 0)
                newCapacity = _defaultCapacity;
            else
                newCapacity = _capacity * 2;

            int[] newBuffer = new int[newCapacity];

            for (int i = 0; i < _count; i++)
                newBuffer[i] = _buffer[i];

            _buffer = newBuffer;
            _capacity = newCapacity;
        }

        for (int i = _count; i > index; i--)
            _buffer[i] = _buffer[i - 1];

        _buffer[index] = value;
        _count++;

        return true;
    }

    public bool TryErase(int index)
    {
        if (index < 0 || index >= _count)
            return false;

        for (int i = index; i < _count - 1; i++)
            _buffer[i] = _buffer[i + 1];

        _count--;
        return true;
    }

    public bool TryGetAt(int index, out int result)
    {
        if (index < 0 || index >= _count)
        {
            result = 0;
            return false;
        }

        result = _buffer[index];
        return true;
    }

    public void Clear()
    {
        _count = 0;
    }

    public bool TryForceCapacity(int newCapacity)
    {
        if (newCapacity < 0)
            return false;

        int[] newBuffer = new int[newCapacity];

        int elementsToCopy = _count;

        if (elementsToCopy > newCapacity)
            elementsToCopy = newCapacity;

        for (int i = 0; i < elementsToCopy; i++)
            newBuffer[i] = _buffer[i];

        _buffer = newBuffer;
        _capacity = newCapacity;
        _count = elementsToCopy;

        return true;
    }

    public int Find(int value)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_buffer[i] == value)
                return i;
        }

        return -1;
    }
}