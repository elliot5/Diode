using DiodeDesktop.src.logic.gate;
using DiodeDesktop.src.logic.gate.list;
using DiodeDesktop.src.logic.list;
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
        //Keyboard states
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        //This is called each gameUpdate. All movement should be multiplied by deltaTime,
        //to stop depending speeds on different computers.
        public void Update(GameTime gameTime)
        {
            //Set the currentKeyboardState
            currentKeyboardState = Keyboard.GetState();

            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Camera Controls

            if (currentKeyboardState.IsKeyDown(Keys.Q))
                DiodeCore.renderManager.blueprintCamera.Zoom += 1 * deltaTime;

            if (currentKeyboardState.IsKeyDown(Keys.E))
                DiodeCore.renderManager.blueprintCamera.Zoom -= 1 * deltaTime;

            if (currentKeyboardState.IsKeyDown(Keys.W))
                DiodeCore.renderManager.blueprintCamera.Position -= new Vector2(0, DiodeCore.renderManager.blueprintCamera.Speed) * deltaTime;

            if (currentKeyboardState.IsKeyDown(Keys.S))
                DiodeCore.renderManager.blueprintCamera.Position += new Vector2(0, DiodeCore.renderManager.blueprintCamera.Speed) * deltaTime;

            if (currentKeyboardState.IsKeyDown(Keys.A))
                DiodeCore.renderManager.blueprintCamera.Position -= new Vector2(DiodeCore.renderManager.blueprintCamera.Speed, 0) * deltaTime;

            if (currentKeyboardState.IsKeyDown(Keys.D))
                DiodeCore.renderManager.blueprintCamera.Position += new Vector2(DiodeCore.renderManager.blueprintCamera.Speed, 0) * deltaTime;

            if (currentKeyboardState.IsKeyDown(Keys.D1) && !previousKeyboardState.IsKeyDown(Keys.D1))
            {
                LogicGate andGate = new AndGate();
                DiodeCore.logicManager.gateManager.AddGate(andGate);
            }
            if (currentKeyboardState.IsKeyDown(Keys.D2) && !previousKeyboardState.IsKeyDown(Keys.D2))
            {
                LogicGate notGate = new NotGate();
                DiodeCore.logicManager.gateManager.AddGate(notGate);
            }
            if (currentKeyboardState.IsKeyDown(Keys.D3) && !previousKeyboardState.IsKeyDown(Keys.D3))
            {
                LightComponent lightComponent = new LightComponent();
                DiodeCore.logicManager.gateManager.AddGate(lightComponent);
            }


            //Set the previousKeyboardState
            previousKeyboardState = currentKeyboardState;
        }
    }
}
