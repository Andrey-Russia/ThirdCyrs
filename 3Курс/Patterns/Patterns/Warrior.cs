using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creator   
{
    public class Warrior : Enemy
    {
        public override string Type => "Воин";

        public Warrior(string name, int health) : base (name, health, new Weapon("Меч", 25))
        {

        }

        private Warrior(string name, int health, Weapon weapon) : base(name, health, weapon)
        {

        }

        public override Enemy Clone(string newName)
        {
            CheckCloneName(newName);

            return new Warrior(newName, Health, Weapon.Clone());
        }
    }
}
