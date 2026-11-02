using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creator
{
    public abstract class EnemyFactory
    {
        protected Random Random { get; }

        protected EnemyFactory(Random random)
        {
            Random = random;
        }

        public abstract Enemy CreateEnemy(string name);

        public List<Enemy> CreateEnemies(int count, ref int nextNumber)
        {
            List<Enemy> enemies = new List<Enemy>();

            for (int i = 0; i < count; i++)
            {
                Enemy enemy = CreateEnemy($"Enemy {nextNumber}");

                enemies.Add(enemy);
                nextNumber++;
            }

            return enemies;
        }
    }
}
