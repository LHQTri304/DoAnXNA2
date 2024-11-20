using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2;
using System.Collections.Generic;

namespace DoAnXNA2
{
    public class GameDisplay : GameState
    {
        public int _Level { get; set; }
        private bool _isPaused;

        public GameDisplay(Game1 _game1) :
            base(_game1)
        {
            _isBGDecorDisplayed = false;
            _isCursorDisplayed = false;
        }

        protected override void SubUpdate(GameTime gameTime)
        {
            //Xử lý khi _game1 tạm dừng
            InputUtilities.HandleKeyPress(Keys.Escape, kstate, () => _isPaused = !_isPaused);
            if (_isPaused)
            {
                InputUtilities.HandleKeyPress(Keys.Space, kstate, () => _isPaused = false);
                InputUtilities.HandleKeyPress(Keys.X, kstate, () => { _isPaused = false; _game1.SetMainMenu(); });
                return;
            }

            // Thêm kẻ địch liên tục
            int[] limit = [4,3,2];
            if(_game1._allEnemies.OfType<EYellow>().ToList().Count <= limit[0])
                _game1._allSpawners[0].SpawnEnemy();
            if(_game1._allEnemies.OfType<ERed>().ToList().Count <= limit[1])
                _game1._allSpawners[1].SpawnEnemy();
            if(_game1._allEnemies.OfType<EGreen>().ToList().Count <= limit[2])
                _game1._allSpawners[2].SpawnEnemy();


            // Cập nhật các sprites
            _game1._playerShip.Update(gameTime, _game1._graphics, kstate, mstate);
            _game1._allEnemies.RemoveAll(enemy =>
            {
                enemy.Update(gameTime, _game1._graphics);
                return !enemy.IsAlive; // Giữ lại kẻ địch còn sống
            });
            _game1._allBullets = _game1._allBullets.Where(b => b.Position.Y >= 0 && b.Position.Y <= _game1.virtualHeight)
                                    .Select(b => { b.Move(); return b; }).ToList();

            // Cập nhật GUI và HUD
            foreach (var item in _game1._gameHUD)
                item.Update(gameTime);
        }

        protected override void SubDraw(SpriteBatch spriteBatch)
        {
            _game1._playerShip.Draw(spriteBatch);
            foreach (var bullet in _game1._allBullets)
                bullet.Draw(spriteBatch);
            foreach (var enemy in _game1._allEnemies)
                enemy.Draw(spriteBatch);
            foreach (var item in _game1._gameHUD)
                item.Draw(spriteBatch);
            if (_isPaused)
                SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "PAUSED\nPress Space to Continue\nPress X to Main Menu", CommonPotion[0]);
        }
    }
}
