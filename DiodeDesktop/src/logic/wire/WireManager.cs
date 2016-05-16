using DiodeDesktop.src.logic.gate;
using DiodeDesktop.src.logic.node;
using DiodeDesktop.src.render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiodeDesktop.src.logic.wire
{
    class WireManager
    {
        //Stye Variables
        public Color unpoweredWire = Color.SlateGray;
        public Color poweredWire = Color.Purple;
        public Color drawingWire = Color.Green;

        //Drawing Variables
        private LogicNode startingDrawNode;

        //Enable drawing from the provided starting gate
        public void EnableDrawing(LogicNode startingDrawNode)
        {
            this.startingDrawNode = startingDrawNode;
        }

        //Disable drawing by resetting the starting drawing gate
        public void DisableDrawing()
        {
            startingDrawNode = null;
        }

        //Returns if the wire is currently in draw mode
        public bool CurrentlyDrawing()
        {
            bool result = false;
            if (startingDrawNode != null) { result = true; }
            return result;
        }

        //Returns the starting draw node
        public LogicNode GetStartingNode()
        {
            return startingDrawNode;
        }

        //Renders all ingame wires
        public void Render(LogicNode node, SpriteBatch spriteBatch)
        {
            //Already Created Wires
            if(node.nodeType == NodeProperties.nodeType.Output)
            {
                foreach (LogicNode connectedNode in node.connectedNodes) {
                    Color nodeColor = unpoweredWire;
                    if(node.powered) { nodeColor = poweredWire;  }
                    DrawWire(spriteBatch, new Vector2(node.GetBounds().X, node.GetBounds().Y), new Vector2(connectedNode.GetBounds().X, connectedNode.GetBounds().Y), 2, nodeColor, 5, false);
                }
            }
            //Drawing wires
            if(startingDrawNode != null)
            {
                DrawWire(spriteBatch, new Vector2(startingDrawNode.GetBounds().X, startingDrawNode.GetBounds().Y), new Vector2(DiodeCore.mouseManager.GetWorldPosition().X, DiodeCore.mouseManager.GetWorldPosition().Y), 2, drawingWire, 5, true);
            }
        }

        //Draw a wire with the given params
        private void DrawWire(SpriteBatch sb, Vector2 start, Vector2 end, int wireWidth, Color wireColor, int offset, bool drawing)
        {
            if (drawing) { 
                end.X -= offset;
                end.Y -= offset;
            }
            Vector2 edge = end - start;
            float angle =
                (float)Math.Atan2(edge.Y, edge.X);
            sb.Draw(TextureManager.whiteBox,
                new Rectangle(
                    (int)start.X+offset,
                    (int)start.Y+offset,
                    (int)edge.Length(), 
                    wireWidth), 
                null,
                wireColor, 
                angle,   
                new Vector2(0, 0),
                SpriteEffects.None,
                0);

        }
    }
}
