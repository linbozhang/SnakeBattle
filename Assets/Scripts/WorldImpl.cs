using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using System.Collections.Generic;
namespace SnakeGame
{
    public class WorldImpl : World
    {
        //   private readonly Random random = new Random(System.DateTime.Now.Millisecond);
        private readonly Dictionary<uint, EntityImpl> entities = new Dictionary<uint, EntityImpl>();// new List<EntityImpl>();
        public readonly int[] entityCounts = new int[3];
        private int totalEnties = 0;
        private readonly BorderC border;
        private readonly ViewC view;
        private readonly GameConfig configuration;
        private readonly ClitherServer server;

        public WorldImpl( ClitherServer server )
        {
            this.server = server;
            this.configuration = server.getConfig();
            this.border = configuration.world.border;
            this.view = configuration.world.view;

            for(int i=0;i<configuration.world.food.startAmout;i++)
            {
                spawnEntity(EntityType.FOOD);
            }
        }

        public EntityImpl spawnEntity(EntityType type)
        {
            return spawnEntity(type,getRandomPosition());
        }

        public EntityImpl spawnEntity(EntityType type, Position position)
        {
            return spawnEntity(type, position, null);
        }
        
        public SnakeImpl spawnPlayerSnake(PlayerImpl player)
        {
            return spawnPlayerSnake(player,getRandomPosition());
        }

        public SnakeImpl spawnPlayerSnake(PlayerImpl player ,Position position)
        {
            return (SnakeImpl)spawnEntity(EntityType.SNAKE,position);
        }
        private EntityImpl spawnEntity(EntityType type ,Position position,SnakeOwner owner)
        {
            if( position ==null)
            {
                return null;
            }

            EntityImpl entity;
            switch(type)
            {
                case EntityType.SNAKE:

                    if(owner==null)
                    {
                        throw new System.Exception("cell entities must have an owner");
                    }


                    GameObject snakeObj= server.spawn( Resources.Load("Prefabs/SnakeImpl")as GameObject,position);
                    SnakeImpl snakeImpl = snakeObj.GetComponent<SnakeImpl>();
                    snakeImpl.init(owner,this,position);
                    entity = snakeImpl;
                    //entity =      //new SnakeImpl(owner, this, position);
                    break;
                case EntityType.FOOD:
                    GameObject foodObj = server.spawn(Resources.Load("Prefabs/FoodImpl") as GameObject, position);
                    FoodImpl foodImpl = foodObj.GetComponent<FoodImpl>();
                    foodImpl.init( this, position);

                    entity = foodImpl;// new FoodImpl(this, position);
                    break;

                case EntityType.MASS:
                    GameObject massObj = server.spawn(Resources.Load("Prefabs/MassImpl") as GameObject, position);
                    MassImpl massImpl = massObj.GetComponent<MassImpl>();
                    massImpl.init(this, position);
                    entity = massImpl; //new MassImpl(this, position);
                    break;

                default:
                    throw new System.Exception("Unsupported entity type:"+type);
                   
            }
            entities.Add(entity.getID(),entity);
            entityCounts[(int)type]++;
            totalEnties++;
            return entity;
        }

        public void removeEntity(EntityImpl entity)
        {
            removeEntity(entity.getID());
        }
        public void removeEntity(uint id)
        {
            if(!entities.ContainsKey(id))
            {
                throw new System.Exception("entity with the specified ID does not exist in the world");
            }

            EntityImpl entity = entities[id];
            entities.Remove(id);
            entityCounts[(int)entity.getType()]--;
            totalEnties--;
            entity.onRemove();


            // remove from player list;
        }

        public EntityImpl getEntity(uint id)
        {
            EntityImpl entity;
            if(entities.TryGetValue(id,out entity))
            {
                return entity;
            }
            return null;
        }

        public List<EntityImpl> getRawEntities()
        {
            List<EntityImpl> rtn=new List<EntityImpl>();
            EntityImpl[] list = new EntityImpl[entities.Values.Count];
             entities.Values.CopyTo(list, 0);
            rtn.AddRange(list);
            return rtn;
        }

        public ICollection<EntityImpl> getEntities()
        {
            EntityImpl[] list = new EntityImpl[entities.Values.Count];
            entities.Values.CopyTo(list, 0);
            return list;
        }

        public int getSnakeCount()
        {
            return entityCounts[(int)EntityType.SNAKE];
        }
        public int getFoodCount()
        {
            return entityCounts[(int)EntityType.FOOD];
        }

        public int getMassCount()
        {
            return entityCounts[(int)EntityType.MASS];
        }

        public BorderC getBorder()
        {
            return border;
        }
        public ViewC getView()
        {
            return view;
        }

        public Position getRandomPosition()
        {
            return new Position(
                (Random.value*(Mathf.Abs(border.left)+Mathf.Abs(border.right))),
                (Random.value*(Mathf.Abs(border.bottom)+Mathf.Abs(border.top)))
                );
        }
        private void spawnFood()
        {
            int spawnedFood = 0;
            while(getFoodCount()<configuration.world.food.maxAmount&& spawnedFood<configuration.world.food.spawnPerInterval)
            {
                spawnEntity(EntityType.FOOD);
                spawnedFood++;
            }
        }

        public void tick()
        {
            //spawnFood

            foreach(EntityImpl entity in entities.Values )
            {
                //serverTick.accept(entity);
            }

        }

    }
}

