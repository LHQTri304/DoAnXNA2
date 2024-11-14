using DoAnXNA2.src.utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2.src.gameState
{
    public class Setting : IGameState
    {
        private SpriteFont _font;

        public Setting(SpriteFont font)
        {
            _font = font;
        }

        public void Update(Game1 game, GameTime gameTime, KeyboardState kstate, MouseState mstate)
        {
            InputUtilities.HandleKeyPress(Keys.X,kstate,()=>game.SetMainMenu());
        }

        public void Draw(Game1 game, SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "SETTINGS", new Vector2(game.virtualWidth / 2, game.virtualHeight / 2 - 200));
            SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "Press X to Return to Main Menu", new Vector2(game.virtualWidth / 2, game.virtualHeight / 2));
        }
    }
}
