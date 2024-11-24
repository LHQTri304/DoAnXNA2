using System.Collections.Generic;
using System.Linq;
using DoAnXNA2.src.levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2
{
    public class GameDisplay : GameState
    {
        public int CurrentLevel { get; set; }
        private List<Level> ListLevels = [];

        public GameDisplay() :
            base()
        {
            _isBGDecorDisplayed = false;
            _isCursorDisplayed = false;
            RenewListLevels();
        }

        public void RenewListLevels()
        {
            ListLevels = [
                new Level01(), new Level02(), new Level03(), new Level04(), new Level05(), new Level06(), new Level01(),
                new Level08(), new Level09(), new Level10(), new Level11(), new Level12(), new Level13(), new Level01(),
                new Level15(), new Level16(), new Level17(), new Level18(), new Level19(), new Level20(), new Level01(),
            ];
        }

        protected override void SubUpdate(GameTime gameTime)
        {
            //Xử lý khi win:
            if (MainRes.AllEnemies.Count == 0 && MainRes.IsAbleToWin)
                MainRes.GSM.SetVictory();

            //Xử lý khi tạm dừng
            _isCursorDisplayed = false;
            InputUtilities.HandleKeyPress(Keys.Escape, kstate, () => MainRes.IsPaused = !MainRes.IsPaused);
            if (MainRes.IsPaused)
            {
                _isCursorDisplayed = true;
                ReadyMadeBtn.ResumeButton.Update(mstate, CommonPotion[0] + new Vector2(100, 175));
                ReadyMadeBtn.MainMenuButton.Update(mstate, CommonPotion[0] + new Vector2(-100, 175));
                return;
            }

            // Thêm kẻ địch liên tục
            Level SelectedLevel = ListLevels[CurrentLevel - 1];
            SelectedLevel.Update(gameTime);


            // Cập nhật các sprites
            MainRes.PlayerShip.Update(gameTime, kstate, mstate);
            MainRes.AllEnemies.RemoveAll(enemy =>
            {
                enemy.Update(gameTime);
                return !enemy.IsAlive; // Giữ lại kẻ địch còn sống
            });
            MainRes.AllBullets = MainRes.AllBullets.Where(b => b.Position.Y >= 0 && b.Position.Y <= MainRes.ScreenHeight)
                .Select(b => { b.Move(); return b; }).ToList();

            // Cập nhật GUI và HUD
            foreach (var item in MainRes.GameHUD)
                item.Update(gameTime);
        }

        protected override void SubDraw(SpriteBatch spriteBatch)
        {
            MainRes.PlayerShip.Draw(spriteBatch);
            foreach (var bullet in MainRes.AllBullets)
                bullet.Draw(spriteBatch);
            foreach (var enemy in MainRes.AllEnemies)
                enemy.Draw(spriteBatch);
            foreach (var item in MainRes.GameHUD)
                item.Draw(spriteBatch);
            if (MainRes.IsPaused)
            {
                SimplifyDrawing.HandleCentered(spriteBatch, Textures.WindowLong, CommonPotion[0], 0.66f);
                SimplifyDrawing.HandleCentered(spriteBatch, Textures.HeaderPause, CommonPotion[0] + new Vector2(0, -210));
                ReadyMadeBtn.ResumeButton.Draw(spriteBatch);
                ReadyMadeBtn.MainMenuButton.Draw(spriteBatch);
            }
        }
    }
}
