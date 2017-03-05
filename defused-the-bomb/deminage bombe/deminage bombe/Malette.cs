using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;

namespace defused_the_bomb
{
    public abstract class Malette
    {
        public string state;
        public string lastState;
        public string TransitionState;
        public bool[] life = new bool[3];

        protected spriteManager IMGmalette;

        protected GuiButton GUIarrowRight;
        protected GuiButton GUIarrowLeft;
        protected GuiButton GUIarrowUp;
        protected GuiButton GUIarrowDown;

        virtual public void ContentLoad(ContentManager Content)
        {
            life[0] = false;
            life[1] = false;
            life[2] = false;

            GUIarrowRight = new GuiButton("repeat", false, 100, 7,102,7, new Vector2(792, 334), Content);
            GUIarrowLeft = new GuiButton("repeat", false, 100, 7,102,7, new Vector2(116, 334), Content);
            GUIarrowUp = new GuiButton("repeat", true, 100, 7,102,7, new Vector2(438, 139), Content);
            GUIarrowDown = new GuiButton("repeat", true, 100, 7,102,7, new Vector2(438, 556), Content);

            GUIarrowRight.origin = new Vector2(GUIarrowRight.image.Width / 2, GUIarrowRight.image.Height / 2);
            GUIarrowLeft.origin = new Vector2(GUIarrowLeft.image.Width / 2, GUIarrowLeft.image.Height / 2);
            GUIarrowUp.origin = new Vector2(GUIarrowUp.image.Width / 2, GUIarrowUp.image.Height / 2);
            GUIarrowDown.origin = new Vector2(GUIarrowDown.image.Width / 2, GUIarrowDown.image.Height / 2);

            GUIarrowRight.position += new Vector2(GUIarrowRight.origin.X, GUIarrowRight.origin.Y);
            GUIarrowLeft.position += new Vector2(GUIarrowLeft.origin.X, GUIarrowLeft.origin.Y);
            GUIarrowUp.position += new Vector2(GUIarrowUp.origin.Y, GUIarrowUp.origin.X);
            GUIarrowDown.position += new Vector2(GUIarrowDown.origin.Y, GUIarrowDown.origin.X);
        }

        virtual public void UnloadContent()
        {

        }

        public void dropLife()
        {
            for (int i = 0; i < life.Length; i++)
            {
                if (!life[i])
                {
                    life[i] = true;
                    break;
                }
            }
        }

        virtual public void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GUIarrowLeft.image, GUIarrowLeft.position, null, Color.White, 0, new Vector2(GUIarrowLeft.origin.X, GUIarrowLeft.origin.Y), 1, SpriteEffects.None, 0);
            spriteBatch.Draw(GUIarrowRight.image, GUIarrowRight.position, null, Color.White, MathHelper.Pi, new Vector2(GUIarrowRight.origin.X, GUIarrowRight.origin.Y), 1, SpriteEffects.None, 0);
            spriteBatch.Draw(GUIarrowUp.image, GUIarrowUp.position, null, Color.White, MathHelper.PiOver2, new Vector2(GUIarrowUp.origin.X, GUIarrowUp.origin.Y), 1, SpriteEffects.None, 0);
            spriteBatch.Draw(GUIarrowDown.image, GUIarrowDown.position, null, Color.White, MathHelper.PiOver2 * 3, new Vector2(GUIarrowDown.origin.X, GUIarrowDown.origin.Y), 1, SpriteEffects.None, 0);
        }

    }

}
