using System;

namespace MyDnd
{
    public class Program
    {

        

        static void Main(string[] args)
        {

            Room startRoom = Room.Factory.CreateHub();
            Player player = new Player(startRoom);

            Room nextRoom = Room.Factory.CreateEnemyRoom();
            player.Move(nextRoom);

            for (int i = 0; i < 10; i++)
            {
                Random rd = new Random();

                int number = rd.Next(2);


        }
        }

    }
    
}