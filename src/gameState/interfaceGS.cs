using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2.src.gameState
{
    public interface IGameState
    {
        void Update(Game1 game, GameTime gameTime, KeyboardState kstate);
        void Draw(Game1 game, SpriteBatch spriteBatch);
    }
}
