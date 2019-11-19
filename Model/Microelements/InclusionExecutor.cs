﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class InclusionExecutor
    {
        private IBoundaryCondition _boundary;
        private ITransitionRule _transition;
        private INeighbourhood _neighbourhood;

        public InclusionExecutor(IBoundaryCondition boundary)
        {
            _boundary = boundary;
            _neighbourhood = new VonNeumanNeighborhood(_boundary);
        }

        public void Grow(CelluralSpace space)
        {
            //In fact inclusions don't grow but to obtain round shape vonNeuman neighbourhood growing fits very weel,
            //This approach also resolves the problem with periodic boundary
            //But if inclusions appears next to each other and collide then they won't be perfect spherical. May apply radius checking for initializing??

            for (int step = 0; step < Inclusion.MaxRadius; step++)
            {
                for (int i = 0; i < space.GetXLength(); i++)
                {
                    for (int j = 0; j < space.GetYLength(); j++)
                    {
                        Cell[] neighbours = _neighbourhood.GetNeighbours(space, i, j);
                        _transition = new InclusionGrowthRule(step);
                        var element = _transition.NextState(space.GetCell(i, j), neighbours);
                        space.SetCellMembership(element, i, j);
                    }
                }
                step++;
            }


        }
    }
}
