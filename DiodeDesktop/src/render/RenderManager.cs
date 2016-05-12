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
    
        BlueprintCamera blueprintCamera;
        SpriteBatch spriteBatch;
        GraphicsDevice graphicsDevice;

        public RenderManager(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            blueprintCamera = new BlueprintCamera(graphicsDevice.Viewport);
            spriteBatch = new SpriteBatch(graphicsDevice);
        }

        public void Render(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.End();
        }

    }
}
