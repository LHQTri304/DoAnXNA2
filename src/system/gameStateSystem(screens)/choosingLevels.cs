using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2;
#nullable enable

namespace DoAnXNA2
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
    public class ChoosingLevels : GameState
    {
        private int _selectedLevel = 1; // Level mặc định

        public ChoosingLevels(Game1 _game) :
            base(_game)
        { }

        private Texture2D GetLevelImg()
        {
            return _selectedLevel switch
            {
                1 => Textures.EnemyYellow,
                2 => Textures.EnemyRed,
                3 => Textures.EnemyGreen,
                _ => Textures.Player,
            };
        }

        protected override void SubUpdate(GameTime gameTime)
        {
            backgroundManager.IsDisableDecorations = false;
            InputUtilities.HandleKeyPress(Keys.Escape, kstate, () => _game.SetMainMenu());
            InputUtilities.HandleMouseClick(mstate.LeftButton, 0, () => _selectedLevel = Math.Max(1, _selectedLevel - 1)); //Lv min = 1
            InputUtilities.HandleMouseClick(mstate.RightButton, 1, () => _selectedLevel = Math.Min(3, _selectedLevel + 1)); // Lv max = 3
            InputUtilities.HandleKeyPress(Keys.Space, kstate, () => _game.SetGameDisplay(_selectedLevel));
        }

        protected override void SubDraw(SpriteBatch spriteBatch)
        {
            List<ContentInfo> _contentText = [
                new("CHOOSE YOUR LEVEL", CommonPotion[0]+new Vector2(0, - 200)),
                new("<< Left Click to Previous | Right Click to Next >>", CommonPotion[0]+new Vector2(0, - 50)),
                new($"Selected level: {_selectedLevel}", CommonPotion[0]),
                new("Press SPACE to Start", CommonPotion[0]+new Vector2(0, + 100)),
            ];
            List<ContentInfo> _contentImg = [
                new(GetLevelImg(), CommonPotion[0]+new Vector2(0, - 100)),
            ];

            foreach (var item in _contentText)
                SimplifyDrawing.HandleCenteredText(spriteBatch, _font, item.Text, item.Position);
            foreach (var item in _contentImg)
                SimplifyDrawing.HandleCentered(spriteBatch, item.Texture, item.Position);
            SimplifyDrawing.HandleTopLeftText(spriteBatch, _font, "Press ESC to return to Main Menu", CommonPotion[1] + new Vector2(10, 10));
        }
    }
}
