using System;
using System.Collections.Generic;
using DoAnXNA2.src.utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#nullable enable

namespace DoAnXNA2.src.gameState
{
    public struct ContentInfo
    {
        public string? Text;
        public Texture2D? Texture;
        public Vector2 Position;

        public ContentInfo(string text, Vector2 position)
        {
            Text = text;
            Position = position;
        }
        public ContentInfo(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }
    }
    public class ChoosingLevels : IGameState
    {
        private SpriteFont _font;
        private int _selectedLevel = 1; // Level mặc định

        public ChoosingLevels(SpriteFont font)
        {
            _font = font;
        }

        private Texture2D GetLevelImg()
        {
            return _selectedLevel switch
            {
                1 => Textures.textureEnemyYellow,
                2 => Textures.textureEnemyRed,
                3 => Textures.textureEnemyGreen,
                _ => Textures.texturePlayer,
            };
        }

        public void Update(Game1 game, GameTime gameTime, KeyboardState kstate, MouseState mstate)
        {
            InputUtilities.HandleKeyPress(Keys.Escape, kstate, () => game.SetMainMenu());
            InputUtilities.HandleMouseClick(mstate.LeftButton, 0, () => _selectedLevel = Math.Max(1, _selectedLevel - 1)); //Lv min = 1
            InputUtilities.HandleMouseClick(mstate.RightButton, 1, () => _selectedLevel = Math.Min(3, _selectedLevel + 1)); // Lv max = 3
            InputUtilities.HandleKeyPress(Keys.Space, kstate, () => game.SetGameDisplay(_selectedLevel));
        }

        public void Draw(Game1 game, SpriteBatch spriteBatch)
        {
            var gWidth = game.virtualWidth;
            var gHeight = game.virtualHeight;
            var centeredX = gWidth / 2;
            var centeredY = gHeight / 2;

            List<ContentInfo> _contentText = [
                new("CHOOSE YOUR LEVEL", new Vector2(centeredX, centeredY - 200)),
                new("<< Left Click to Previous | Right Click to Next >>", new Vector2(centeredX, centeredY - 50)),
                new($"Selected level: {_selectedLevel}", new Vector2(centeredX, centeredY)),
                new("Press SPACE to Start", new Vector2(centeredX, centeredY + 100)),
            ];
            List<ContentInfo> _contentImg = [
                new(GetLevelImg(), new Vector2(centeredX, centeredY - 100)),
            ];

            foreach (var item in _contentText)
                SimplifyDrawing.HandleCenteredText(spriteBatch, _font, item.Text, item.Position);
            foreach (var item in _contentImg)
                SimplifyDrawing.HandleCentered(spriteBatch, item.Texture, item.Position);
            SimplifyDrawing.HandleTopLeftText(spriteBatch, _font, "Press ESC to return to Main Menu", new Vector2(10, 10));
        }
    }
}
