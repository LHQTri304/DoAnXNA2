using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public class HealthBar
    {
        private int _currentHP;
        private int _maxHP;
        private int _totalWidth;
        private float _scale;
        private Texture2D _barStart, _barMiddle, _barEnd;
        public Vector2 Position { get; set; }

        public HealthBar(Vector2 position, int maxHP, int totalWidth, float scale = 1.0f)
        {
            Position = position;
            _maxHP = maxHP;
            _currentHP = maxHP;
            _totalWidth = totalWidth;
            _scale = scale;
            _barStart = Textures.Health_Bar_1_1; // Giả định Textures chứa các thành phần texture
            _barMiddle = Textures.Health_Bar_1_2;
            _barEnd = Textures.Health_Bar_1_3;
        }

        public void SetHP(int newHP)
        {
            _currentHP = MathHelper.Clamp(newHP, 0, _maxHP);
        }

        public void Update(GameTime gameTime, int targetHP, float adjustSpeed = 0.2f)
        {
            // Điều chỉnh mượt mà HP
            int deltaHP = targetHP - _currentHP;
            if (Math.Abs(deltaHP) > 0)
            {
                int adjustAmount = (int)(adjustSpeed * _maxHP * gameTime.ElapsedGameTime.TotalSeconds);
                _currentHP += Math.Sign(deltaHP) * Math.Min(Math.Abs(deltaHP), adjustAmount);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float progress = (float)_currentHP / _maxHP;
            DrawHealthBar(spriteBatch, Position, _totalWidth, progress, _scale);
        }

        private void DrawHealthBar(SpriteBatch spriteBatch, Vector2 centerPosition, int totalWidth, float progress, float scale)
        {
            int startWidth = (int)(_barStart.Width * scale);
            int endWidth = (int)(_barEnd.Width * scale);
            int middleWidth = (int)(_barMiddle.Width * scale);

            int filledWidth = (int)((totalWidth - startWidth - endWidth) * progress);
            if (filledWidth < 0) filledWidth = 0;

            int barHeight = (int)(_barStart.Height * scale);

            Vector2 topLeftPosition = new Vector2(
                centerPosition.X - totalWidth / 2,
                centerPosition.Y - barHeight / 2
            );

            spriteBatch.Draw(
                _barStart,
                new Rectangle((int)topLeftPosition.X, (int)topLeftPosition.Y, startWidth, barHeight),
                Color.White
            );

            int middleX = (int)topLeftPosition.X + startWidth;
            int remainingWidth = filledWidth;

            while (remainingWidth > 0)
            {
                int drawWidth = Math.Min(remainingWidth, middleWidth);
                spriteBatch.Draw(
                    _barMiddle,
                    new Rectangle(middleX, (int)topLeftPosition.Y, drawWidth, barHeight),
                    Color.White
                );
                middleX += drawWidth;
                remainingWidth -= drawWidth;
            }

            if (progress > 0)
            {
                spriteBatch.Draw(
                    _barEnd,
                    new Rectangle(middleX, (int)topLeftPosition.Y, endWidth, barHeight),
                    Color.White
                );
            }
        }
    }
}
