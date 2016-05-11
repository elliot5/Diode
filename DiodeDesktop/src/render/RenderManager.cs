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
        GraphicsDevice graphicsDevice;
        SpriteBatch spriteBatch;

        public void Initialize(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            this.graphicsDevice = graphicsDevice;
            this.spriteBatch = spriteBatch;
            blueprintCamera = new BlueprintCamera(graphicsDevice.Viewport);
        }

        public void Render()
        {

        }

    }
}
