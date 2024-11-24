using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public class GameOver : GameState
    {       
        public GameOver() :
            base()
        { }

        protected override void SubUpdate(GameTime gameTime)
        {
            ReadyMadeBtn.MainMenuButton.Update(mstate, CommonPotion[0] + new Vector2(0, 200));
        }

        protected override void SubDraw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCentered(spriteBatch, Textures.HeaderYouLose, CommonPotion[0] + new Vector2(0, -100));
            ReadyMadeBtn.MainMenuButton.Draw(spriteBatch);
        }
    }
}
