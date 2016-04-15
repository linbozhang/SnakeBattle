using UnityEngine;
using System.Collections;

namespace SnakeGame
{
    public class Position 
    {
        public float x;
        public float y;

        public Position(Position position)
        {
            this.x = position.x;
            this.y = position.y;
        }

        public Position (float x,float y)
        {
            this.x = x;
            this.y = y;
        }

        public float getX()
        {
            return x;
        }

        public float getY()
        {
            return y;
        }

        public void setX(float x)
        {
            this.x = x;
        }

        public void setY(float y)
        {
            this.y = y;
        }

        public Position multiply(float mx, float my)
        {
            return new Position(x * mx, y * my);
        }

        public Position divide(float dx, float dy)
        {
            return new Position(x / dx, y / dy);
        }

        public Position add(float ax, float ay)
        {
            return new Position(x + ax, y + ay);
        }

        public Position subtract(float sx, float sy)
        {
            return new Position(x - sx, y - sy);
        }

        public float distanceSquared(Position position)
        {
            return Mathf.Pow(position.y - this.y, 2) + Mathf.Pow(position.y -this.y, 2);
        }

        public float distance(Position position)
        {
            return Mathf.Sqrt(distanceSquared(position));
        }

        public float distanceSquared(float ox, float oy)
        {
            return Mathf.Pow(ox - getX(), 2) + Mathf.Pow(oy - getY(), 2);
        }

        public float distance(float ox, float oy)
        {
            return Mathf.Sqrt(distanceSquared(ox, oy));
        }

      
        //public int hashCode()
        //{
        //    int hash = 7;
        //    hash = 89 * hash + (int)(float.floatToLongBits(this.x) ^ (float.floatToLongBits(this.x) >>> 32));
        //    hash = 89 * hash + (int)(float.floatToLongBits(this.y) ^ (float.floatToLongBits(this.y) >>> 32));
        //    return hash;
        //}

       
        public bool equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (GetType()!= obj.GetType())
            {
                return false;
            }
             Position other = obj as Position;
            if(this.x!=other.x)
            {
                return false;
            }
            if(this.y!=other.y)
            {
                return false; 
            }
            return true;
        }

       
        public string toString()
        {
            return "Position{" + "x=" + x + ", y=" + y + '}';
        }
    }
}

