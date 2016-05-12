using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiodeDesktop.src.render
{
    class TextureManager
    {

        public static Texture2D whiteBox;

        public static void Load(ContentManager content)
        {
            whiteBox = content.Load<Texture2D>("squareTexture");
        }

    }
}
