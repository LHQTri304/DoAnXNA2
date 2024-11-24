using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2
{
    public class Button
    {
        private Texture2D _defaultTexture;
        private Texture2D _hoverTexture;
        private Vector2 _position;
        private Action _onClick;
        private bool _isPressed;
        public float Scale { get; set; }

        public Button(Texture2D defaultTexture, Texture2D hoverTexture, Action onClick)
        {
            _defaultTexture = defaultTexture;
            _hoverTexture = hoverTexture;
            _position = new Vector2(0, 0);
            _onClick = onClick;
            _isPressed = false;
            Scale = 0.5f;
        }

        public void SetPosition(Vector2 newPosition)
        {
            _position = newPosition;
        }

        public bool CheckHovered()
        {
            var btnBounds = QuickGetUtilities.GetBounds(_position, _defaultTexture);
            Rectangle realBtnBounds = new(
                (int)(btnBounds.X + btnBounds.Width * (1 - Scale) / 2),
                (int)(btnBounds.Y + btnBounds.Height * (1 - Scale) / 2),
                (int)(btnBounds.Width * Scale),
                (int)(btnBounds.Height * Scale)
            );
            return realBtnBounds.Contains(MainRes.Cursor.Position);
        }

        public void Update(MouseState mstate, Vector2 newPosition)
        {
            if (mstate.LeftButton == ButtonState.Released)
                _isPressed = false;
            SetPosition(newPosition);
            if (CheckHovered() && !_isPressed && mstate.LeftButton == ButtonState.Pressed)
            {
                _isPressed = true;
                _onClick?.Invoke();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var currentTexture = CheckHovered() ? _hoverTexture : _defaultTexture;
            SimplifyDrawing.HandleCentered(spriteBatch, currentTexture, _position, Scale);
        }
    }
}
