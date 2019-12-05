﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Model.Transition;

namespace Model
{
    public class CurvatureExecutor : ISimulationExecutor
    {
        public string Name
        {
            get { return ToString(); }
            set { }
        }
    

        public int Step { get; private set; }

        public CurvatureExecutor()
        {
        }

        public CurvatureExecutor(int step)
        {
            if (step < 0) throw new ArgumentException();
            Step = step;
        }

        public int ReturnStep()
        {
            return Step;
        }

        public void NextState(CelluralSpace space, CelluralSpace lastSpace, ITransitionRule transition, INeighbourhood neighbourhood)
        {
            for (int i = 0; i < space.GetXLength(); i++)
            {
                for (int j = 0; j < space.GetYLength(); j++)
                {
                    // TODO: refactor
                    IBoundaryCondition boun = new AbsorbingBoundary();
                    INeighbourhood nei = new MooreNeighbourhood(new AbsorbingBoundary());
                    ITransitionRule rule = new RuleOne();
                    Cell[] neighbours = nei.GetNeighbours(lastSpace, i, j);
                    var element = rule.NextState(space.GetCell(i, j), neighbours);

                    if (element != null)
                    {
                        space.SetCellMembership(element, i, j);
                        continue;
                    }

                    nei = new VonNeumanNeighbourhood(new AbsorbingBoundary()); 
                    rule = new RuleTwo();
                    neighbours = nei.GetNeighbours(lastSpace, i, j);
                    element = rule.NextState(space.GetCell(i, j), neighbours);

                    if (element != null)
                    {
                        space.SetCellMembership(element, i, j);
                        continue;
                    }

                    nei = new FurtherMooreNeighbourhood(new AbsorbingBoundary());
                    rule = new RuleTwo();
                    neighbours = nei.GetNeighbours(lastSpace, i, j);
                    element = rule.NextState(space.GetCell(i, j), neighbours);

                    if (element != null)
                    {
                        space.SetCellMembership(element, i, j);
                        continue;
                    }

                    nei = new FurtherMooreNeighbourhood(new AbsorbingBoundary());
                    rule = new RuleFour();
                    neighbours = nei.GetNeighbours(lastSpace, i, j);
                    element = rule.NextState(space.GetCell(i, j), neighbours);
                    space.SetCellMembership(element, i, j);

                }
            }
            Step++;
        }

        public void Reset()
        {
            Step = 0;
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "CurvatureExecutor";
        }
    }
}
