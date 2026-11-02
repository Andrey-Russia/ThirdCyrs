using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creator
{
    public class WarriorFactory : EnemyFactory
    {
        public WarriorFactory(Random random) : base(random)
        {

        }

        public override Enemy CreateEnemy(string name)
        {
            int health = Random.Next(80, 151);

            return new Warrior(name, health);
        }
    }
}
