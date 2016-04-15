using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
namespace SnakeGame
{
    public abstract class EntityImpl : NetworkBehaviour, Tickable,Entity {

        protected  uint id;
        protected  EntityType type;
        protected WorldImpl world;
        protected Color color = Color.green;
        protected Position position;
        protected uint consumer = 0;
        protected int mass = 10;
        protected bool spiked = false;


        public   void init(EntityType type, WorldImpl world, Position position)
        {
            this.id = GetComponent<NetworkIdentity>().netId.Value;
            this.type = type;
            this.world = world;
            this.position = position;
        }

        public EntityImpl (EntityType type,WorldImpl world, Position position)
        {
            this.id = 1;
            this.type = type;
            this.world = world;
            this.position = position;
        }

        public uint getID()
        {
            return id;
        }

        public EntityType getType()
        {
            return type;
        }

        public Position getPosition()
        {
            return position;
        }

        public void setPosition(Position position)
        {
            this.position = position;
        }
        
        public uint getConsumer()
        {
            return consumer;
        }

        public void Kill(uint consumer)
        {
            this.consumer = consumer;
            world.removeEntity(this);
        }

        public Color getColor()
        {
            return color;
        }

        public void setColor(Color color)
        {
            this.color = color;
        }

        public int getPhysicalSize()
        {
            return (int)Mathf.CeilToInt(Mathf.Sqrt(100 * mass));
        }

        public int getMass()
        {
            return mass;
        }

        public void setMass(int mass)
        {
            this.mass = mass;
        }

        public void addMass(int mass)
        {
            this.mass += mass;
        }

        public  WorldImpl getWorld()
        {
            return world;
        }

        public bool collisionCheck(float bottomY,float topY,float rightX,float leftX)
        {
            if(position.y>bottomY||position.y<topY||position.x>rightX||position.x<leftX)
            {
                return false;
            }
            return true;
        }

        public abstract bool shouldUpdate();

        public  abstract void tick();
        public void onRemove()
        {

        }

        public bool equals(object obj)
        {
            if(obj==null)
            {
                return false;
            }
            if(!( obj is EntityImpl ))
            {
                return false;
            }

            EntityImpl other = (EntityImpl)obj;
            if(this.id!=other.id)
            {
                return false;
            }

            if(this.type!=other.type)
            {
                return false;
            }

            return true;
        }


    }
}

