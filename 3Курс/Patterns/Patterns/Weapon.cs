using System;

namespace Creator
{
    public class Weapon
    {
        public string Name { get; }
        public int Damage { get; }

        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public Weapon Clone()
        {
            return new Weapon(Name, Damage);
        }
    }
}