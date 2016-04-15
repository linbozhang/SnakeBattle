using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace SnakeGame
{
    public class PlayerList
    {
        private readonly ClitherServer server;
        private IList<PlayerImpl> players = new List<PlayerImpl>();

        public PlayerList(ClitherServer server)
        {
            this.server = server;
        }

        public ICollection<PlayerImpl> getAllPlayers()
        {
            return players;
        }

        public  void addPlayer(PlayerImpl player)
        {
            players.Add(player);
        }
        public void removePlayer(PlayerImpl player)
        {
            players.Remove(player);
            if(player!=null)
            {
                foreach(Snake snake in player.getSnakes())
                {
                    server.getWorld().removeEntity(null);
                }
                    
            }
        }

        public void sendToAll()
        {

        }
    }
}

