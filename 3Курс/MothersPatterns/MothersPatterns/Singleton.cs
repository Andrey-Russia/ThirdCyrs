using System;

sealed class Singleton
{
    private static readonly Lazy<Singleton> _singletonInstance = new Lazy<Singleton>(() => new Singleton());

    private Singleton()
    {

    }

    public static Singleton GetInstance()
    {
        return _singletonInstance.Value;
    }
}

class Client5
{
    public void Operation()
    {
        Singleton first = Singleton.GetInstance();
        Singleton second = Singleton.GetInstance();

        Console.WriteLine(ReferenceEquals(first, second));
    }
}

class Program5
{
    static void Main()
    {
        Client5 client = new Client5();
        client.Operation();
    }
}