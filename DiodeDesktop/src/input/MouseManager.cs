using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DiodeDesktop.src.input
{
    class MouseManager
    {
        //Toggles
        private bool clickToggle;
        private bool interactToggle;

        public Rectangle selectedArea = new Rectangle();

        //Placeholder for mouse logic
        public void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();

            //Handle Logic based mouse controls
            if (DiodeCore.logicManager.logicRunning)
            {
                if (clickToggle != true)
                {
                    clickToggle = true;
                    DiodeCore.logicManager.OnClick();
                }
                } else
                {
                    clickToggle = false;
                }
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    if (interactToggle != true)
                    {
                        interactToggle = true;
                        DiodeCore.logicManager.OnInteract();
                    }
                } else
                {
                    interactToggle = false;
                }
        }

        //Returns a Vector2 of the location of the mouse
        //dependent on the screen. (Projected)
        public Vector2 GetScreenPosition()
        {
            return new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        }

        //Returns a Vector2 of the location of the mouse
        //dependent on the projection/world (Unprojected)
        public Vector2 GetWorldPosition()
        {
            var matrix = Matrix.Invert(DiodeCore.renderManager.blueprintCamera.GetViewMatrix());
            return Vector2.Transform(GetScreenPosition(), matrix);
        }

        

    }
}
