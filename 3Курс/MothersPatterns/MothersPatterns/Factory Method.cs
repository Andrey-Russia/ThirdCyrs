using System;

//Общий тип объектов создаваемых фабричным методом
public abstract class Product
{

}

//конкретный продукт, мб колбаса
public class ConcreteProdcutA : Product
{

}

//2 конкретный продукт, мб хлеб
public class ConcreteProdcutB : Product
{

}

public abstract class Creator
{
    public abstract Product FactoryMethod();
}

public class ConcreteCreatorA : Creator
{
    public override Product FactoryMethod()
    {
        return new ConcreteProdcutA();
    }
}

public class ConcreteCreatorB : Creator
{
    public override Product FactoryMethod()
    {
        return new ConcreteProdcutB();
    }
}

public class Program1
{
    static void Main()
    {
        Creator creator = new ConcreteCreatorA();

        Product product = creator.FactoryMethod();
        Console.WriteLine(product.GetType().Name);

        creator = new ConcreteCreatorB();
        product = creator.FactoryMethod();
        Console.WriteLine(product.GetType().Name);
    }
}