using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2;

namespace DoAnXNA2
{
    public class GameOver : GameState
    {       
        public GameOver(Game1 _game1) :
            base(_game1)
        { }

        protected override void SubUpdate(GameTime gameTime)
        {
            _backgroundManager.IsDecorationsDisplayed = false;
            InputUtilities.HandleKeyPress(Keys.Space, kstate, () => _game1.SetMainMenu());
        }

        protected override void SubDraw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "GAME OVER", new Vector2(_game1.virtualWidth / 2, _game1.virtualHeight / 2 - 200));
            SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "Press Space to Return Main Menu", new Vector2(_game1.virtualWidth / 2, _game1.virtualHeight / 2));
        }
    }
}
