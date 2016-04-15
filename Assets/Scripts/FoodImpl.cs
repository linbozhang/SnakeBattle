using UnityEngine;
using System.Collections;

namespace SnakeGame
{
    public class FoodImpl :EntityImpl, Food
    {

        public void init(WorldImpl world, Position positoin)
        {
            base.init(EntityType.FOOD, world, positoin);
        }

        public FoodImpl (WorldImpl world ,Position positoin):base( EntityType.FOOD,world,positoin)
        {
            
            
        }    

        public override bool shouldUpdate()
        {
            return true;
        }

        public override void tick()
        {

        }
        
    }
}

