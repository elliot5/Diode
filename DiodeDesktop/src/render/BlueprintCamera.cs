
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DiodeDesktop.src
{
    class BlueprintCamera
    {
        //Camera viewport, readonly.
        private readonly Viewport _viewport;

        //Initialize the Camera
        public BlueprintCamera(Viewport viewport)
        {
            _viewport = viewport; 
            Rotation = 0;
            Zoom = 1;
            Speed = 100;
            Origin = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
            Position = Vector2.Zero;
        }

        //Matrix and setting based variables
        public float Speed { get; set; }
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public float Zoom { get; set; }
        public Vector2 Origin { get; set; }

        //Returns the view matrix constructed by the default/given variables
        public Matrix GetViewMatrix()
        {
            return
                Matrix.CreateTranslation(new Vector3(-Position, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }


        public Matrix GetProjectionMatrix()
        {
            return Matrix.CreateOrthographic(_viewport.Width, _viewport.Height, _viewport.MinDepth, _viewport.MaxDepth);
        }
    }
}
