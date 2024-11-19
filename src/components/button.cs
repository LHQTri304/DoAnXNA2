using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2
{
    public class Button
    {
        private Texture2D _texture;
        private Vector2 _position;

        public Button(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
        }

        public bool IsClicked(MouseState mouseState)
        {
            var mouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
            var buttonRectangle = new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
            return mouseRectangle.Intersects(buttonRectangle) && mouseState.LeftButton == ButtonState.Pressed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
