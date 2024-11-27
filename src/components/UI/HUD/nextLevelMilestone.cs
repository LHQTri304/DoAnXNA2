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
            SimplifyDrawing.HandleBottomLeftText(spriteBatch, Font, text, new Vector2(15, MainRes.ScreenHeight - 40), 0.25f);
        }
    }
}