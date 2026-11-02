using System;
using System.Runtime.CompilerServices;

public abstract class AbstractProductA
{

}

public abstract class AbstractProductB
{

}

public class ProductA1 : AbstractProductA
{

}
public class ProductB1 : AbstractProductB
{

}

public class ProductA2 : AbstractProductA
{

}

public class ProductB2 : AbstractProductB
{

}

public abstract class AbstractFactory
{
    public abstract AbstractProductA CreateProductA();
    public abstract AbstractProductB CreateProductB();
}

public class ConcreteFactory1 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ProductA1();
    }

    public override AbstractProductB CreateProductB()
    {
        return new ProductB1();
    }
}

public class ConcreteFactory2 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ProductA2();
    }

    public override AbstractProductB CreateProductB()
    {
        return new ProductB2();
    }
}

public class Client1
{
    private readonly AbstractProductA abstractProductA;
    private readonly AbstractProductB abstractProductB;

    public Client1(AbstractFactory factory)
    {
        abstractProductA = factory.CreateProductA();
        abstractProductB = factory.CreateProductB();
    }

    public void Run()
    {
       
        Console.WriteLine($"A: {abstractProductA.GetType().Name}, " + $"B: {abstractProductB.GetType().Name}");
    }
}

public class Program3
{
    static void Main()
    {
        Client1 client1 = new Client1(new ConcreteFactory1());
        client1.Run();

        Client1 client2 = new Client1(new ConcreteFactory2());
        client2.Run();
    }
}