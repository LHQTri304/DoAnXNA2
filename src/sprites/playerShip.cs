using System.Collections.Generic;
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

        // Danh sách để quản lý đạn
        public List<BulletPlayer> Bullets { get; set; }
        private float shootCoolDown;
        private float shootCoolDownTime = 1f; // thời gian chờ giữa các lần bắn

        public PlayerShip(Texture2D texture, Vector2 position, float speed)
        {
            Texture = texture;
            Position = position;
            Speed = speed;
            Bullets = new List<BulletPlayer>();
            shootCoolDown = 0;
        }

        public void Move(KeyboardState kstate, float updatedPlayerShipSpeed)
        {
            // Tạo biến tạm để thay đổi giá trị của Position
            Vector2 newPosition = Position;

            if (kstate.IsKeyDown(Keys.Up) || kstate.IsKeyDown(Keys.W))
                newPosition.Y -= updatedPlayerShipSpeed;
            if (kstate.IsKeyDown(Keys.Down) || kstate.IsKeyDown(Keys.S))
                newPosition.Y += updatedPlayerShipSpeed;
            if (kstate.IsKeyDown(Keys.Left) || kstate.IsKeyDown(Keys.A))
                newPosition.X -= updatedPlayerShipSpeed;
            if (kstate.IsKeyDown(Keys.Right) || kstate.IsKeyDown(Keys.D))
                newPosition.X += updatedPlayerShipSpeed;

            // Gán lại giá trị sau khi cập nhật
            Position = newPosition;
        }

        // Phương thức bắn đạn
        public void Shoot(Texture2D bulletTexture, float bulletSpeed)
        {
            if (shootCoolDown <= 0)
            {
                BulletPlayer bullet = new BulletPlayer(bulletTexture, new Vector2(Position.X, Position.Y), bulletSpeed);
                Bullets.Add(bullet);
                shootCoolDown = shootCoolDownTime; // Reset thời gian chờ sau khi bắn
            }
        }

        // Cập nhật trạng thái bắn đạn
        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, KeyboardState kstate, Texture2D bulletTexture, float bulletSpeed)
        {
            //update speed theo thời gian thực -> Giúp chuyển động nhìn mượt và thống nhất
            float updatedPlayerShipSpeed = Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Move(kstate, updatedPlayerShipSpeed); // Trạng thái di chuyển theo phím điều khiển

            // Cập nhật cooldown
            if (shootCoolDown > 0)
            {
                shootCoolDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            // Sử dụng tiện ích HandleKeyPress cho phím Space và hành động Shoot
            InputUtilities.HandleKeyPress(Keys.Space, kstate, () => Shoot(bulletTexture, bulletSpeed));

            // Cập nhật vị trí của các viên đạn và kiểm tra xem có chạm viền trên không
            for (int i = Bullets.Count - 1; i >= 0; i--)
            {
                Bullets[i].Move();
                if (Bullets[i].Position.Y < 0)
                {
                    Bullets.RemoveAt(i);
                }
            }

            // Giới hạn playerShip di chuyển trong cửa sổ
            KeepPlayerInsideWindow(graphics);
        }

        private void KeepPlayerInsideWindow(GraphicsDeviceManager graphics)
        {
            float windowWidth = graphics.PreferredBackBufferWidth;
            float windowHeight = graphics.PreferredBackBufferHeight;
            // Giới hạn vị trí của playerShip trong cửa sổ
            if (Position.X < 0)
                Position = new Vector2(windowWidth, Position.Y);
            if (Position.X > windowWidth)
                Position = new Vector2(0, Position.Y);
            if (Position.Y < (windowHeight * 2 / 3) + (Texture.Height / 2))
                Position = new Vector2(Position.X, (windowHeight * 2 / 3) + (Texture.Height / 2));
            if (Position.Y > windowHeight - (Texture.Height / 2))
                Position = new Vector2(Position.X, windowHeight - (Texture.Height / 2));
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            SimplifyDrawing.HandleCentered(_spriteBatch, Texture, Position);
        }
    }
}