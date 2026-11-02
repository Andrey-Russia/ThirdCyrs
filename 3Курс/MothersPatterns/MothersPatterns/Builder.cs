using System;
using System.Collections.Generic;

class Product3
{
    private readonly List<string> _parts = new List<string>();

    public void Add(string part)
    {

        _parts.Add(part);
    }

    public override string ToString()
    {
        return string.Join(", ", _parts);
    }
}

abstract class Builder
{
    public abstract void BuildPartA();
    public abstract void BuildPartB();
    public abstract void BuildPartC();

    public abstract Product3 GetResult();
}

class ConcreteBuilder : Builder
{
    private Product3 _product = new Product3();

    public override void BuildPartA()
    {
        _product.Add("Часть A");
    }

    public override void BuildPartB()
    {
        _product.Add("Часть B");
    }

    public override void BuildPartC()
    {
        _product.Add("Часть C");
    }

    public override Product3 GetResult()
    {
        Product3 result = _product;

        _product = new Product3();

        return result;
    }
}

class Director
{
    private readonly Builder _builder;

    public Director(Builder builder)
    {
        this._builder = builder;
    }

    public void Construct()
    {
        _builder.BuildPartA();
        _builder.BuildPartB();
        _builder.BuildPartC();
    }
}

class Program4
{
    static void Main()
    {
        Builder builder = new ConcreteBuilder();

        Director director = new Director(builder);
        director.Construct();

        Product3 product = builder.GetResult();
        Console.WriteLine(product);
    }
}