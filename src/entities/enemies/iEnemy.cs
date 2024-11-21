using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public abstract class Enemy
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        protected int ScoreKilled { get; set; }
        public bool IsAlive { get; set; } = true;

        //Quản lý cơ chế di chuyển & bắn
        protected IMovementStrategy MovementStrategy;
        protected IBaseShootingStrategy ShootingStrategy;

        // Thêm tham chiếu đến Game1 --> Phục vụ game over và allBullets
        private Game1 _game1;

        public Enemy(Game1 game, Texture2D texture, Vector2 position, int scoreKilled, IMovementStrategy movementStrategy, IBaseShootingStrategy shootingStrategy)
        {
            _game1 = game;
            Texture = texture;
            Position = position;
            ScoreKilled = scoreKilled;
            MovementStrategy = movementStrategy;
            ShootingStrategy = shootingStrategy;
        }

        private void CheckCollisions()
        {
            CheckCollisionQuick.EnemyVsBulletPlayer(this, _game1.AllBullets, () =>
                    {
                        Soundtrack.EnemyKilled.Play(0.1f, 0f, 0f);
                        _game1._currentScore += ScoreKilled;
                        IsAlive = false; // Kẻ địch bị tiêu diệt
                    });
        }

        private void CheckOutOfScreen()
        {
            if (Position.Y > _game1.VirtualHeight + 50)
                IsAlive = false;
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            if (!IsAlive) return; // Không cập nhật kẻ địch nếu nó đã bị tiêu diệt

            ShootingStrategy.Shoot(gameTime, Position, _game1.AllBullets);
            Position = MovementStrategy.Move(gameTime, graphics, Position);
            CheckCollisions();
            CheckOutOfScreen();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive)
                SimplifyDrawing.HandleCentered(spriteBatch, Texture, Position, 0.6f);
        }
    }
}