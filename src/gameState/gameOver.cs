using DoAnXNA2.src.utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2.src.gameState
{
    public class GameOver : IGameState
    {
        private SpriteFont _font;
        
        public GameOver(SpriteFont font)
        {
            _font = font;
        }

        public void Update(Game1 game, GameTime gameTime, KeyboardState kstate)
        {
            InputUtilities.HandleKeyPress(Keys.Space, kstate, () => game.SetMainMenu());
        }

        public void Draw(Game1 game, SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "GAME OVER", new Vector2(game.virtualWidth / 2, game.virtualHeight / 2 - 200));
            SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "Press Space to Return Main Menu", new Vector2(game.virtualWidth / 2, game.virtualHeight / 2));
        }
    }
}
