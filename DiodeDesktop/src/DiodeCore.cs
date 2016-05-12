
using DiodeDesktop.src.input;
using DiodeDesktop.src.render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DiodeDesktop
{
    class DiodeCore : Game
    {
        public static RenderManager renderManager;
        public static KeyboardManager keyboardManager;

        GraphicsDeviceManager graphicsManager;

        public DiodeCore()
        {
            IsMouseVisible = true;
            graphicsManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            renderManager = new RenderManager(graphicsManager.GraphicsDevice);
            keyboardManager = new KeyboardManager();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            TextureManager.Load(Content);
        }
        
        protected override void UnloadContent()
        {
            Content.Unload();
        }


        protected override void Update(GameTime gameTime)
        {
            keyboardManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            renderManager.Render(gameTime);
            base.Draw(gameTime);
        }
    }
}
