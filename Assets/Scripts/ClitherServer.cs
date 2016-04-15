using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
namespace SnakeGame
{
    public class ClitherServer:NetworkBehaviour
    {
        private static ClitherServer instance;
        public readonly PlayerList playerList;// = new PlayerList(this);
        
        private WorldImpl world;
        private GameConfig configuration;
        private long tick = 0L;
        private bool running;

        private ClitherServer()
        {
            playerList = new PlayerList(instance);
        }

        public static ClitherServer getInstance()
        {
            if(instance==null)
            {
                instance = new ClitherServer();
               
            }
            return instance;
        }

        public PlayerList getPlayerList()
        {
            return playerList;
        }

        public WorldImpl getWorld()
        {
            return world;
        }

        public void loadConfig()
        {
            this.configuration = Configuration.load();
        }

        public GameConfig getConfig()
        {
            return configuration;
        }

        public long getTick()
        {
            return tick;
        }

        public void run()
        {
            loadConfig();

            Debug.Log("start server run");

            world = new WorldImpl(this);


        }


        public GameObject spawn( GameObject prefab, Position position )
        {
            GameObject obj = (GameObject)Instantiate(prefab, new Vector3(position.x/100,position.y/100,0), Quaternion.identity);
            NetworkServer.Spawn(obj);
            return obj;
        }

    }
}

