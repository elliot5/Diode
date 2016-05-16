using DiodeDesktop.src.logic.gate;
using DiodeDesktop.src.logic.gate.list;
using DiodeDesktop.src.logic.node;
using DiodeDesktop.src.logic.wire;
using Microsoft.Xna.Framework;

namespace DiodeDesktop.src.logic
{
    class LogicManager
    {
        //Public logic based variables
        public NodeManager nodeManager;
        public GateManager gateManager;
        public WireManager wireManager;

        //This is like a pause feature, if the variable is
        //true then logic will run, if it is false then all
        //logic will freeze in its current state until resumed.
        public bool logicRunning;

        //Initialize the Logic Managers
        public LogicManager()
        {
            nodeManager = new NodeManager();
            gateManager = new GateManager();
            wireManager = new WireManager();
            logicRunning = true;
        }

        //All logic, (GateManager and NodeManager) will be updated here.
        //If logicRunning is equal to true.
        public void Update(GameTime gameTime)
        {
            if (logicRunning) { 
                nodeManager.Update(gameTime);
                gateManager.Update(gameTime);
            }
        }

        //Called when mouse is left clicked
        //Connect/Select, Move, Modify
        public void OnClick()
        {
            foreach(LogicGate gate in gateManager.gates)
            {
                if (gate.GetBounds().Intersects(new Rectangle((int)DiodeCore.mouseManager.GetWorldPosition().X, (int)DiodeCore.mouseManager.GetWorldPosition().Y, 1, 1)))
                {
                    //WIP
                }
                foreach (LogicNode node in gate.GetNodes())
                {
                    if (node.GetBounds().Intersects(new Rectangle((int)DiodeCore.mouseManager.GetWorldPosition().X, (int)DiodeCore.mouseManager.GetWorldPosition().Y, 1, 1)))
                    {
                        node.OnClick();
                    }
                }
            }
        }

        //Called when mouse is right clicked
        //Disconnect/Unselect, Press, Interact
        public void OnInteract()
        {
            if(wireManager.CurrentlyDrawing()) { wireManager.DisableDrawing(); }
        }
    }
}
