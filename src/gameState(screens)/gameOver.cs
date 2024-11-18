using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2.src.utilities;

namespace DoAnXNA2.src.gameState
{
    public class GameOver : GameState
    {       
        public GameOver(Game1 _game) :
            base(_game)
        { }

        protected override void SubUpdate(GameTime gameTime)
        {
            backgroundManager.IsDisableDecorations = false;
            InputUtilities.HandleKeyPress(Keys.Space, kstate, () => _game.SetMainMenu());
        }

        protected override void SubDraw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "GAME OVER", new Vector2(_game.virtualWidth / 2, _game.virtualHeight / 2 - 200));
            SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "Press Space to Return Main Menu", new Vector2(_game.virtualWidth / 2, _game.virtualHeight / 2));
        }
    }
}
