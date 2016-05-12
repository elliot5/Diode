using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiodeDesktop.src.input
{
    class KeyboardManager
    {
        public void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var keyboardState = Keyboard.GetState();

            //Camera Controls
            if (keyboardState.IsKeyDown(Keys.W))
                DiodeCore.renderManager.blueprintCamera.Position -= new Vector2(0, DiodeCore.renderManager.blueprintCamera.Speed) * deltaTime;

            if (keyboardState.IsKeyDown(Keys.S))
                DiodeCore.renderManager.blueprintCamera.Position += new Vector2(0, DiodeCore.renderManager.blueprintCamera.Speed) * deltaTime;

            if (keyboardState.IsKeyDown(Keys.A))
                DiodeCore.renderManager.blueprintCamera.Position -= new Vector2(DiodeCore.renderManager.blueprintCamera.Speed, 0) * deltaTime;

            if (keyboardState.IsKeyDown(Keys.D))
                DiodeCore.renderManager.blueprintCamera.Position += new Vector2(DiodeCore.renderManager.blueprintCamera.Speed, 0) * deltaTime;
        }
    }
}
