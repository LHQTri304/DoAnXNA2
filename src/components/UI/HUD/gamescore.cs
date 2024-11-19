using System;
using DoAnXNA2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public class GameScoreHUD : I_HUD
    {
        private double _gameScore;

        public GameScoreHUD(Game1 game, SpriteFont font)
            : base(game, font)
        {
            _gameScore = 0;
        }

        public override void Update(GameTime gameTime)
        {
            _gameScore = _game._currentScore;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            string text = $"Score: {_gameScore}";
            spriteBatch.DrawString(Font, text, new Vector2(10, _game.virtualHeight - 70), Color.White);
            //SimplifyDrawing.HandleCenteredText(spriteBatch, Font, timeText, new Vector2(100, 10));
        }
    }
}