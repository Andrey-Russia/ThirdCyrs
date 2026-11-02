using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creator
{
    public abstract class Enemy
    {
        public string Name { get; }
        public int Health { get; private set; }
        public Weapon Weapon { get; }

        public bool IsAlive => Health > 0;

        public abstract string Type { get; }

        protected Enemy(string name, int health, Weapon weapon)
        {
            Name = name;
            Health = health;
            Weapon = weapon;
        }

        public void Kill()
        {
            Health = 0;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} | Тип: {Type} | Здоровье: {Health} | " + $"Оружие: {Weapon.Name} | Урон: {Weapon.Damage}");
        }

        public abstract Enemy Clone(string newName);

        protected void CheckCloneName(string newName)
        {
            if (!IsAlive)
                throw new InvalidOperationException("Нельзя клонировать мёртвого врага.");

            if (string.IsNullOrWhiteSpace(newName) || newName == Name)
                throw new ArgumentException("Клону нужно дать новое непустое имя.");
        }
    }
}
