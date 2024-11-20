using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2;

namespace DoAnXNA2
{
    public class GameDisplay : GameState
    {
        public int _Level { get; set; }
        private bool _isPaused;

        public GameDisplay(Game1 _game) :
            base(_game)
        {
            _isBGDecorDisplayed = false;
            _isCursorDisplayed = false;
        }

        protected override void SubUpdate(GameTime gameTime)
        {
            //Xử lý khi _game tạm dừng
            InputUtilities.HandleKeyPress(Keys.Escape, kstate, () => _isPaused = !_isPaused);
            if (_isPaused)
            {
                InputUtilities.HandleKeyPress(Keys.Space, kstate, () => _isPaused = false);
                InputUtilities.HandleKeyPress(Keys.X, kstate, () => { _isPaused = false; _game1.SetMainMenu(); });
                return;
            }

            // Thêm kẻ địch liên tục (mỗi level tạm thời tương ứng với 1 spawner)
            _game1._allSpawners[0].StartAutoSpawn(0.3, 50);

            // Cập nhật các sprites
            _game1._playerShip.Update(gameTime, _game1._graphics, kstate, mstate);
            _game1._allSpawners[0].Update(gameTime, _game1._graphics);
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
            foreach (var enemy in _game1._allSpawners[0].Enemies)
                enemy.Draw(spriteBatch);
            foreach (var item in _game1._gameHUD)
                item.Draw(spriteBatch);
            if (_isPaused)
                SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "PAUSED\nPress Space to Continue\nPress X to Main Menu", CommonPotion[0]);
        }
    }
}
