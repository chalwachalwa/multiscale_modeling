using System;
using System.Linq;


namespace Model{
    
    public class RuleFour : ITransitionRule
    {
        public int Threshhold
        {
            get {return _threshold;}
            set
            {
                if(value > 100) _threshold = 100;
                if(value < 0) _threshold = 0;
                _threshold = value;
            }
        }
        private Random _random;
        private int _threshold;

        public RuleFour()
        {
            _random = new Random();
            Threshhold = 90;
        }

        public Microelement NextState(Cell cell, Cell[] neighbours){ 

            if (cell?.MicroelementMembership == null)
            {
                var groups = (from c in neighbours
                             where c?.MicroelementMembership?.Id != null && c.MicroelementMembership is Grain
                             group c by c.MicroelementMembership).ToArray();

                if (groups.Count() == 0)
                {
                    return null;
                }
                else if (groups.Count() > 1)
                {
                    //Check if groups has this same count
                    var top = (from g in groups
                              let maxPower = groups.Max(r => r.Count())
                              where g.Count() == maxPower
                              select g.Key).ToArray();

                    int topCount = top.Count();
                    if (topCount > 1)
                    {
                        //Take a random one
                        var r = new Random();
                        int randomIndex = r.Next(0, topCount - 1);
                        if(_random.Next(0,100) < Threshhold) return null;
                        return top.ElementAt(randomIndex);
                    }
                    else
                    {
                        //Return the strongest neighbour
                        if(_random.Next(0,100) < Threshhold) return null;
                        return top.First();
                    }
                }
                else
                {
                    //return the only neighbour
                    if(_random.Next(0,100) < Threshhold) return null;
                    return groups.First().Key;
                }
            }
            else
            {
                //return self
                return cell.MicroelementMembership;
            }
        }
    }
        
}