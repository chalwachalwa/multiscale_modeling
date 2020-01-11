using System.Drawing;
using System.Collections.Generic;
using Model.Neighbourhood;

namespace Model.Microelements{
    
    public class Grain : Microelement
    {
        public sealed override List<Cell> Members { get; set; }
        public sealed override int? Phase{get; set;}
        public sealed override Color Color {get; set;}
        public sealed override int Id{get; set;}

        public int Area { get => Members.Count; }
       


        public Grain(int id, int phase, Color color)
        {
            Id = id;
            Color = color;
            Phase = phase;
            Members = new List<Cell>();
        }

        public override void Delete()
        {
            foreach(var member in Members)
            {
                member.MicroelementMembership = null;
            }
        }

    }

}
