using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public class LoadingBar
    {
        private float _progress;
        private int _totalWidth;
        private Texture2D _barStart, _barMiddle, _barEnd;
        public Vector2 Position { get; set; }

        public LoadingBar(Vector2 position, int totalWidth)
        {
            Position = position;
            _progress = 0f;
            _totalWidth = totalWidth;
            _barStart = Textures.Loading_Bar_3_1;
            _barMiddle = Textures.Loading_Bar_3_2;
            _barEnd = Textures.Loading_Bar_3_3;
        }

        public void SetProgress(float newProgress)
        {
            _progress = newProgress;
        }

        public void Update(GameTime gameTime, float adjustSpeed = 0.2f)
        {
            _progress += (float)gameTime.ElapsedGameTime.TotalSeconds * adjustSpeed;
            if (_progress > 1f)
                _progress = 1f; // Cap progress at 100%
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawLoadingBar(spriteBatch, Position, _totalWidth, _progress);
        }


        private void DrawLoadingBar(SpriteBatch spriteBatch, Vector2 centerPosition, int totalWidth, float progress)
        {
            // Width of start, middle, and end parts
            int startWidth = _barStart.Width;
            int endWidth = _barEnd.Width;
            int middleWidth = _barMiddle.Width;

            // Calculate the width of the middle section based on progress
            int filledWidth = (int)((totalWidth - startWidth - endWidth) * progress);
            if (filledWidth < 0) filledWidth = 0;

            // Calculate the total height of the bar
            int barHeight = _barStart.Height;

            // Calculate the top-left position based on the center position
            Vector2 topLeftPosition = new Vector2(
                centerPosition.X - totalWidth / 2, // Center horizontally
                centerPosition.Y - barHeight / 2  // Center vertically
            );

            // Draw start part
            spriteBatch.Draw(
                _barStart,
                new Rectangle((int)topLeftPosition.X, (int)topLeftPosition.Y, startWidth, barHeight),
                Color.White
            );

            // Draw middle part (repeated texture)
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

            // Draw end part (only if progress > 0)
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
