using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public abstract class I_HUD   //Heads-Up Display
    {
        protected SpriteFont Font { get; set; }

        public I_HUD(SpriteFont font)
        {
            Font = font;
        }
        
        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}