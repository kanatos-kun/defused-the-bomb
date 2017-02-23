using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace defused_the_bomb
{
    public class GuiButton : spriteManager
    {
        MouseState mouse;

        private bool oldMousePressed;
        private bool newMousePressed;

        public GameTimer timer = new GameTimer(2000);

        public GuiButton(int pNumber, Vector2 pPosition, ContentManager Content)
        {
            this.LoadContent(Content);
            image = Tblimage[pNumber];
            position = pPosition;
            size = new Vector2(Tblimage[pNumber].Width, Tblimage[pNumber].Height);
        }


        public bool hover()
        {
            bool hover = false;
            bool hover_x = false;
            bool hover_y = false;
            mouse = Mouse.GetState();
            if (mouse.X > position.X && mouse.X < position.X + image.Width)
                hover_x = true;
            if (mouse.Y > position.Y && mouse.Y < position.Y + image.Height)
                hover_y = true;
            if (hover_x && hover_y) hover = true;
            return hover;
        }

        public bool clickRelease()
        {
            bool release = false;
            if (oldMousePressed)
            {
                release = true;
                timer.Start();

                oldMousePressed = false;
                newMousePressed = false;
            }
            return release;
        }

        public void update(GameTime gameTime)
        {
            hover();
            click();
            clickRelease();
            timer.Update(gameTime);
        }

        public bool click()
        {
            bool click = false;
            mouse = Mouse.GetState();

            if (!timer.start)
            { 
                if (ButtonState.Pressed == mouse.LeftButton && hover())
                {
                    click = true;
                    newMousePressed = true;
                }
                else if (ButtonState.Released == mouse.LeftButton && hover() && newMousePressed)
                {
                    oldMousePressed = true;
                }
            }

            return click;
        }

    }
}
