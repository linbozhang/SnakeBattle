using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace SnakeGame
{
    public class SnakeImpl:EntityImpl,Snake
    {
        private  SnakeOwner owner;
        private string name;
        private long recombineTicks = 0;

        public void init(SnakeOwner owner, WorldImpl world, Position position)
        {
            base.init(EntityType.SNAKE,world,position);
            this.owner = owner;
            this.name = owner.getName();

        }

        public SnakeImpl (SnakeOwner owner ,WorldImpl world,Position position):base(EntityType.SNAKE, world, position)
        {
            this.owner = owner;
            this.name = owner.getName();
        }

        public override bool shouldUpdate()
        { return true; }

        public  string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public SnakeOwner getOwner()
        {
            return owner;
        }

        public float getSpeed()
        {
            return 30.0f * Mathf.Pow(mass, -1.0f / 4.5f) * 50.0f / 40.0f;
        }

        public long getRecombineTicks()
        {
            return recombineTicks;
        }

        public void setRecombineTicks(long recombineTicks)
        {
            this.recombineTicks = recombineTicks;
        }

        public override void tick()
        {
            if(recombineTicks>0)
            {
                recombineTicks--;
            }

            move();
            eat();
        }

        private void move()
        {
            if(!(owner is PlayerImpl))
            {
                return;
            }
            PlayerImpl player = (PlayerImpl)owner;

            int r = getPhysicalSize();

            Vector2 mousepos = Vector2.zero;
            float deltaX = mousepos.x - position.x;
            float deltaY = mousepos.y - position.y;
            float angle = Mathf.Atan2(deltaX,deltaY);

            if(float.IsNaN(angle))
            {
                return;
            }

            float distance = position.distance(mousepos.x,mousepos.y);
            float speed = Mathf.Min(getSpeed(),distance);

            float x1 = position.x + (speed * Mathf.Sin(angle));
            float y1 = position.y + (speed * Mathf.Cos(angle));
            if(x1<world.getBorder().left)
            {
                x1 = world.getBorder().left;
            }
            if(x1>world.getBorder().right)
            {
                x1 = world.getBorder().right;
            }
            if(y1<world.getBorder().top)
            {
                y1 = world.getBorder().top;
            }

            if(y1>world.getBorder().bottom)
            {
                y1 = world.getBorder().bottom;
            }

            setPosition(new Position(x1,y1));
        }

        private void eat()
        {
            List<EntityImpl> ediales = new List<EntityImpl>();
            int r = getPhysicalSize();

            float topY = position.y - r;
            float bottomY = position.y + r;
            float leftX = position.x - r;
            float rightX = position.x + r;

            foreach(Entity otherEntity in world.getEntities())
            {
                EntityImpl other = (EntityImpl)otherEntity;
                if(other==this)
                {
                    continue;
                }

                if(!other.collisionCheck(bottomY,topY,rightX,leftX))
                {
                    continue;
                }
                float multiplier = 1.25f;
                if(other is FoodImpl)
                {
                    ediales.Add(other);
                    continue;
                }else if(other  is SnakeImpl)
                {
                    SnakeImpl otherCell = (SnakeImpl)other;
                }

                if(other.getMass()*multiplier>mass)
                {
                    continue;
                }

                ediales.Add(other);
            }

            foreach (var entity in ediales)
            {
                this.addMass(entity.getMass());
                entity.Kill(getID());
            }
        }

        public new void onRemove()
        {
            getOwner().removeSnake(this);
        }

        private bool simpleCollide(SnakeImpl other ,float collisionDist )
        {
            return( Mathf.Abs(position.x - other.getPosition().x) < (2 * collisionDist) )&& Mathf.Abs(position.y - other.getPosition().y) < (2 * collisionDist);
        }


    }
}

