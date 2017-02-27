using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace deminage_bombe
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        public Vector2 Dimensions { private set; get; }
        public GameManager currentScreen;
        public KeyboardState oldState;
        public ContentManager Content { private set; get; }


        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }

        public ScreenManager()
        {
            Dimensions = new Vector2(960,720);
            currentScreen = new TitleScreen();

        }

        public void ContentLoad(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.ContentLoad(Content);
            oldState = Keyboard.GetState();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState newState = Keyboard.GetState();

            //if (newState.IsKeyDown(Keys.Space))
            //    currentScreen = new GameScreen(Content);
            //else if (newState.IsKeyDown(Keys.A))
            //    currentScreen = new TitleScreen(Content);

            if (currentScreen.changeScreen == "GameScreen" && currentScreen.state =="titleScreen")
                currentScreen = new GameScreen(Content);

            currentScreen.Update(gameTime);
        }

        public void  Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }

    }
}
