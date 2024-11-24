using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System;
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
                4 => Textures.EnemyBlue,
                5 => Textures.EnemyOrange,
                6 => Textures.EnemyPurple,
                7 => Textures.Dot_02,
                8 => Textures.EnemyGray,
                9 => Textures.EnemyCyan,
                10 => Textures.EnemyPink,
                11 => Textures.EnemyBrown,
                12 => Textures.EnemyTeal,
                13 => Textures.EnemyLime,
                14 => Textures.Dot_02,
                15 => Textures.EnemyBlack,
                16 => Textures.EnemyWhite,
                17 => Textures.EnemyGold,
                18 => Textures.EnemySilver,
                19 => Textures.EnemyMaroon,
                20 => Textures.EnemyNavy,
                21 => Textures.Dot_02,
                _ => Textures.Player,
            };
        }

        private void SetLevels()
        {
            for (int level = 1; level <= _levelPositions.Count; level++)
            {
                int currentLevel = level;
                _levelButtons.Add(
                    new Button(_game1, Textures.Blank_BTN, Textures.Blank_BTN_Active,
                    (level == 7 || level == 14 | level == 21) ?
                        () => _game1.SetComingSoon() :
                        () => _game1.SetGameDisplay(currentLevel))
                );
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
            {
                Texture2D Img = GetLevelImg(index + 1);
                float Scale = Textures.Blank_BTN.Width / Img.Width * 0.45f;
                SimplifyDrawing.HandleCentered(spriteBatch, GetLevelImg(index + 1), levelP, Scale);
            }
            ReadyMadeBtn.BackwardButton.Draw(spriteBatch);
        }
    }
}
