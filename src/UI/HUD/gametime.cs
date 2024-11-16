using System;
using DoAnXNA2.src.utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2.src.UI
{
    public class GameTimeHUD : I_HUD
    {
        private TimeSpan _gameTimeElapsed;

        public GameTimeHUD(Game1 game, SpriteFont font)
            : base(game, font)
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
            SimplifyDrawing.HandleCenteredText(spriteBatch, Font, timeText, new Vector2(10, 10));
        }
    }
}