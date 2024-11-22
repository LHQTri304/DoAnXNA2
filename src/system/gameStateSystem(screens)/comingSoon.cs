using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2;

namespace DoAnXNA2
{
    public class ComingSoon : GameState
    {       
        public ComingSoon(Game1 _game1) :
            base(_game1)
        { }

        protected override void SubUpdate(GameTime gameTime)
        {
            ReadyMadeBtn.MainMenuButton.Update(mstate, CommonPotion[0] + new Vector2(0, 100));
        }

        protected override void SubDraw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "COMING SOON...", CommonPotion[0] + new Vector2(0, -50));
            ReadyMadeBtn.MainMenuButton.Draw(spriteBatch);
        }
    }
}
