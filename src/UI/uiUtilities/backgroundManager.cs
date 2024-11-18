using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2.src.utilities
{
    public class BackgroundManager
    {
        private Game1 _game;
        private Texture2D backgroundTexture;
        private List<Texture2D> decorationTextures;
        private List<Decoration> decorations;
        private int maxDecorations;
        private float backgroundYPosition;
        private Random random;
        private double spawnTimer;
        private double nextSpawnTime;

        //Random management (min,max)
        private Range SpawnTime = new(0.25f, 3.75f);
        private Range Speed = new(50f, 200f);
        private Range Scale = new(0.5f, 2.25f);
        private float TheLastRandomX = 0;

        //When in battle
        public bool IsDisableDecorations { get; set; }


        public BackgroundManager(Game1 game)
        {
            _game = game;
            decorations = new List<Decoration>();
            maxDecorations = 10;
            backgroundYPosition = 0f;
            random = new Random();
            nextSpawnTime = 0f;
            backgroundTexture = Textures.BackgroundStuff[0];
            decorationTextures = Textures.BackgroundStuff.Where(x => x != backgroundTexture).ToList();
            IsDisableDecorations = false;
        }

        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Update background position
            backgroundYPosition += 1f;
            if (backgroundYPosition >= backgroundTexture.Height)
                backgroundYPosition = 0f;

            // Handle when disable --> Not update the decorations
            if (IsDisableDecorations)
                return;

            // Update spawn timer
            spawnTimer += gameTime.ElapsedGameTime.TotalSeconds;

            // Spawn decorations
            if (spawnTimer >= nextSpawnTime && decorations.Count < maxDecorations)
            {
                SpawnDecorations();
                spawnTimer = 0;
                nextSpawnTime = GetRandom(SpawnTime); // Set next spawn time
            }

            // Update decorations
            for (int i = decorations.Count - 1; i >= 0; i--)
            {
                decorations[i].Position += new Vector2(0, decorations[i].Speed * elapsed);

                // Remove decorations off-screen
                float YOffScreen = _game.virtualHeight + decorations[i].Texture.Height * decorations[i].Scale;
                if (decorations[i].Position.Y > YOffScreen)
                {
                    decorations.RemoveAt(i);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw background
            SimplifyDrawing.HandleTopLeft(spriteBatch, backgroundTexture, new Vector2(0, backgroundYPosition));
            SimplifyDrawing.HandleTopLeft(spriteBatch, backgroundTexture, new Vector2(0, backgroundYPosition - backgroundTexture.Height));

            // Draw decorations
            if (IsDisableDecorations)
                return;
            foreach (var decoration in decorations)
            {
                SimplifyDrawing.HandleRotatingTexture(spriteBatch, decoration.Texture, decoration.Position, GetRotateSpeed(decoration), decoration.Scale, decoration.IsRotateClockwise, GetRotateSpeed(decoration));
            }
        }

        private void SpawnDecorations()
        {
            int groupSize = random.Next(1, 4); // Random group size (1 to 3 items)
            for (int i = 0; i < groupSize; i++)
            {
                Texture2D texture = decorationTextures[random.Next(decorationTextures.Count)];
                float scale = (float)GetRandom(Scale); // Scale between 0.5 and 3.75
                float speed = (float)GetRandom(Speed); // Speed between 25 and 100
                Vector2 position = new(
                    GetRanPositionX(texture, scale),
                    -texture.Height * scale
                );
                bool clockwise = random.Next(2) == 1;

                decorations.Add(new Decoration(texture, position, scale, speed, clockwise));
            }
        }

        private double GetRandom(Range value)
        {
            return random.NextDouble() * (value.Max - value.Min) + value.Min;
        }
        private float GetRanPositionX(Texture2D texture, float scale)
        {
            float x = random.Next(0, _game.virtualWidth - (int)(texture.Width * scale));
            if (Math.Abs(x - TheLastRandomX) <= _game.virtualWidth / 5)
                return GetRanPositionX(texture, scale); // Gọi lại đệ quy nếu không thỏa mãn
            TheLastRandomX = x;
            return x;
        }

        private float GetRotateSpeed(Decoration decoration)
        {
            return (Scale.Max - decoration.Scale) / 5000 + 0.00001f;
        }
    }

    public class Decoration
    {
        public Texture2D Texture { get; }
        public Vector2 Position { get; set; }
        public float Scale { get; }
        public float Speed { get; }
        public bool IsRotateClockwise { get; }

        public Decoration(Texture2D texture, Vector2 position, float scale, float speed, bool clockwise)
        {
            Texture = texture;
            Position = position;
            Scale = scale;
            Speed = speed;
            IsRotateClockwise = clockwise;
        }
    }

    public struct Range
    {
        public float Min { get; set; }
        public float Max { get; set; }

        public Range(float min, float max)
        {
            Min = min;
            Max = max;
        }

        public bool IsWithinRange(float value) => value >= Min && value <= Max;
    }
}
