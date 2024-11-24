using System;
using DoAnXNA2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public class GameTimeHUD : I_HUD
    {
        private TimeSpan _gameTimeElapsed;

        public GameTimeHUD(SpriteFont font)
            : base(font)
        {
            _gameTimeElapsed = TimeSpan.Zero;
        }

        public override void Update(GameTime gameTime)
        {
            _gameTimeElapsed += gameTime.ElapsedGameTime;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            string timeText = $"Time: {_gameTimeElapsed.TotalSeconds:F2}";
            spriteBatch.DrawString(Font, timeText, new Vector2(10, 10), Color.White);
            //SimplifyDrawing.HandleCenteredText(spriteBatch, Font, timeText, new Vector2(100, 10));
        }
    }
}