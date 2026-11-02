using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creator
{
    public class Game
    {
        private readonly Random random = new Random();
        private readonly List<Enemy> enemies = new List<Enemy>();

        private int nextNumber = 1;

        public void Run()
        {
            int difficulty = ReadDifficulty();

            if (difficulty == 0)
                return;

            enemies.Clear();
            nextNumber = 1;

            int enemyCount = GetEnemyCount(difficulty);

            CreateEnemies(enemyCount);
            ShowEnemies();
            KillRandomEnemy();
            CloneRandomEnemy();
        }

        private void CreateEnemies(int count)
        {
            EnemyFactory warriorFactory = new WarriorFactory(random);
            EnemyFactory archerFactory = new ArcherFactory(random);

            int warriorCount = (count + 1) / 2;
            int archerCount = count / 2;

            enemies.AddRange(warriorFactory.CreateEnemies(warriorCount, ref nextNumber));

            enemies.AddRange(archerFactory.CreateEnemies(archerCount, ref nextNumber));
        }

        private void ShowEnemies()
        {
            Console.WriteLine($"\nСоздано врагов: {enemies.Count}");

            foreach (Enemy enemy in enemies)
            {
                enemy.ShowInfo();
            }
        }

        private void KillRandomEnemy()
        {
            int index = random.Next(enemies.Count);
            Enemy enemy = enemies[index];

            enemy.Kill();
            enemies.RemoveAt(index);

            Console.WriteLine($"\nУмер: {enemy.Name}");
        }

        private void CloneRandomEnemy()
        {
            int index = random.Next(enemies.Count);
            Enemy original = enemies[index];

            string cloneName = $"Enemy {nextNumber} (клон)";
            Enemy clone = original.Clone(cloneName);

            nextNumber++;
            enemies.Add(clone);

            Console.WriteLine($"\nКлонирован враг: {original.Name}");
            Console.WriteLine("Информация о клоне:");

            clone.ShowInfo();
        }

        private int ReadDifficulty()
        {
            Console.WriteLine("Выберите уровень сложности:");
            Console.WriteLine("1 — лёгкий: 3 врага");
            Console.WriteLine("2 — средний: 5 врагов");
            Console.WriteLine("3 — сложный: 8 врагов");

            while (true)
            {
                Console.Write("Введите 1, 2 или 3: ");

                var input = Console.ReadLine();

                if (input == null)
                    return 0;

                if (int.TryParse(input, out int difficulty) && difficulty >= 1 && difficulty <= 3)
                {
                    return difficulty;
                }

                Console.WriteLine("Ошибка: введите число от 1 до 3.");
            }
        }

        private int GetEnemyCount(int difficulty)
        {
            switch (difficulty)
            {
                case 1:
                    return 3;
                case 2:
                    return 5;
                case 3:
                    return 8;
                default:
                    throw new ArgumentException("Неизвестный уровень сложности.");
            }
        }
    }
}
