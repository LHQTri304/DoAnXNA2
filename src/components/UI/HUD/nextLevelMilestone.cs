using System;
using DoAnXNA2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public class NextLevelMilestoneHUD : I_HUD
    {
        private int _playerCurrentLevel;

        public NextLevelMilestoneHUD(SpriteFont font)
            : base(font)
        {
            _playerCurrentLevel = 1;
        }

        public override void Update(GameTime gameTime)
        {
            _playerCurrentLevel = MainRes.PlayerShip.CurrentLevel;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            string text = $"To next LV: {ScoreTable.MilestoneLv0to10[_playerCurrentLevel + 1]}";
            spriteBatch.DrawString(Font, text, new Vector2(10, MainRes.ScreenHeight - 40), Color.White);
            //SimplifyDrawing.HandleCenteredText(spriteBatch, Font, timeText, new Vector2(100, 10));
        }
    }
}