using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2
{
    public class Cursor
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }

        public Cursor()
        {
            Texture = Textures.Cursor;
            Position = new Vector2(0, 0);
        }

        public void ReloadTexture()
        {
            Texture = Textures.Cursor;
        }

        public void Update(MouseState mstate)
        {
            Vector2 mousePosition = new(mstate.X, mstate.Y);
            Position = mousePosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleTopLeft(spriteBatch, Texture, Position - new Vector2(3,4));
            //SimplifyDrawing.HandleCentered(spriteBatch, Textures.BulletP, Position);
        }
    }
}
