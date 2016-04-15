using UnityEngine;
using System.Collections;
using System;

namespace SnakeGame
{
    public class MassImpl : EntityImpl
    {

        public void init(WorldImpl world, Position position)
        {
            base.init(EntityType.MASS, world,position);
        }
        public MassImpl(WorldImpl world, Position position) : base(EntityType.MASS, world, position)
        {

        }
        public override bool shouldUpdate()
        {
            throw new NotImplementedException();
        }


        public override void tick()
        {
            throw new NotImplementedException();
        }

    }
}