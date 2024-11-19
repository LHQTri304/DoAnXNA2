using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public static class QuickGetUtilities
    {
        public static Rectangle GetPlayerBounds(Vector2 _position, Texture2D _texture)
        {
            int Top = (int)_position.X - _texture.Width / 4;
            int Left = (int)_position.Y - _texture.Height / 4;
            int Width = _texture.Width / 2;
            int Height = _texture.Height / 2;
            return new Rectangle(Top, Left, Width, Height);
        }
        public static Rectangle GetBounds(Vector2 _position, Texture2D _texture)
        {
            int Top = (int)_position.X - _texture.Width / 2;
            int Left = (int)_position.Y - _texture.Height / 2;
            int Width = _texture.Width;
            int Height = _texture.Height;
            return new Rectangle(Top, Left, Width, Height);
        }
    }
}
