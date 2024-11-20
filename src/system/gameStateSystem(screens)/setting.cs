using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2;

namespace DoAnXNA2
{
    public class Setting : GameState
    {
        public Setting(Game1 _game1) :
            base(_game1)
        { 
            _isBGDecorDisplayed = true;
            _isCursorDisplayed = true;
        }

        protected override void SubUpdate(GameTime gameTime)
        {
            ReadyMadeBtn.BackwardButton.Update(mstate, CommonPotion[0] + new Vector2(0, 200));
        }

        protected override void SubDraw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "SETTINGS", CommonPotion[0] + new Vector2(0, -200));
            ReadyMadeBtn.BackwardButton.Draw(spriteBatch);
            //SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "Press X to Return to Main Menu", CommonPotion[0]);
        }
    }
}
