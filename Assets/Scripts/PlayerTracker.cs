using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
namespace SnakeGame
{
    public class PlayerTracker
    {
        private readonly PlayerImpl player;
        private readonly WorldImpl world;
        private readonly List<uint> visibleEntites = new List<uint>();

        private Queue<EntityImpl> removalQueue = new Queue<EntityImpl>();
        private float rangeX;
        private float rangeY;
        private float centerX;
        private float centerY;
        private float viewLeft;
        private float viewRight;
        private float viewTop;
        private float viewBottom;
        private long lastViewUpdateTick = 0L;

        public PlayerTracker (PlayerImpl player)
        {
            this.player = player;
            //this.world=
        }

        public void remove(EntityImpl entity)
        {
            if(!removalQueue.Contains(entity))
            {
                removalQueue.Enqueue(entity);
            }
        }

        private void updateRange()
        {
            float totalSize = 0;
            foreach(var snake in player.getSnakes())
            {
                totalSize += snake.getPhysicalSize();
            }

            float factor = Mathf.Pow(Mathf.Min(64.0f/totalSize,1),0.4f);

            rangeX = world.getView().baseX / factor;
            rangeY = world.getView().baseY / factor;
        }

        private void updateCenter()
        {
            if(player.getSnakes()==null|| player.getSnakes().Count==0)
            {
                return;
            }

            int size = player.getSnakes().Count;
            float x = 0;
            float y = 0;
            foreach( var snack in player.getSnakes())
            {
                x += snack.getPosition().x;
                y += snack.getPosition().y;
            }
            this.centerX = x / size;
            this.centerY = y / size;
       
        }

        public void updateView()
        {
            updateRange();
            updateCenter();
            viewTop = centerY - rangeY;
            viewBottom = centerY + rangeY;
            viewLeft = centerX - rangeX;
            viewRight = centerX + rangeX;

           //
        }

        private List<uint> calculateEntitesInView()
        {
            List<uint> entityList = new List<uint>();
            foreach( var entity in world.getEntities() )
            {
                Position pos = entity.getPosition();
                if(pos.y<=viewBottom&&pos.y>=viewTop&&pos.x>=viewLeft&&pos.x<=viewRight)
                {
                    entityList.Add(entity.getID());
                }
            }
            return entityList;
        }

        public List<uint> getVisibleEntities()
        {
            return visibleEntites;
        }

        public void updateNodes()
        {
            List<uint> updates = new List<uint>();
            //List<Entity> removals = new List<Entity>();
            EntityImpl [] removals= removalQueue.ToArray();
            removalQueue.Clear();
            List<uint> needRemove = new List<uint>();
            if (true) //每五帧更新一次
            {
                updateView();
                List<uint> newVisible = calculateEntitesInView();

               

                foreach(var eId in visibleEntites)
                {
                    if(!newVisible.Contains(eId))
                    {
                        needRemove.Add(eId);
                        
                    }
                }

                foreach( var i in needRemove)
                {
                    visibleEntites.Remove(i);
                }

               
                foreach(var eid in newVisible)
                {
                    if(!visibleEntites.Contains(eid))
                    {
                        visibleEntites.Add(eid);
                        updates.Add(eid);
                    }
                }
                needRemove.Clear();



            }

            //List<int> needRemove = new List<int>();

            foreach(var i in visibleEntites)
            {
                EntityImpl entity = world.getEntity(i);
                if(entity==null)
                {
                    needRemove.Add(i);
                    continue;
                }

                if(entity.shouldUpdate())
                {
                    updates.Add(i);
                }
            }
        }



    }
}

