using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creator
{
    public class Archer : Enemy
    {
        public override string Type => "Лучник";

        public Archer(string name, int health) : base(name, health, new Weapon("Лук из рога оленя.", 35))
        {

        }

        private Archer(string name, int health, Weapon weapon): base(name, health, weapon)
        {

        }

        public override Enemy Clone(string newName)
        {
            CheckCloneName(newName);

            return new Archer(newName, Health, Weapon.Clone());
        }
    }
}
