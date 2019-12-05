﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Xunit;
using Model;
using System.Drawing;
using Model.Transition;

namespace Test.Model.Transition
{
    public class RuleOneTest
    {
        private static Cell a = new Cell(new Grain(0,0, Color.Blue));
        private static Cell b = new Cell(new Grain(1,0, Color.Blue));
        private static Cell c = new Cell(new Grain(2,0, Color.Blue));
        private static Cell d = new Cell(new Grain(3,0, Color.Blue));
        private static Cell e = new Cell(new Grain(4,0, Color.Blue));
        private static Cell f = new Cell(new Grain(5,0, Color.Blue));
        private static Cell g = new Cell(new Grain(6,0, Color.Blue));
        private static Cell h = new Cell(new Grain(7,0, Color.Blue));





        [Theory]
        [ClassData(typeof(RuleOneTestData))]
        public void EmptyCellTest(Cell expected, Cell[] neighbours)
        {
            ITransitionRule rule = new RuleOne();
            var cell = new Cell();
            Microelement result = rule.NextState(cell, neighbours);
            Assert.Same(expected?.MicroelementMembership, result);
        }

        [Fact]
        public void FilledCellTest()
        {
            var neighbours = new Cell[]{ b, c, a, a, a, a, a, a };
            ITransitionRule rule = new RuleOne();
            var cell = c;
            Assert.Same(c.MicroelementMembership, rule.NextState(cell, neighbours));
        }


        private class RuleOneTestData : IEnumerable<object[]>
        {   ///x\y 0 1 2
            /// 0 |a|b|c|
            /// 1 |d|e|f|
            /// 2 |g|h|i|
            public IEnumerator<object[]> GetEnumerator()
            {                                                  
                yield return new object[] { a, new Cell[] { a, a, a, a, a, null, null, null  } }; 
                yield return new object[] { a, new Cell[] { null, a, a, a, a, a, null, null  } }; 
                yield return new object[] { a, new Cell[] { null, null, a, a, a, a, a, null  } }; 
                yield return new object[] { a, new Cell[] { null, null, null, a, a, a, a, a  } }; 
                yield return new object[] { a, new Cell[] { a, null, null, null, a, a, a, a  } };
                yield return new object[] { a, new Cell[] { a, a, null, null, null, a, a, a  } }; 
                yield return new object[] { a, new Cell[] { a, a, a, null, null, null, a, a  } }; 
                yield return new object[] { a, new Cell[] { a, a, a, a, null, null, null, a  } }; 

                yield return new object[] { a, new Cell[] { a, a, a, a, a, a, null, null  } }; 
                yield return new object[] { a, new Cell[] { null, a, a, a, a, a, a, null  } }; 
                yield return new object[] { a, new Cell[] { null, null, a, a, a, a, a, a  } };
                yield return new object[] { a, new Cell[] { a,null, null,  a, a, a, a, a  } };
                yield return new object[] { a, new Cell[] { a, a,null, null, a, a, a, a } };   
                yield return new object[] { a, new Cell[] { a, a, a, null, null , a, a, a  } }; 
                yield return new object[] { a, new Cell[] { a, a, a, a, null , null, a, a  } }; 
                yield return new object[] { a, new Cell[] { a, a, a, a, a , null, null, a  } }; 

                yield return new object[] { a, new Cell[] { a, a, a, a, a, a, a, null  } }; 
                yield return new object[] { a, new Cell[] { null, a, a, a, a, a, a, a  } }; 
                yield return new object[] { a, new Cell[] { a, null, a, a, a, a, a, a  } }; 
                yield return new object[] { a, new Cell[] { a, a, a, null, a, a, a, a  } }; 
                yield return new object[] { a, new Cell[] { a, a, a, a, null, a, a, a  } }; 
                yield return new object[] { a, new Cell[] { a, a, a, a, a, null, a, a  } }; 
                yield return new object[] { a, new Cell[] { a, a, a, a, a, a, null, a  } }; 

                
                yield return new object[] { a, new Cell[] { a, a, a, a, a, a, a, a  } };
                yield return new object[] { a, new Cell[] { b, c, a, a, a, a, a, b  } };
                yield return new object[] { null, new Cell[] { a, b, c, d, e, f, g, a  } }; 
                yield return new object[] { null, new Cell[] { a, a, a, a, e, f, g, e  } }; 
                yield return new object[] { null, new Cell[] { null, a, a, a, e, a,e, a  } }; 
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }


    }
}
