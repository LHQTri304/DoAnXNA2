using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2.src.sprites;

namespace DoAnXNA2.src.spawners
{
    public abstract class EnemySpawner
    {
        public List<Enemy> Enemies { get; set; }
        protected Vector2 _spawnPosition;
        protected Game1 _game;

        public EnemySpawner(Game1 game)
        {
            _game = game;
            Enemies = [];
        }

        public abstract void SpawnEnemy();

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            Enemies = Enemies.Where(enemy =>
            {
                enemy.Update(gameTime, graphics);
                return enemy.IsAlive; // Giữ lại kẻ địch còn sống
            }).ToList();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}
