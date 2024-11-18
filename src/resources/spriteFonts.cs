using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public static class SpriteFonts
    {
        public static SpriteFont Arial;
        public static SpriteFont SVN_Dumpling;


        public static SpriteFont LoadSpriteFonts(ContentManager content)
        {
            Arial = content.Load<SpriteFont>("hudFontArial");
            SVN_Dumpling = content.Load<SpriteFont>("hudFontSVN-Dumpling");
            try
            {
                return SVN_Dumpling;
            }
            catch (ContentLoadException)
            {
                System.Diagnostics.Debug.WriteLine("Cài font đẹp thất bại");
                return Arial;
            }
        }
    }
}
