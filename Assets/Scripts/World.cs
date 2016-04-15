using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace SnakeGame
{
    public interface  World
    {
        //Server getServer();
        EntityImpl spawnEntity(EntityType type);
        EntityImpl spawnEntity(EntityType type, Position position);
        void removeEntity(EntityImpl entity);
        void removeEntity(uint id);
        EntityImpl getEntity(uint id);
        ICollection<EntityImpl> getEntities();
    }
}

