using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public class GameScoreHUD : I_HUD
    {
        private double _gameScore;

        public GameScoreHUD(SpriteFont font)
            : base(font)
        {
            _gameScore = 0;
        }

        public override void Update(GameTime gameTime)
        {
            _gameScore = MainRes.CurrentScore;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            string text = $"Score: {_gameScore}";
            SimplifyDrawing.HandleBottomLeftText(spriteBatch, Font, text, new Vector2(15, MainRes.ScreenHeight - 70), 0.25f);
        }
    }
}