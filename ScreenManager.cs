using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.GameScreens
{
    public enum GameState { Menu, Play }
    class ScreenManager : DrawableGameComponent
    {
        public static GameState gameState = GameState.Menu;
        public static Input keyboard;
        public static SpriteFont spriteFont;
        public static bool IsExiting = false;
        MenuScreen menuScreen;
        GameScreen gameScreen;
        SpriteBatch spriteBatch;
        public ScreenManager(Game game)
            : base(game)
        {
            menuScreen = new MenuScreen();
            gameScreen = new GameScreen();
            keyboard = new Input();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = Game1.content.Load<SpriteFont>("basic");
            menuScreen.UpdateTextPositioning();
            gameScreen.LoadContent();

        }
        public override void Update(GameTime gameTime)
        {
            keyboard.Update();
            if (gameState == GameState.Menu)
                menuScreen.Update(gameTime);
            else if (gameState == GameState.Play)
                gameScreen.Update(gameTime);
            if (IsExiting)
                this.Game.Exit();
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (gameState == GameState.Menu)
                menuScreen.Draw(spriteBatch);
            else if (gameState == GameState.Play)
                gameScreen.Draw(spriteBatch);
            base.Draw(gameTime);
            spriteBatch.End();

        }
    }
}
