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
        private bool _isPaused;

        public GameDisplay(Game1 _game1) :
            base(_game1)
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
            if(_game1.AllEnemies.Count == 0 && _game1.IsAbleToWin)
                _game1.SetVictory();

            //Xử lý khi tạm dừng
            InputUtilities.HandleKeyPress(Keys.Escape, kstate, () => _isPaused = !_isPaused);
            if (_isPaused)
            {
                InputUtilities.HandleKeyPress(Keys.Space, kstate, () => _isPaused = false);
                InputUtilities.HandleKeyPress(Keys.X, kstate, () => { _isPaused = false; _game1.SetMainMenu(); });
                return;
            }

            // Thêm kẻ địch liên tục
            Level SelectedLevel = ListLevels[CurrentLevel - 1];
            SelectedLevel.Update(_game1, gameTime);


            // Cập nhật các sprites
            _game1.PlayerShip.Update(gameTime, _game1.Graphics, kstate, mstate);
            _game1.AllEnemies.RemoveAll(enemy =>
            {
                enemy.Update(gameTime, _game1.Graphics);
                return !enemy.IsAlive; // Giữ lại kẻ địch còn sống
            });
            _game1.AllBullets = _game1.AllBullets.Where(b => b.Position.Y >= 0 && b.Position.Y <= _game1.VirtualHeight)
                .Select(b => { b.Move(); return b; }).ToList();

            // Cập nhật GUI và HUD
            foreach (var item in _game1.GameHUD)
                item.Update(gameTime);
        }

        protected override void SubDraw(SpriteBatch spriteBatch)
        {
            _game1.PlayerShip.Draw(spriteBatch);
            foreach (var bullet in _game1.AllBullets)
                bullet.Draw(spriteBatch);
            foreach (var enemy in _game1.AllEnemies)
                enemy.Draw(spriteBatch);
            foreach (var item in _game1.GameHUD)
                item.Draw(spriteBatch);
            if (_isPaused)
                SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "PAUSED\nPress Space to Continue\nPress X to Main Menu", CommonPotion[0]);
        }
    }
}
