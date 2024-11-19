using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2
{
    public class Button
    {
        private Game1 _game1;
        private Texture2D Texture;
        private Vector2 Position;
        private Action OnClick;
        private bool IsPressed;
        public float Scale { get; set; }

        public Button(Game1 game1, Texture2D texture, Action onClick)
        {
            _game1 = game1;
            Texture = texture;
            Position = new Vector2(0, 0);
            OnClick = onClick;
            IsPressed = false;
            Scale = 0.5f;
        }

        public void SetPosition(Vector2 newPosition)
        {
            Position = newPosition;
        }

        public bool CheckReady()
        {
            var btnBounds = QuickGetUtilities.GetBounds(Position, Texture);
            Rectangle realBtnBounds = new(
                (int)(btnBounds.X + btnBounds.Width * (1 - Scale) / 2),
                (int)(btnBounds.Y + btnBounds.Height * (1 - Scale) / 2),
                (int)(btnBounds.Width * Scale),
                (int)(btnBounds.Height * Scale)
            );
            return realBtnBounds.Contains(_game1._cursor.Position);
        }

        public void Update(MouseState mstate, Vector2 newPosition)
        {
            if (mstate.LeftButton == ButtonState.Released)
                IsPressed = false;
            SetPosition(newPosition);
            if (CheckReady() && !IsPressed && mstate.LeftButton == ButtonState.Pressed)
            {
                IsPressed = true;
                OnClick?.Invoke();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCentered(spriteBatch, Texture, Position, Scale);
        }
    }
}
