using System;

// Создаёт базовую структуру для копирования объектов
public abstract class Prototype
{
    public int Id { get; }

    public Prototype(int id)
    {
        Id = id;
    }

    public abstract Prototype Clone();
}

//Первый вариант прототипа 
//при копировании создаёт новый объект совего класса
public class ConcretePrototype1 : Prototype
{
    public ConcretePrototype1(int id) : base(id)
    {

    }

    public override Prototype Clone()
    {
        return new ConcretePrototype1(Id);
    }
}

//Второй вариант прототипа 
//при копировании создаёт новый объект совего класса
public class ConcretePrototype2 : Prototype
{
    public ConcretePrototype2(int id) : base(id)
    {

    }

    public override Prototype Clone()
    {
        return new ConcretePrototype2(Id);
    }
}

//Клиент получает протоип и просит сделать его копию
//для любого наследника прототипа подходит
public class Client
{
    public void Operation(Prototype original)
    {
        Prototype copy = original.Clone();

        Console.WriteLine($"Тип копии: {copy.GetType().Name}");
        Console.WriteLine($"Id копии: {copy.Id}");
        Console.WriteLine($"Это тот же объект: {ReferenceEquals(original, copy)}");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // Создаём исходный образец и передаём его клиенту
        Prototype original = new ConcretePrototype1(10);

        Client client = new Client();
        client.Operation(original);
    }
}