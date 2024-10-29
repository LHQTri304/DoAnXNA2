using System.Linq;
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

        public GameDisplay(PlayerShip playerShip, EnemySpawner enemySpawner, GameHUD gameHUD)
        {
            _playerShip = playerShip;
            _enemySpawner = enemySpawner;
            _gameHUD = gameHUD;
        }

        public void Update(Game1 game, GameTime gameTime, KeyboardState kstate)
        {
            // Cập nhật các sprites
            _playerShip.Update(gameTime, game._graphics, kstate, _enemySpawner.Enemies.SelectMany(e => e.Bullets).ToList(), Textures.textureBulletP, 5f);
            _enemySpawner.Update(gameTime, game._graphics, Textures.textureEnemy, _playerShip.Bullets, Textures.textureBulletE, 3.5f);

            // Cập nhật GUI và HUD
            _gameHUD.Update(gameTime, _enemySpawner.Enemies.Count);

            // Kiểm tra điều kiện thua
            foreach (var _enemy in _enemySpawner.Enemies)
                _playerShip.CheckCollisionWithBulletEnemy(_enemy.Bullets);
            if (game._isGameOver)
                game.SetGameOver();
        }

        public void Draw(Game1 game, SpriteBatch spriteBatch)
        {
            _playerShip.Draw(spriteBatch);
            foreach (var bullet in _playerShip.Bullets)
                bullet.Draw(spriteBatch);
            foreach (var enemy in _enemySpawner.Enemies)
            {
                enemy.Draw(spriteBatch);
                foreach (var bullet in enemy.Bullets)
                    bullet.Draw(spriteBatch);
            }
        }
    }
}
