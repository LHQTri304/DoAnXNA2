using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public class HealthBar
    {
        private Texture2D _tableStart, _tableMiddle, _tableEnd;
        private Texture2D _barStart, _barMiddle, _barEnd;
        private Dictionary<int, (Texture2D barStart, Texture2D barMiddle, Texture2D barEnd)> BarTextures;
        private int _currentHP;
        private int _maxHP;
        private int _totalWidth;
        private float _scale;
        public Vector2 Position { get; set; }

        public HealthBar(int indexTexture, Vector2 position, int maxHP, int totalWidth, float scale = 1.0f)
        {
            Position = position;
            _maxHP = maxHP;
            _currentHP = maxHP;
            _totalWidth = totalWidth;
            _scale = scale;
            LoadTexture(indexTexture);
        }

        public void LoadTexture(int index)
        {
            _tableStart = Textures.Bar_Table_1_1;
            _tableMiddle = Textures.Bar_Table_1_2;
            _tableEnd = Textures.Bar_Table_1_3;

            BarTextures = new Dictionary<int, (Texture2D, Texture2D, Texture2D)>()
                {
                    { 1, (Textures.Health_Bar_1_1, Textures.Health_Bar_1_2, Textures.Health_Bar_1_3) },
                    { 2, (Textures.Health_Bar_2_1, Textures.Health_Bar_2_2, Textures.Health_Bar_2_3) },
                };

            if (BarTextures.TryGetValue(index, out var textures))
            {
                _barStart = textures.barStart;
                _barMiddle = textures.barMiddle;
                _barEnd = textures.barEnd;
            }
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
            DrawTableBar(spriteBatch, Position, (int)(_totalWidth * 1.025), _scale);
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

        private void DrawTableBar(SpriteBatch spriteBatch, Vector2 centerPosition, int totalWidth, float scale)
        {
            int startWidth = (int)(_tableStart.Width * scale);
            int endWidth = (int)(_tableEnd.Width * scale);
            int middleWidth = (int)(_tableMiddle.Width * scale);

            int filledWidth = totalWidth - startWidth - endWidth;
            if (filledWidth < 0) filledWidth = 0;

            int barHeight = (int)(_tableStart.Height * scale);

            Vector2 topLeftPosition = new Vector2(
                centerPosition.X - totalWidth / 2,
                centerPosition.Y - barHeight / 2
            );

            spriteBatch.Draw(
                _tableStart,
                new Rectangle((int)topLeftPosition.X, (int)topLeftPosition.Y, startWidth, barHeight),
                Color.White
            );

            int middleX = (int)topLeftPosition.X + startWidth;
            int remainingWidth = filledWidth;

            while (remainingWidth > 0)
            {
                int drawWidth = Math.Min(remainingWidth, middleWidth);
                spriteBatch.Draw(
                    _tableMiddle,
                    new Rectangle(middleX, (int)topLeftPosition.Y, drawWidth, barHeight),
                    Color.White
                );
                middleX += drawWidth;
                remainingWidth -= drawWidth;
            }
            spriteBatch.Draw(
                _tableEnd,
                new Rectangle(middleX, (int)topLeftPosition.Y, endWidth, barHeight),
                Color.White
            );
        }
    }
}
