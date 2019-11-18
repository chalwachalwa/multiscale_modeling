using System;
using System.Collections.Generic;
using System.Drawing;


namespace Model{
   public class CelluralAutomaton{

       public List<Grain> Grains{get; private set;}
       public List<Inclusion> Inclusions{get; private set;}

       public CelluralSpace Space {get; private set;} 
       public int Step
       {
           get{ return this._executor.Step;}
           private set{} 
        }

       private CelluralSpace _lastStepSpace;
       private ITransitionRule _transition;
       private INeighbourhood _neighbourhood;
       private IBoundaryCondition _boundary;
       private SimulationExecutor _executor;
       private SpaceRenderingEngine _renderingEngine;
       private GrainGenerator _grainGenerator;
       private InclusionGenerator _inclusionGenerator;

       public CelluralAutomaton(int size, ITransitionRule transition, INeighbourhood neighbourhood, IBoundaryCondition boundary)
       {
           if(transition == null || neighbourhood == null || boundary == null) throw new ArgumentNullException();
           this._transition = transition;
           this._neighbourhood = neighbourhood;
           this._boundary = boundary;
           this.Space = new CelluralSpace(size);
           this._lastStepSpace = new CelluralSpace(size);
           this._executor = new SimulationExecutor();
           this._grainGenerator = new GrainGenerator();
           this._inclusionGenerator = new InclusionGenerator();
       }

        public void NextStep()
        {
            
            _lastStepSpace = Space.Clone();
            Space.NextState(_transition, _neighbourhood, _boundary);
            

        }

        public void PopulateSimulation()
        {
        
        }

   }
   
   
   
   
   
   
   
   
   
   /* public class CelluralAutomaton
    {
        public CelluralSpace Space { get; private set; }
        public List<Grain> Grains { get; private set; }
        
        
        public CelluralAutomaton()
        {
            this.Space = new CelluralSpace(500); //TODO: replace magic number with resizable control
        }

        public CelluralAutomaton(int spaceSize)
        {
            this.Space = new CelluralSpace(spaceSize);
        }

        
        

    }*/

    
}

