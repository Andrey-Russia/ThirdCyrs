using System;

interface ICommand
{
    void Execute();
}

class Lamp
{
    public void TurnOn()
    {
        Console.WriteLine("Лампа включена.");
    }

    public void TurnOff()
    {
        Console.WriteLine("Лампа выключена.");
    }
}

class TurnOnCommand : ICommand
{
    private readonly Lamp _lamp;

    public TurnOnCommand(Lamp lamp)
    {
        _lamp = lamp;
    }

    public void Execute()
    {
        _lamp.TurnOn();
    }
}

class TurnOffCommand : ICommand
{
    private readonly Lamp _lamp;

    public TurnOffCommand(Lamp lamp)
    {
        _lamp = lamp;
    }

    public void Execute()
    {
        _lamp.TurnOff();
    }
}

class RemoteControl
{
    private ICommand _command;

    public RemoteControl(ICommand command)
    {
        _command = command;
    }

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }
}

class Program1
{
    static void Main()
    {
        Lamp lamp = new Lamp();

        ICommand turnOn = new TurnOnCommand(lamp);
        ICommand turnOff = new TurnOffCommand(lamp);

        RemoteControl remote = new RemoteControl(turnOn);
        remote.PressButton();

        remote.SetCommand(turnOff);
        remote.PressButton();
    }
}