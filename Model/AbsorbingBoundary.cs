using System;

namespace Model{
    
    
    public static class AbsorbingBoundary
    {
        // AbsorbingBoundary always return null Cell 
        /// |nl|nl|nl|nl|nl|
        /// |nl|00|01|02|nl|
        /// |nl|10|11|12|nl|
        /// |nl|20|21|22|nl|
        /// |nl|nl|nl|nl|nl|
        public static Tuple<int,int> BoundaryCondition(Cell[,] space, int x, int y, BoundaryDirection direction) {
            
            
            return null;
        }
    }

    
}
