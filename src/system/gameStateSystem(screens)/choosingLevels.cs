using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
#nullable enable

namespace DoAnXNA2
{
    public class ChoosingLevels : GameState
    {
        private readonly List<Vector2> _levelPositions = [];
        private readonly List<Button> _levelButtons = [];

        public ChoosingLevels(Game1 _game1) :
            base(_game1)
        {
            SetPositions();
            SetLevels();
        }

        private Texture2D GetLevelImg(int SelectedLevel)
        {
            return SelectedLevel switch
            {
                1 => Textures.EnemyYellow,
                2 => Textures.EnemyRed,
                3 => Textures.EnemyGreen,
                _ => Textures.Player,
            };
        }

        private void SetLevels()
        {
            for (int level = 1; level <= _levelPositions.Count; level++)
            {
                int currentLevel = level;
                _levelButtons.Add(new Button(_game1, Textures.Blank_BTN, Textures.Blank_BTN_Active, () => _game1.SetGameDisplay(currentLevel)));
            }
        }

        private void SetPositions()
        {
            int columns = 7;
            int rows = 3;
            float screenWidth = _game1.VirtualWidth;
            float screenHeight = _game1.VirtualHeight;

            // Centered region dimensions
            float regionWidth = (float)(screenWidth * 0.75);
            float regionHeight = (float)(screenHeight * 0.4);

            // Calculate spacings
            float xSpacing = regionWidth / (columns - 1);
            float ySpacing = regionHeight / (rows - 1);

            // Starting point of the region
            float startX = (screenWidth - regionWidth) / 2;
            float startY = (screenHeight - regionHeight) / 3;

            // Generate positions
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    int x = (int)(startX + col * xSpacing);
                    int y = (int)(startY + row * ySpacing);
                    _levelPositions.Add(new Vector2(x, y));
                }
            }
            return;
        }

        protected override void SubUpdate(GameTime gameTime)
        {
            ReadyMadeBtn.BackwardButton.Update(mstate, CommonPotion[0] + new Vector2(0, 200));
            foreach (var (position, button) in _levelPositions.Zip(_levelButtons, (p, b) => (p, b)))
                button.Update(mstate, position);
        }

        protected override void SubDraw(SpriteBatch spriteBatch)
        {
            foreach (var levelB in _levelButtons)
                levelB.Draw(spriteBatch);
            foreach (var (levelP, index) in _levelPositions.Select((value, idx) => (value, idx)))
                SimplifyDrawing.HandleCentered(spriteBatch, GetLevelImg(index + 1), levelP, 1.5f);
            ReadyMadeBtn.BackwardButton.Draw(spriteBatch);
        }
    }
}
