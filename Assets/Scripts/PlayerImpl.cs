using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
namespace SnakeGame
{
    public class PlayerImpl:NetworkBehaviour
    {

        private readonly Dictionary<uint ,SnakeImpl> snakes = new Dictionary<uint, SnakeImpl>();
        private readonly PlayerTracker tracker;
        private string name;
        private bool ompCapable;
        private readonly object locker=new object();
        private Color snakesColor;


        

        public PlayerImpl ()
        {
            this.tracker = new PlayerTracker(this);

        }

        public string getAddress()
        {
            return null;
        }

        public NetworkConnection getConnection()
        {
            if(isServer)
            {
                return connectionToClient;
            }
            return null;
            
        }

        public void addSnake(SnakeImpl snake)
        {
            snakes.Add(snake.getID(), snake);
            tracker.updateView();
            tracker.updateNodes();
        }

        public void removeSnake(SnakeImpl snake)
        {
            snakes.Remove(snake.getID());
            tracker.updateView();
            tracker.updateNodes();
        }

        public void removeSnake(uint entityId)
        {
            snakes.Remove(entityId);
        }
        public uint getSnakeIdAt(int index)
        {
            uint[] keys = new uint[snakes.Keys.Count];
            snakes.Keys.CopyTo(keys,0);
            if(index>=0&&index<keys.Length)
            {
                return keys[index];
            }
            return 0;
            
        }

        public float getTotalMass()
        {
            float totalMass = 0;
            foreach (var snake in getSnakes())
            {
                totalMass += snake.getMass();
            }
            return totalMass;
        }

        public ICollection<SnakeImpl> getSnakes()
        {
            return snakes.Values;
        }


        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public PlayerTracker getTracker()
        {
            return tracker;
        }

        public void setSnakeColor(Color color)
        {
            snakesColor = color;
        }
        public Color getSnakesColor()
        {
            return snakesColor;
        }
    }
}

