using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2
{
    public abstract class GameState
    {
        protected SpriteFont _font;
        protected KeyboardState kstate;
        protected MouseState mstate;
        protected BackgroundManager _backgroundManager;
        protected bool _isBGDecorDisplayed = true;
        protected bool _isCursorDisplayed = true;
        protected List<Vector2> CommonPotion = new();

        // LoadingBar instance
        private LoadingBar _loadingBar;
        private int _loadBarLength;
        private float _loadDuration;
        private bool _isLoadingActive = false;
        private float _loadingTimeElapsed = 0f;

        public GameState(int loadBarLength = 300, float loadDuration = 0.5f)
        {
            _font = MainRes.Font;
            GetKeyStateMouseState();
            _backgroundManager = new BackgroundManager();
            _isCursorDisplayed = true;
            CommonPotion = MainRes.CommonPotion;

            // Initialize LoadingBar
            _loadBarLength = loadBarLength;
            _loadDuration = loadDuration;
            _loadingBar = new LoadingBar(CommonPotion[0], _loadBarLength);
        }

        protected void GetKeyStateMouseState()
        {
            kstate = Keyboard.GetState();
            mstate = Mouse.GetState();
        }

        public void Update(GameTime gameTime)
        {
            if (_isLoadingActive)
            {
                // Update the LoadingBar progress
                float adjustSpeed = 1f / _loadDuration;
                _loadingBar.Update(gameTime, adjustSpeed);
                _loadingTimeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

                // End loading if time has elapsed
                if (_loadingTimeElapsed >= _loadDuration)
                {
                    _isLoadingActive = false;
                    _loadingTimeElapsed = 0f;
                }
            }

            if (!_isLoadingActive)
                GetKeyStateMouseState();

            // Regular updates
            if (_isCursorDisplayed)
                MainRes.Cursor.Update(mstate);
            _backgroundManager.IsDecorationsDisplayed = _isBGDecorDisplayed;
            _backgroundManager.Update(gameTime);
            SubUpdate(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_isLoadingActive)
            {
                _backgroundManager.Draw(spriteBatch);
                _loadingBar.Draw(spriteBatch);
                return; // Skip other draws
            }

            // Regular drawing
            _backgroundManager.Draw(spriteBatch);
            SubDraw(spriteBatch);
            if (_isCursorDisplayed)
                MainRes.Cursor.Draw(spriteBatch);
        }

        public void StartLoading()
        {
            _isLoadingActive = true;
            _loadingTimeElapsed = 0f;
            _loadingBar.SetProgress(0f); // Reset progress
        }

        protected abstract void SubUpdate(GameTime gameTime);
        protected abstract void SubDraw(SpriteBatch spriteBatch);
    }
}
