using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiodeDesktop.src.logic.node;
using Microsoft.Xna.Framework;

namespace DiodeDesktop.src.logic.gate.list
{
    class AndGate : LogicGate
    {

        //Gate Varaibles 
        public int x, y;
        public List<LogicNode> logicNodes;
        public GateProperties.gateType gateType;
        public int input, output;

        //Returns the gates bounds
        public override Rectangle GetBounds()
        {
            return DiodeCore.logicManager.gateManager.CalculateBounds(this, x, y);
        }

        //Returns all the gates nodes
        public override List<LogicNode> GetNodes()
        {
            return logicNodes;
        }

        //This is called every tick to update the gates logic
        public override void UpdateLogic(GameTime gameTime)
        {
            if(logicNodes[0].powered && logicNodes[1].powered) { logicNodes[2].powered = true; }
            else { logicNodes[2].powered = false; }
        }

        //Called on gate creation, X and Y always provided
        public override void Initialize(int x, int y)
        {
            this.x = x; this.y = y;
            logicNodes = new List<LogicNode>();
            DiodeCore.logicManager.nodeManager.AddNode(this, new LogicNode(NodeProperties.nodeCompatibility.Single, NodeProperties.nodeType.Input, 1, Color.Red));
            DiodeCore.logicManager.nodeManager.AddNode(this, new LogicNode(NodeProperties.nodeCompatibility.Single, NodeProperties.nodeType.Input, 2, Color.Red));
            DiodeCore.logicManager.nodeManager.AddNode(this, new LogicNode(NodeProperties.nodeCompatibility.Single, NodeProperties.nodeType.Output, 2, Color.Blue));
        }

        //Gives the ammount of inputs and outputs connected to the Logic System
        public override void CalculateGate(int input, int output)
        {
            this.input += input; this.output += output;
        }

        //Get the ammount of stored Inputs
        public override int GetInputCount()
        {
            return input;
        }

        //Get the ammount of stored Outputs
        public override int GetOutputCount()
        {
            return output;
        }

        //Return the Nodes color
        public override Color GetColor()
        {
            return Color.LightBlue;
        }
    }
}
