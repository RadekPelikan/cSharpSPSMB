using System.Runtime.CompilerServices;

namespace MyDnd
{
    public class Player
    {
        private Room currentRoom;

        public Player(Room currentRoom)
        {
            this.currentRoom = currentRoom;
        }

        public void Move(Room nextRoom)
        {
            currentRoom = nextRoom;
        }
    
    }
}