using UnityEngine;
using System.Collections;

namespace SnakeGame
{
    public interface Entity
    {

         WorldImpl getWorld();

         uint getID();

         EntityType getType();

         Position getPosition();

         void setPosition(Position position);

         Color getColor();

         void setColor(Color color);

         int getPhysicalSize();

         int getMass();

         void setMass(int mass);

         void addMass(int mass);

    }
}

