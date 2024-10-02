using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public static class Textures
    {
        public static Texture2D texturePlayer;
        public static Texture2D textureBulletP;

        public static void LoadTextures(ContentManager content)
        {
            texturePlayer = content.Load<Texture2D>("player");
            textureBulletP = content.Load<Texture2D>("bulletPlayer");
        }
    }
}
