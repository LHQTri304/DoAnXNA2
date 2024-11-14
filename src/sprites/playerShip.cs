using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2.src.utilities;
using System.Diagnostics;

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
        }

        private void Move(Vector2 direction, float elapsedTime)
        {
            Position += direction * Speed * elapsedTime;
        }

        private Vector2 GetMovementDirection(KeyboardState kstate)
        {
            Vector2 direction = Vector2.Zero;
            if (kstate.IsKeyDown(Keys.Up) || kstate.IsKeyDown(Keys.W)) direction.Y -= 1;
            if (kstate.IsKeyDown(Keys.Down) || kstate.IsKeyDown(Keys.S)) direction.Y += 1;
            if (kstate.IsKeyDown(Keys.Left) || kstate.IsKeyDown(Keys.A)) direction.X -= 1;
            if (kstate.IsKeyDown(Keys.Right) || kstate.IsKeyDown(Keys.D)) direction.X += 1;
            return direction;
        }

        private void MoveToMouse(float elapsedTime)
        {
            MouseState mouseState = Mouse.GetState();
            Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);

            /* // Tính hướng từ vị trí hiện tại của PlayerShip đến vị trí chuột
            Vector2 direction = mousePosition - Position;
            if (direction.Length() > 0)
                direction.Normalize(); // Chuẩn hóa vector để di chuyển với tốc độ cố định

            Position += direction * Speed * elapsedTime; */
            Position = mousePosition;
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

        public void Shoot()
        {
            if (_shootCooldown <= 0)
            {
                _game._allBullets.Add(new BulletPlayer(Textures.textureBulletP, new Vector2(Position.X, Position.Y), _bulletSpeed, 0));
                _shootCooldown = _shotReloading;
            }
        }

        private void KeepPlayerInsideWindow(GraphicsDeviceManager graphics)
        {
            float windowWidth = graphics.PreferredBackBufferWidth;
            float windowHeight = graphics.PreferredBackBufferHeight;
            Position = new Vector2(
                MathHelper.Clamp(Position.X, 0, windowWidth),
                MathHelper.Clamp(Position.Y, 0 + Texture.Height / 2, windowHeight - Texture.Height / 2)
            );
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

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, KeyboardState kstate)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Di chuyển & Giới hạn vị trí player trong cửa sổ
            MoveToMouse(elapsedTime);
            KeepPlayerInsideWindow(graphics);

            // Xử lý bắn
            if (_shootCooldown > 0) _shootCooldown -= elapsedTime;
            ShootWithMouse();

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
