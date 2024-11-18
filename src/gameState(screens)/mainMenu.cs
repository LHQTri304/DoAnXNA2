using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2.src.utilities;

namespace DoAnXNA2.src.gameState
{
    public class MainMenu : GameState
    {
        public MainMenu(Game1 game) :
            base(game)
        { }

        protected override void SubUpdate(GameTime gameTime)
        {
            backgroundManager.IsDisableDecorations = false;
            InputUtilities.HandleKeyPress(Keys.Space, kstate, () => _game.SetChoosingLevels());
            InputUtilities.HandleKeyPress(Keys.X, kstate, () => _game.SetSetting());
        }

        protected override void SubDraw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "MAIN MENU", CommonPotion[0] + new Vector2(0, -200));
            SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "Press Space to Start\nPress X to Setting", CommonPotion[0]);
        }
    }
}
