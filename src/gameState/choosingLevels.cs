using System;
using DoAnXNA2.src.utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2.src.gameState
{
    public class ChoosingLevels : IGameState
    {
        private SpriteFont _font;
        private int _selectedLevel = 1; // Level mặc định

        public ChoosingLevels(SpriteFont font)
        {
            _font = font;
        }

        public void Update(Game1 game, GameTime gameTime, KeyboardState kstate)
        {
            InputUtilities.HandleKeyPress(Keys.X,kstate,()=>game.SetMainMenu());
            InputUtilities.HandleKeyPress(Keys.Left,kstate,()=>_selectedLevel = Math.Max(1, _selectedLevel - 1)); // Di chuyển level
            InputUtilities.HandleKeyPress(Keys.Right,kstate,()=>_selectedLevel = Math.Min(5, _selectedLevel + 1)); // Giả sử có 5 level
            InputUtilities.HandleKeyPress(Keys.Space,kstate,()=>game.SetGameDisplay(_selectedLevel)); // Bắt đầu game với level đã chọn
        }

        public void Draw(Game1 game, SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "CHOOSE LEVEL", new Vector2(game.virtualWidth / 2, game.virtualHeight / 2 - 200));
            SimplifyDrawing.HandleCenteredText(spriteBatch, _font, $"Selected Level: {_selectedLevel}", new Vector2(game.virtualWidth / 2, game.virtualHeight / 2));
            SimplifyDrawing.HandleCenteredText(spriteBatch, _font, "Press X to Return to Main Menu", new Vector2(game.virtualWidth / 2, game.virtualHeight / 2 + 100));
        }
    }
}
