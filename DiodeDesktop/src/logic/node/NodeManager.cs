using DiodeDesktop.src.logic.gate;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiodeDesktop.src.logic.node
{
    class NodeManager
    {

        //Handled by LogicManager, updated each tick
        public void Update(GameTime gameTime)
        {
            foreach(LogicGate logicGate in DiodeCore.logicManager.gateManager.gates)
            {
                foreach (LogicNode logicNode in logicGate.GetNodes())
                {
                    if (logicNode.nodeType == NodeProperties.nodeType.Output)
                    {
                        foreach (LogicNode logicNodeChild in logicNode.connectedNodes)
                        {
                            logicNodeChild.powered = logicNode.powered;
                        }
                    }
                }
            }
        }

        //This is used to add a node to it's parent with a multiplier of one
        public void AddNode(LogicGate parent, LogicNode node)
        {
            AddLogicNode(parent, node, 1);
        }

        //This is used to add a node to it's parent with a provided multiplier
        public void AddNode(LogicGate parent, LogicNode node, int multiplier)
        {
            AddLogicNode(parent, node, multiplier);
        }

        //This is used to add a node to it's parent from the given constructor
        private void AddLogicNode(LogicGate parent, LogicNode node, int multiplier)
        {
            node.parentGate = parent;
            parent.GetNodes().Add(node);
            if (node.nodeType == NodeProperties.nodeType.Input) { parent.CalculateGate(multiplier, 0); }
            if (node.nodeType == NodeProperties.nodeType.Output) { parent.CalculateGate(0, multiplier); }
        }

        //Calculate the bounds for the given node.
        public Rectangle CalculateBounds(LogicNode node, int index, int width, int height)
        {
            int x = 0; int y = 0;
            if (node.nodeType == NodeProperties.nodeType.Input)
            {
                x = node.parentGate.GetBounds().Left - (width/2);
                y = node.parentGate.GetBounds().Y + (index * 16) - (height / 2);
            }
            if (node.nodeType == NodeProperties.nodeType.Output)
            {
                x = node.parentGate.GetBounds().Right - (width/2);
                y = node.parentGate.GetBounds().Y + (index * 16) - (height / 2);
            }
            return new Rectangle(x, y, width, height);
        }
    }
}
