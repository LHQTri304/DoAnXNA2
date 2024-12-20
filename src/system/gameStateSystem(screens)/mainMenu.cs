using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public class MainMenu : GameState
    {
        public MainMenu() :
            base()
        { }

        protected override void SubUpdate(GameTime gameTime)
        {
            ReadyMadeBtn.PlayButton.Update(mstate, CommonPotion[0] + new Vector2(100, 200));
            ReadyMadeBtn.SettingsButton.Update(mstate, CommonPotion[0] + new Vector2(-100, 200));
        }

        protected override void SubDraw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCentered(spriteBatch, Textures.TitleGame, CommonPotion[0] + new Vector2(0, -100), 0.3f);
            ReadyMadeBtn.PlayButton.Draw(spriteBatch);
            ReadyMadeBtn.SettingsButton.Draw(spriteBatch);
        }
    }
}
