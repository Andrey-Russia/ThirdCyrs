using System;

interface IAttackStrategy
{
    void Attack();
}

class SwordAttack : IAttackStrategy
{
    public void Attack()
    {
        Console.WriteLine("Персонаж наносит удар мечом.");
    }
}

class BowAttack : IAttackStrategy
{
    public void Attack()
    {
        Console.WriteLine("Персонаж стреляет из лука.");
    }
}

class Character
{
    private IAttackStrategy _strategy;

    public Character(IAttackStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IAttackStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Attack()
    {
        _strategy.Attack();
    }
}

class Program
{
    static void Main()
    {
        Character character = new Character(new SwordAttack());
        character.Attack();

        character.SetStrategy(new BowAttack());
        character.Attack();
    }
}