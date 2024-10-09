using System;

namespace MyDnd
{
    public class Entity
    {
        public int Age;

        public virtual void Attack(Entity entity)
        {
            Console.WriteLine("Attacking from entity");
        }
    }
    
    public class Enemy : Entity
    {
        protected readonly string Name;
        private double BaseDmg;
        private double _hp;
        private EnemyAbilities _enemyAbilities = EnemyAbilities.AttackClose | EnemyAbilities.Heal;
        public double Hp 
        { 
            get { return _hp; } 
            private set { _hp = value > 0 ? value : 0; } 
        }

        public Enemy(string name, double baseDmg, double hp)
        {
            Name = name;
            BaseDmg = baseDmg;
            Hp = hp;
        }

        public override void Attack(Entity entity)
        {
            Console.WriteLine("Attacking from Enemy");
        }

        public void Attack(Enemy enemy)
        {
            if (_enemyAbilities.HasFlag(EnemyAbilities.AttackClose))
                enemy.Hp -= BaseDmg;
            else
                Console.WriteLine($"${Name} doesn't know how to attack");
        }

        public void Attack(Player player)
        {
            
        }

        public static class Factory
        {
            public static Enemy CreateOger()
            {
                return new Enemy("Oger", 5, 50);
            }

            public static Enemy CreateGoblin()
            {
                return new Enemy("Goblic", 7, 20);
            }
        }
    }
}