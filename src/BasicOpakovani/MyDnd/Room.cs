using System.Runtime.Serialization;

namespace MyDnd
{
    public class Room
    {
        private Enemy myEnemy;
        private string Treasure;

        public Room()
        {
        }

        public Room(Enemy myEnemy)
        {
            this.myEnemy = myEnemy;
        }

        public Room(string treasure)
        {
            Treasure = treasure;
        }

        public static class Factory
        {
            public static Room CreateHub()
            {
                return new Room();
            }
            public static Room CreateEnemyRoom()
            {
                Enemy roomEnemy = Enemy.Factory.CreateGoblin();
                return new Room(roomEnemy);
            }

            public static Room CreateTreasureRoom()
            {
                string treasure = "money";
                return new Room(treasure);
            }
        }
    }


}