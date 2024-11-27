using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public class PlayerHeathHUD : I_HUD
    {
        private int _currentHP;
        private int _maxHP;

        public PlayerHeathHUD()
            : base()
        {
            _currentHP = 0;
            _maxHP = 0;
        }

        public override void Update(GameTime gameTime)
        {
            _currentHP = MainRes.PlayerShip.HP;
            _maxHP = HPStatsManager.PlayerHP;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            string text = $"HP: {_currentHP}/{_maxHP}";
            SimplifyDrawing.HandleBottomLeftText(spriteBatch, Font, text, new Vector2(15, 70), 0.25f);
        }
    }
}