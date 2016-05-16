using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DiodeDesktop.src.render
{
    class TextureManager
    {
        //Textures
        public static Texture2D whiteBox;

        //Called on LoadContent, Initialize all textures.
        public static void Load(ContentManager content)
        {
            whiteBox = content.Load<Texture2D>("squareTexture");
        }

    }
}
