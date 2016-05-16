
using DiodeDesktop.src.input;
using DiodeDesktop.src.logic;
using DiodeDesktop.src.logic.debug;
using DiodeDesktop.src.render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DiodeDesktop
{
    class DiodeCore : Game
    {
        //Config
        public static string _VERSION = "1.1";
        public static bool _VSYNC = true;
        public static bool _SHOWMOUSE = true;
        public static string _ROOTDIR = "Content";

        //Static Managers
        public static RenderManager renderManager;
        public static KeyboardManager keyboardManager;
        public static MouseManager mouseManager;
        public static LogicManager logicManager;
        public static GraphicsDeviceManager graphicsManager;
        public static DebugManager debugManager;

        //Pre-Initialize
        public DiodeCore()
        {
            Window.AllowUserResizing = true;
            IsFixedTimeStep = _VSYNC;
            IsMouseVisible = _SHOWMOUSE;
            Content.RootDirectory = _ROOTDIR;
            graphicsManager = new GraphicsDeviceManager(this);
        }

        //Initialize Content
        protected override void Initialize()
        {
            renderManager = new RenderManager(graphicsManager.GraphicsDevice);
            keyboardManager = new KeyboardManager();
            mouseManager = new MouseManager();
            logicManager = new LogicManager();
            debugManager = new DebugManager();
            base.Initialize();
        }

        //Load Content
        protected override void LoadContent()
        {
            TextureManager.Load(Content);
        }
        
        //Unload Content
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        //Update Managers
        protected override void Update(GameTime gameTime)
        {
            SetWindowTitle(gameTime);
            debugManager.Update(gameTime);
            logicManager.Update(gameTime);
            keyboardManager.Update(gameTime);
            mouseManager.Update(gameTime);
            base.Update(gameTime);
        }

        //Render Managers
        protected override void Draw(GameTime gameTime)
        {
            debugManager.DrawUpdate(gameTime);
            renderManager.Render(gameTime);
            base.Draw(gameTime);
        }

        //Set the windows title
        private void SetWindowTitle(GameTime gameTime)
        {
            Window.Title = "Diode " + _VERSION + " | FPS: " + debugManager.GetFPS() + " | UDP: " + debugManager.GetUPS();
        }
    }
}
