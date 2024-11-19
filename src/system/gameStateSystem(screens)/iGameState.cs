using System;
using System.Collections.Generic;
using DoAnXNA2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DoAnXNA2
{
    public abstract class GameState
    {
        protected Game1 _game;
        protected SpriteFont _font;
        protected KeyboardState kstate;
        protected MouseState mstate;
        protected BackgroundManager backgroundManager;
        protected Dictionary<int, Vector2> CommonPotion = [];
        // 0 = Center | 1 = TopLeft | 2 = TopRight | 3 = BottomLeft | 4 = BottomRight


        public GameState(Game1 game)
        {
            _game = game;
            _font = game._font;
            GetKeyStateMouseState();
            backgroundManager = new BackgroundManager(_game);
            CommonPotion.Add(0, new Vector2(game.virtualWidth / 2, game.virtualHeight / 2));
            CommonPotion.Add(1, new Vector2(0, 0));
            CommonPotion.Add(2, new Vector2(game.virtualWidth, 0));
            CommonPotion.Add(3, new Vector2(0, game.virtualHeight));
            CommonPotion.Add(4, new Vector2(game.virtualWidth, game.virtualHeight));
        }
        protected void GetKeyStateMouseState()
        {
            kstate = Keyboard.GetState();
            mstate = Mouse.GetState();
        }
        public void Update(GameTime gameTime)
        {
            backgroundManager.Update(gameTime);
            GetKeyStateMouseState();
            SubUpdate(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            backgroundManager.Draw(spriteBatch);
            SubDraw(spriteBatch);
        }
        protected abstract void SubUpdate(GameTime gameTime);
        protected abstract void SubDraw(SpriteBatch spriteBatch);
    }
}
