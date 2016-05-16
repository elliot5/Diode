using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiodeDesktop.src.logic.gate
{
    class GateManager
    {
        //All gates will be stored here
        public List<LogicGate> gates;

        //Initialize the GateManager
        public GateManager()
        {
            gates = new List<LogicGate>();
        }

        //Handled by LogicManager, updated each tick
        public void Update(GameTime gameTime)
        {
            //This will go through each gate and update the logic
            for(int updateIndex = 0; updateIndex < gates.Count; updateIndex++)
            {
                gates[updateIndex].UpdateLogic(gameTime);
            }
        }

        //This will add and initialize the given gate at the given location.
        public void AddGate(LogicGate gate, int x, int y)
        {
            gate.Initialize(x, y);
            gates.Add(gate);
        }

        //This will add and initialize the given gate at the mouse position.
        public void AddGate(LogicGate gate)
        {
            gate.Initialize((int)DiodeCore.mouseManager.GetWorldPosition().X,
                (int)DiodeCore.mouseManager.GetWorldPosition().Y);
            gates.Add(gate);
        }

        //Calculates the gates bounds and returns it.
        public Rectangle CalculateBounds(LogicGate gate, int x, int y)
        {
            int width = 32; int height = 0; 
            if(gate.GetInputCount() > gate.GetOutputCount())
            {
                height = 16 * gate.GetInputCount() + 16;
            } else
            {
                height = 16 * gate.GetOutputCount() + 16;
            }
            return new Rectangle(x, y, width, height);
        }

    }
}
