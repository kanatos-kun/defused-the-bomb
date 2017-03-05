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
        private bool inversed = false;
        public string state;
        public bool repeat { get; private set; } = true;
        protected spriteManager IMGactive = new spriteManager();
        protected spriteManager IMGhover = new spriteManager();
        protected spriteManager IMGinactive = new spriteManager();

        public GameTimer timer = new GameTimer(2000);

        public GuiButton(string pState,int pInactive,int pHover,int pActive, Vector2 pPosition, ContentManager Content)
        {
            this.LoadContent(Content);
            state = pState;
            IMGinactive.image = Tblimage[pInactive];
            IMGactive.image = Tblimage[pActive];
            IMGhover.image = Tblimage[pHover];
            image = Tblimage[pInactive];
            position = pPosition;
            //size = new Vector2(Tblimage[pImage].Width, Tblimage[pImage].Height);
        }

        public GuiButton(string pState,double pElapsedTime, int pInactive, int pHover, int pActive, Vector2 pPosition, ContentManager Content)
        {
            this.LoadContent(Content);
            state = pState;
            timer.elapsed = pElapsedTime;
            IMGinactive.image = Tblimage[pInactive];
            IMGactive.image = Tblimage[pActive];
            IMGhover.image = Tblimage[pHover];
            image = Tblimage[pInactive];
            position = pPosition;
            //size = new Vector2(Tblimage[pImage].Width, Tblimage[pImage].Height);
        }

        public GuiButton(string pState,bool pInversed,double pElapsedTime, int pInactive, int pHover, int pActive, Vector2 pPosition, ContentManager Content)
        {
            this.LoadContent(Content);
            state = pState;
            inversed = pInversed;
            timer.elapsed = pElapsedTime;
            IMGinactive.image = Tblimage[pInactive];
            IMGactive.image = Tblimage[pActive];
            IMGhover.image = Tblimage[pHover];
            image = Tblimage[pInactive];
            position = pPosition;
            //size = new Vector2(Tblimage[pImage].Width, Tblimage[pImage].Height);
        }

        public bool hover()
        {
            bool hover = false;
            bool hover_x = false;
            bool hover_y = false;
            mouse = Mouse.GetState();

           image = IMGinactive.image;

            if (inversed)
            {
                if (mouse.X > position.X - origin.Y && mouse.X < position.X + image.Width - origin.Y)
                    hover_x = true;
                if (mouse.Y > position.Y - origin.X && mouse.Y < position.Y + image.Height - origin.X)
                    hover_y = true;
                if (hover_x && hover_y)
                {
                    image = IMGhover.image;
                    hover = true;
                }
            }
            else
            { 
                if (mouse.X  > position.X - origin.X && mouse.X < position.X + image.Width - origin.X)
                    hover_x = true;
                if (mouse.Y > position.Y - origin.Y && mouse.Y  < position.Y + image.Height - origin.Y)
                    hover_y = true;
                if (hover_x && hover_y)
                {
                    image = IMGhover.image;
                    hover = true;
                }
            }

            if (!repeat)
                image = IMGactive.image;

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
            clickRelease();
            if (!timer.start)
                hover();
            click();

            if (timer.stop && state == "once")
                repeat = false;

            timer.Update(gameTime);
        }

        public bool click()
        {
            bool click = false;
            mouse = Mouse.GetState();

            if (!timer.start && repeat)
            { 
                if (ButtonState.Pressed == mouse.LeftButton && hover())
                {
                    image = IMGactive.image;
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
