using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace defused_the_bomb
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        public Vector2 Dimensions { private set; get; }

        public SceneManager currentScene;
        public GameManager currentScreen;

        public KeyboardState oldState;
        public ContentManager Content { private set; get; }

        MouseState mouse;

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
            currentScene = new SceneManager();
        }

        public void ContentLoad(ContentManager Content)
        {

            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentScene.ContentLoad(Content);
            currentScreen = currentScene.scene;
            oldState = Keyboard.GetState();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState newState = Keyboard.GetState();
            mouse = Mouse.GetState();

            //if (newState.IsKeyDown(Keys.Space))
            //    currentScreen = new GameScreen(Content);
            //else if (newState.IsKeyDown(Keys.A))
            //    currentScreen = new TitleScreen(Content);

            //if (currentScreen.transition == "GameScreen" && currentScreen.scene =="titleScreen")
            //    currentScreen = new GameScreen(Content);

            if (currentScreen.transition != null && currentScreen.transition != "")
            {
                currentScene.Transition(currentScreen.transition);
                currentScreen.transition = null;
            }
            currentScreen = currentScene.scene;
            currentScreen.Update(gameTime);
        }

        public void  Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
            spriteBatch.Draw(spriteManager.Instance.Tblimage[101], new Vector2(mouse.X, mouse.Y), Color.White);

        }

    }
}
