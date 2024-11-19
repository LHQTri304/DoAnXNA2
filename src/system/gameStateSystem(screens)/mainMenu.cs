using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2;

namespace DoAnXNA2
{
    public class MainMenu : GameState
    {
        public MainMenu(Game1 game) :
            base(game)
        { }

        protected override void SubUpdate(GameTime gameTime)
        {
            backgroundManager.IsDisableDecorations = false;
            _game._cursor.Update(mstate);

            //InputUtilities.HandleKeyPress(Keys.Space, kstate, () => _game.SetChoosingLevels());
            //InputUtilities.HandleKeyPress(Keys.X, kstate, () => _game.SetSetting());
        }

        protected override void SubDraw(SpriteBatch spriteBatch)
        {
            _game._cursor.Draw(spriteBatch);
            //SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "MAIN MENU", CommonPotion[0] + new Vector2(0, -200));
            //SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "Press Space to Start\nPress X to Setting", CommonPotion[0]);
        }
    }
}
