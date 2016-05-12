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
    
        public BlueprintCamera blueprintCamera;
        public SpriteBatch spriteBatch;
        public GraphicsDevice graphicsDevice;

        public RenderManager(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            blueprintCamera = new BlueprintCamera(graphicsDevice.Viewport);
            spriteBatch = new SpriteBatch(graphicsDevice);
        }

        public void Render(GameTime gameTime)
        {
            Clear(Color.DarkGray);
            spriteBatch.Begin(transformMatrix: blueprintCamera.GetViewMatrix());
            spriteBatch.Draw(TextureManager.whiteBox, new Rectangle(20, 20, 20, 20), Color.White);
            spriteBatch.Draw(TextureManager.whiteBox, new Rectangle(40, 20, 20, 20), Color.Blue);
            spriteBatch.End();
        }

        private void Clear(Color color)
        {
            graphicsDevice.Clear(color);
        }

    }
}
