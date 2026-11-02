using Creator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creator
{
    public class ArcherFactory : EnemyFactory
    {
        public ArcherFactory(Random random) : base(random)
        {
        }

        public override Enemy CreateEnemy(string name)
        {
            int health = Random.Next(50, 101);

            return new Archer(name, health);
        }
    }
}
