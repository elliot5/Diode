using DiodeDesktop.src.logic.gate;
using DiodeDesktop.src.logic.node;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiodeDesktop.src.render
{
    class RenderManager
    {

        //Render based public variables
        public BlueprintCamera blueprintCamera;
        public SpriteBatch spriteBatch;
        public GraphicsDevice graphicsDevice;

        //Initialize the RenderManager here.
        public RenderManager(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            blueprintCamera = new BlueprintCamera(graphicsDevice.Viewport);
            spriteBatch = new SpriteBatch(graphicsDevice);
        }

        //Called on Draw updates, all rendering will take place here.
        public void Render(GameTime gameTime)
        {
            Clear(Color.DarkGray);
            spriteBatch.Begin(transformMatrix: blueprintCamera.GetViewMatrix());
            //Begin Render Process (Unprojected)

            //Render Gates
            for (int gateIndex = 0; gateIndex < DiodeCore.logicManager.gateManager.gates.Count; gateIndex++) {
                LogicGate logicGate = DiodeCore.logicManager.gateManager.gates[gateIndex];
                spriteBatch.Draw(TextureManager.whiteBox, logicGate.GetBounds(), logicGate.GetColor());
                //Render Nodes
                for (int nodeIndex = 0; nodeIndex < logicGate.GetNodes().Count; nodeIndex++)
                {
                    LogicNode logicNode = logicGate.GetNodes()[nodeIndex];
                    spriteBatch.Draw(TextureManager.whiteBox, logicNode.GetBounds(), logicNode.color);         
                }
            }
            //Render Wires
            for (int gateIndex = 0; gateIndex < DiodeCore.logicManager.gateManager.gates.Count; gateIndex++)
            {
                LogicGate logicGate = DiodeCore.logicManager.gateManager.gates[gateIndex];
                for (int nodeIndex = 0; nodeIndex < logicGate.GetNodes().Count; nodeIndex++) {
                    LogicNode logicNode = logicGate.GetNodes()[nodeIndex];
                    DiodeCore.logicManager.wireManager.Render(logicNode, spriteBatch);
               }
            }

            //End Render Process
            spriteBatch.End();
        }

        //Clear screen with the input color when called
        private void Clear(Color color)
        {
            graphicsDevice.Clear(color);
        }

    }
}
