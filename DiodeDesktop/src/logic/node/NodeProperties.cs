using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiodeDesktop.src.logic.node
{
    class NodeProperties
    {
        //These are the two types of wires, single wires only work with
        //each other, and busses only work with each other.
        public enum nodeCompatibility {Single, Bus};

        //Input nodes only take output nodes, and output nodes only take,
        //input nodes. One must be chosen for the node to function.
        public enum nodeType { Input, Output };
    }
}
