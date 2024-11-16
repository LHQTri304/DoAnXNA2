using System.Collections.Generic;
using System.Linq;
using DoAnXNA2.src.spawners;
using DoAnXNA2.src.sprites;
using DoAnXNA2.src.UI;
using DoAnXNA2.src.utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2.src.gameState
{
    public class GameDisplay : IGameState
    {
        public int _Level { get; set; }
        private Game1 _game;
        private bool _isPaused;

        public GameDisplay(Game1 game)
        {
            _game = game;
        }

        public void Update(Game1 game, GameTime gameTime, KeyboardState kstate, MouseState mstate)
        {
            //Xử lý khi game tạm dừng
            InputUtilities.HandleKeyPress(Keys.Escape, kstate, () => _isPaused = !_isPaused);
            if (_isPaused)
            {
                InputUtilities.HandleKeyPress(Keys.Space, kstate, () => _isPaused = false);
                InputUtilities.HandleKeyPress(Keys.X, kstate, () => { _isPaused = false; game.SetMainMenu(); });
                return;
            }

            // Thêm kẻ địch liên tục (mỗi level tạm thời tương ứng với 1 spawner)
            _game._allSpawners[_Level - 1].StartAutoSpawn(0.3, 50);

            // Cập nhật các sprites
            _game._playerShip.Update(gameTime, game._graphics, kstate, mstate);
            _game._allSpawners[_Level - 1].Update(gameTime, game._graphics);
            _game._allBullets = _game._allBullets.Where(b => b.Position.Y >= 0 && b.Position.Y <= game.virtualHeight)
                                    .Select(b => { b.Move(); return b; }).ToList();

            // Cập nhật GUI và HUD
            foreach (var item in _game._gameHUD)
                item.Update(gameTime);
        }

        public void Draw(Game1 game, SpriteBatch spriteBatch)
        {
            _game._playerShip.Draw(spriteBatch);
            foreach (var bullet in _game._allBullets)
                bullet.Draw(spriteBatch);
            foreach (var enemy in _game._allSpawners[_Level - 1].Enemies)
                enemy.Draw(spriteBatch);
            foreach (var item in _game._gameHUD)
                item.Draw(spriteBatch);
            if (_isPaused)
                SimplifyDrawing.HandleCenteredText(spriteBatch, game.Content.Load<SpriteFont>("hudFontTest1"), "PAUSED\nPress Space to Continue\nPress X to Main Menu", new Vector2(game.virtualWidth / 2, game.virtualHeight / 2));
        }
    }
}
