using System.Linq;
using DoAnXNA2.src.spawners;
using DoAnXNA2.src.sprites;
using DoAnXNA2.src.utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2.src.gameState
{
    public class GameDisplay : IGameState
    {
        private PlayerShip _playerShip;
        private EnemySpawner _enemySpawner;
        private GameHUD _gameHUD;

        private bool _isPaused;

        //For spawner        
        private double spawnTimer = 0; // Để kiểm soát thời gian giữa các lần spawn
        private double spawnInterval = 2.0; // Thời gian (giây) giữa mỗi lần spawn

        // Thêm tham chiếu đến Game1 --> Phục vụ game over và allBullets
        private Game1 _game;

        public GameDisplay(Game1 game, PlayerShip playerShip, EnemySpawner enemySpawner, GameHUD gameHUD)
        {
            _game = game;
            _playerShip = playerShip;
            _enemySpawner = enemySpawner;
            _gameHUD = gameHUD;
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

            //Xử lý spawner enemies
            spawnTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (spawnTimer >= spawnInterval)
            {
                spawnTimer = 0;
                _enemySpawner.SpawnEnemy();
            }

            // Cập nhật các sprites
            _playerShip.Update(gameTime, game._graphics, kstate, mstate);
            _enemySpawner.Update(gameTime, game._graphics);
            _game._allBullets = _game._allBullets.Where(b => b.Position.Y >= 0 && b.Position.Y <= game.virtualHeight)
                                    .Select(b => { b.Move(); return b; }).ToList();

            // Cập nhật GUI và HUD
            _gameHUD.Update(gameTime, _enemySpawner.Enemies.Count);
        }

        public void Draw(Game1 game, SpriteBatch spriteBatch)
        {
            _playerShip.Draw(spriteBatch);
            foreach (var bullet in _game._allBullets)
                bullet.Draw(spriteBatch);
            foreach (var enemy in _enemySpawner.Enemies)
                enemy.Draw(spriteBatch);
            if (_isPaused)
                SimplifyDrawing.HandleCenteredText(spriteBatch, game.Content.Load<SpriteFont>("hudFontTest1"), "PAUSED\nPress Space to Continue\nPress X to Main Menu", new Vector2(game.virtualWidth / 2, game.virtualHeight / 2));
        }
    }
}
