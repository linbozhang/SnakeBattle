using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace SnakeGame
{
    public interface SnakeOwner
    {
        string getName();

        void setName(string name);

        IList<Snake> getSnakes();

        void addSnake(Snake snake);

        void removeSnake(Snake snake);

        void removeSnake(int id);
    }
}

