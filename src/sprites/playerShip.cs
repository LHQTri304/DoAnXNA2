using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2.src.utilities;

namespace DoAnXNA2.src.sprites
{
    public class PlayerShip
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public List<BulletPlayer> Bullets;

        // Quản lý bắn đạn
        private float _shootCooldown;
        private readonly float _shootCooldownTime = 1f;

        public PlayerShip(Texture2D texture, Vector2 position, float speed)
        {
            Texture = texture;
            Position = position;
            Speed = speed;
            Bullets = new List<BulletPlayer>();
            _shootCooldown = 0;
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

        public void Shoot(Texture2D bulletTexture, float bulletSpeed)
        {
            if (_shootCooldown <= 0)
            {
                Bullets.Add(new BulletPlayer(bulletTexture, new Vector2(Position.X, Position.Y), bulletSpeed));
                _shootCooldown = _shootCooldownTime;
            }
        }

        private void KeepPlayerInsideWindow(GraphicsDeviceManager graphics)
        {
            float windowWidth = graphics.PreferredBackBufferWidth;
            float windowHeight = graphics.PreferredBackBufferHeight;
            Position = new Vector2(
                MathHelper.Clamp(Position.X, 0, windowWidth),
                MathHelper.Clamp(Position.Y, (windowHeight * 2 / 3) + Texture.Height / 2, windowHeight - Texture.Height / 2)
            );
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, KeyboardState kstate, Texture2D bulletTexture, float bulletSpeed)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Di chuyển
            Vector2 direction = GetMovementDirection(kstate);
            Move(direction, elapsedTime);

            // Cập nhật thời gian cooldown
            if (_shootCooldown > 0) _shootCooldown -= elapsedTime;

            // Xử lý bắn
            InputUtilities.HandleKeyPress(Keys.Space, kstate, () => Shoot(bulletTexture, bulletSpeed));

            // Cập nhật vị trí viên đạn
            foreach (var bullet in Bullets) bullet.Move();
            Bullets = Bullets.Where(b => b.Position.Y >= 0).ToList();

            // Giới hạn vị trí player trong cửa sổ
            KeepPlayerInsideWindow(graphics);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCentered(spriteBatch, Texture, Position);
        }
    }
}
