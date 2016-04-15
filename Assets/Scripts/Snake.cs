using UnityEngine;
using System.Collections;

namespace SnakeGame
{
    public interface Snake
    {

        string getName();
        void setName(string name);
        SnakeOwner getOwner();
        //int getId();
        int getMass();
        //Position getPosition();
        int getPhysicalSize();
        //void SetPosition(Position add);
    }
}

