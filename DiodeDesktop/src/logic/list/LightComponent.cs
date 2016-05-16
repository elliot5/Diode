using DiodeDesktop.src.logic.gate;
using DiodeDesktop.src.logic.node;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiodeDesktop.src.logic.list
{
    class LightComponent : LogicGate
    {

        //Gate Varaibles 
        public int x, y;
        public List<LogicNode> logicNodes;
        public GateProperties.gateType gateType;
        public int input, output;
        public Color gateColor;

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
            if (logicNodes[0].powered)
            {
                gateColor = Color.Yellow;
            } else
            {
                gateColor = Color.DimGray;
            }
        }

        //Called on gate creation, X and Y always provided
        public override void Initialize(int x, int y)
        {
            this.x = x; this.y = y;
            logicNodes = new List<LogicNode>();
            DiodeCore.logicManager.nodeManager.AddNode(this, new LogicNode(NodeProperties.nodeCompatibility.Single, NodeProperties.nodeType.Input, 1, Color.Red));
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
            return gateColor;
        }
    }
}
