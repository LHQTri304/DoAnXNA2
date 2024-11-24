using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public class Victory : GameState
    {       
        public Victory() :
            base()
        { }

        protected override void SubUpdate(GameTime gameTime)
        {
            ReadyMadeBtn.MainMenuButton.Update(mstate, CommonPotion[0] + new Vector2(0, 175));
        }

        protected override void SubDraw(SpriteBatch spriteBatch)
        {
            //SimplifyDrawing.HandleCentered(spriteBatch, Textures.WindowLong, CommonPotion[0], 0.66f);
            SimplifyDrawing.HandleCentered(spriteBatch, Textures.Star_03, CommonPotion[0] + new Vector2(-120, -80), 0.45f, 30f);
            SimplifyDrawing.HandleCentered(spriteBatch, Textures.Star_03, CommonPotion[0] + new Vector2(120, -80), 0.45f, -30f);
            SimplifyDrawing.HandleCentered(spriteBatch, Textures.Star_03, CommonPotion[0] + new Vector2(0, -90), 0.5f);
            //SimplifyDrawing.HandleCentered(spriteBatch, Textures.HeaderScore, CommonPotion[0], 0.5f);
            //SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "1234567890", CommonPotion[0] + new Vector2(0, 45),0.3f);
            SimplifyDrawing.HandleCentered(spriteBatch, Textures.HeaderYouWin, CommonPotion[0] + new Vector2(0, -210));
            ReadyMadeBtn.MainMenuButton.Draw(spriteBatch);
        }
    }
}
