using UnityEngine;
using System.Collections;

namespace SnakeGame
{

    public class GameConfig
    {
        public WorldC world = new WorldC();
        public PlayerC palyer = new PlayerC();
        public ServerC server = new ServerC();
    }

    public class WorldC
    {
        public ViewC view = new ViewC();
        public BorderC border = new BorderC();
        public FoodC food = new FoodC();


    }

    public class ServerC
    {
        public int port = 8081;
        public int maxConnections = 100;
        public string id = "localhost";
        public string name = "Unknown Server";
    }

    public class PlayerC
    {
        public int startMass = 35;
        public int maxMass = 255000;
        public int maxNickLength = 15;
    }

    public class ViewC
    {
        public float baseX = 1024;
        public float baseY = 592;

    }

    public class BorderC
    {
        public float left = 0;
        public float right = 6000;
        public float top = 0;
        public float bottom = 6000;
    }

    public class FoodC
    {
        public int spawnInterval = 20;
        public int spawnPerInterval = 10;
        public int startAmout = 100;
        public int maxAmount = 500;
        public int foodSize = 1;
    }
}


