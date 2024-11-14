using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2.src.utilities;
using System.Diagnostics;
using DoAnXNA2.src.strategyMethod;

namespace DoAnXNA2.src.sprites
{
    public class PlayerShip
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public bool IsAlive { get; set; }

        // Quản lý bắn đạn
        private float _bulletSpeed;
        private float _shootCooldown;
        private readonly float _shotReloading;
        protected IPlayerShootingStrategy ShootingStrategy;


        // Thêm tham chiếu đến Game1 --> Phục vụ game over và allBullets
        private Game1 _game;

        public PlayerShip(Game1 game, Vector2 position, float speed)
        {
            _game = game;
            Texture = Textures.texturePlayer;
            Position = new Vector2(game.virtualWidth / 2, game.virtualHeight / 2);
            Speed = 1000f;
            IsAlive = true;
            _bulletSpeed = 3.5f;
            _shootCooldown = 0;
            _shotReloading = 0.1f;
            ShootingStrategy = new StraightShot();
        }
        public void ShootWithMouse()
        {
            MouseState mouseState = Mouse.GetState();
            if (_shootCooldown <= 0 && mouseState.LeftButton == ButtonState.Pressed)
            {
                _game._allBullets.Add(new BulletPlayer(Textures.textureBulletP, Position, _bulletSpeed, 0));
                _shootCooldown = _shotReloading;
            }
        }

        private void CheckCollisionWithBullet()
        {
            var playerBounds = QuickGetUtilities.GetPlayerBounds(Position, Texture);
            _game._allBullets.OfType<BulletEnemy>().ToList().RemoveAll(bullet =>
            {
                var bulletBounds = QuickGetUtilities.GetBounds(bullet.Position, bullet.Texture);
                return CollisionUtilities.CheckCollision(
                    playerBounds,
                    bulletBounds,
                    () =>
                    {
                        System.Diagnostics.Debug.WriteLine("bạn đã bị bắn");
                        IsAlive = false;
                        _game.SetGameOver(); //Cập nhật trạng thái game
                    }
                );
            });
        }

        private void CheckCollisionWithEnemy()
        {
            var playerBounds = QuickGetUtilities.GetPlayerBounds(Position, Texture);
            _game._enemySpawner.Enemies.RemoveAll(enemy =>
            {
                var enemyBounds = QuickGetUtilities.GetBounds(enemy.Position, enemy.Texture);
                return CollisionUtilities.CheckCollision(
                    playerBounds,
                    enemyBounds,
                    () =>
                    {
                        System.Diagnostics.Debug.WriteLine("bạn đã tông trúng kẻ địch");
                        IsAlive = false;
                        _game.SetGameOver(); //Cập nhật trạng thái game
                    }
                );
            });
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, KeyboardState kstate, MouseState mstate)
        {
            // Di chuyển & Giới hạn vị trí player trong cửa sổ
            Position = MovementPlayerUtilities.GetNewPosition(Position, mstate);
            Position = MovementPlayerUtilities.KeepPlayerInsideWindow(graphics, Position, Texture);

            // Xử lý bắn
            //if (_shootCooldown > 0) _shootCooldown -= elapsedTime;
            //ShootWithMouse();
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            ShootingStrategy.Shoot(elapsedTime, mstate, Position, _game._allBullets);
            

            // Xử lý thua
            CheckCollisionWithBullet();
            CheckCollisionWithEnemy();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCentered(spriteBatch, Texture, Position);
        }
    }
}
