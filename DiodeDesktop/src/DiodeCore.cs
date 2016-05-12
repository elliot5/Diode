
using DiodeDesktop.src.render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DiodeDesktop
{
    class DiodeCore : Game
    {
        RenderManager renderManager;
        GraphicsDeviceManager graphicsManager;

        public DiodeCore()
        {
            graphicsManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            renderManager = new RenderManager(graphicsManager.GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
           
        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            renderManager.Render(gameTime);
            base.Draw(gameTime);
        }
    }
}
