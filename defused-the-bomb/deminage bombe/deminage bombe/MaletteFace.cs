using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace defused_the_bomb
{
    public class MaletteFace : Malette
    {
        spriteManager IMGmoduleWire;

        GuiButton GUIwire01;
        GuiButton GUIwire02;
        GuiButton GUIwire03;
        GuiButton GUIwire04;

        fontManager FONThover;
        fontManager FONTclick;
        fontManager FONTclickRelease;

        public override void ContentLoad(ContentManager Content)
        {
            base.ContentLoad(Content);
            state = "MaletteFace";

            IMGmoduleWire = new spriteManager(9, new Vector2(234, 251), Content);
            IMGmalette = new spriteManager(5, Vector2.Zero, Content);

            GUIwire01 = new GuiButton("once",200, 20, new Vector2(244, 275), Content);
            GUIwire02 = new GuiButton("once",200, 18, new Vector2(284, 275), Content);
            GUIwire03 = new GuiButton("once",200, 16, new Vector2(324, 275), Content);
            GUIwire04 = new GuiButton("once",200, 14, new Vector2(364, 275), Content);

            FONThover = new fontManager(0, "hover : " + GUIarrowRight.hover(), Vector2.Zero, Content);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            GUIwire01.update(gameTime);
            GUIwire02.update(gameTime);
            GUIwire03.update(gameTime);
            GUIwire04.update(gameTime);
            GUIarrowRight.update(gameTime);
            GUIarrowUp.update(gameTime);
            GUIarrowLeft.update(gameTime);
            GUIarrowDown.update(gameTime);

            FONThover.texte = "hover : " + GUIarrowRight.hover();

            //-----------------------------------------------------------------
            //                          Module wire
            //-----------------------------------------------------------------
            if (GUIwire01.timer.stop)
            {
                Console.WriteLine("le fils 1 a été coupé");
                dropLife();
            }
            if (GUIwire02.timer.stop)
            { 
                Console.WriteLine("le fils 2 a été coupé");
                dropLife();
            }
            if (GUIwire03.timer.stop)
            { 
                Console.WriteLine("le fils 3 a été coupé");
                dropLife();
            }
            if (GUIwire04.timer.stop)
            {
                Console.WriteLine("le fils 4 a été coupé");
                dropLife();
            }

            if (GUIwire01.click())
            {
                GUIwire01.image = spriteManager.Instance.Tblimage[21];
            }
            if (GUIwire02.click())
            {
                GUIwire02.image = spriteManager.Instance.Tblimage[19];
            }
            if (GUIwire03.click())
            {
                GUIwire03.image = spriteManager.Instance.Tblimage[17];
            }
            if (GUIwire04.click())
            {
                GUIwire04.image = spriteManager.Instance.Tblimage[15];
            }

            if (GUIarrowRight.timer.stop)
                TransitionState = "MaletteDroite";

            if (GUIarrowLeft.timer.stop)
                TransitionState = "MaletteGauche";

            if (GUIarrowUp.timer.stop)
            {
                if (TransitionState == "MaletteDessous")
                    TransitionState = "MaletteDessus";
                if (TransitionState == "MaletteDessus")
                    TransitionState = "MaletteDessus";
                else
                    TransitionState = "MaletteDessus";
            }

            if (GUIarrowDown.timer.stop)
            {
                if (TransitionState == "MaletteDessous")
                    TransitionState = "MaletteDessous";
                if (TransitionState == "MaletteDessus")
                    TransitionState = "MaletteDessous";
                else
                    TransitionState = "MaletteDessous";
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Draw(IMGmalette.image, IMGmalette.position, Color.White);
            spriteBatch.Draw(IMGmoduleWire.image, IMGmoduleWire.position, Color.White);

            spriteBatch.Draw(GUIwire01.image, GUIwire01.position, Color.White);
            spriteBatch.Draw(GUIwire02.image, GUIwire02.position, Color.White);
            spriteBatch.Draw(GUIwire03.image, GUIwire03.position, Color.White);
            spriteBatch.Draw(GUIwire04.image, GUIwire04.position, Color.White);

            //spriteBatch.DrawString(FONThover.font, FONThover.texte, FONThover.position, Color.Black);
        }
    }
}
