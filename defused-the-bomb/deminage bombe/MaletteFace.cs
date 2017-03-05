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
        spriteManager IMGmodule1;
        spriteManager[] IMGmoduleLife = new spriteManager[6];

        GuiButton[] GUIwire= new GuiButton[4];
        GuiButton[] GUInumber = new GuiButton[10];
        GuiButton[] GUIforme = new GuiButton[6];
        GuiButton[] GUIanimaux = new GuiButton[6];

        fontManager FONThover;
        fontManager FONTclick;
        fontManager FONTclickRelease;

        GameTimer TIMERwin;

        bool[] BOOLmodule = new bool[4];

        public override void ContentLoad(ContentManager Content)
        {
            base.ContentLoad(Content);
            state = "MaletteFace";

            IMGmodule1 = new spriteManager(9, new Vector2(234, 251), Content);
            IMGmalette = new spriteManager(5, Vector2.Zero, Content);
            IMGmoduleLife[0] = new spriteManager(33, new Vector2(294,235), Content);
            IMGmoduleLife[1] = new spriteManager(33, new Vector2(457,235), Content);
            IMGmoduleLife[2] = new spriteManager(33, new Vector2(614,235), Content);
            IMGmoduleLife[3] = new spriteManager(33, new Vector2(294,491), Content);
            IMGmoduleLife[4] = new spriteManager(33, new Vector2(457,491), Content);
            IMGmoduleLife[5] = new spriteManager(33, new Vector2(614,491), Content);

            for (int i =0; i< IMGmoduleLife.Length;i++)
            {
                spriteManager sprite = IMGmoduleLife[i];
                sprite.position = new Vector2
               (sprite.position.X + (sprite.image.Width / 2), sprite.position.Y + (sprite.image.Height / 2));
            }

            GUIwire[0] = new GuiButton("once",200, 20,93,21, new Vector2(244, 275), Content);
            GUIwire[1] = new GuiButton("once",200, 18,94,19, new Vector2(284, 275), Content);
            GUIwire[2] = new GuiButton("once",200, 16,91,17, new Vector2(324, 275), Content);
            GUIwire[3] = new GuiButton("once",200, 14,92,15, new Vector2(364, 275), Content);

            GUInumber[0] = new GuiButton("once", 200, 36,37,35, new Vector2(593, 260), Content);
            GUInumber[1] = new GuiButton("once", 200, 39,40,38, new Vector2(622, 260), Content);
            GUInumber[2] = new GuiButton("once", 200, 42,43,41, new Vector2(650, 260), Content);
            GUInumber[3] = new GuiButton("once", 200, 45,46,44, new Vector2(593, 286), Content);
            GUInumber[4] = new GuiButton("once", 200, 48,49,47, new Vector2(622, 286), Content);
            GUInumber[5] = new GuiButton("once", 200, 51,52,50, new Vector2(650, 286), Content);
            GUInumber[6] = new GuiButton("once", 200, 54,55,53, new Vector2(593, 313), Content);
            GUInumber[7] = new GuiButton("once", 200, 57,58,56, new Vector2(622, 313), Content);
            GUInumber[8] = new GuiButton("once", 200, 60,61,59, new Vector2(650, 313), Content);
            GUInumber[9] = new GuiButton("once", 200, 63,64,62, new Vector2(622, 340), Content);

            GUIforme[0] = new GuiButton("once", 200, 67,97,67, new Vector2(404, 262), Content);
            GUIforme[1] = new GuiButton("once", 200, 69,99,69, new Vector2(459, 262), Content);
            GUIforme[2] = new GuiButton("once", 200, 66,96,66, new Vector2(510, 262), Content);
            GUIforme[3] = new GuiButton("once", 200, 68,98,68, new Vector2(398, 310), Content);
            GUIforme[4] = new GuiButton("once", 200, 65,95,65, new Vector2(450, 310), Content);
            GUIforme[5] = new GuiButton("once", 200, 70,100,70, new Vector2(501, 310), Content);

            GUIanimaux[0] = new GuiButton("once", 200, 81,82,80, new Vector2(405, 382), Content);
            GUIanimaux[1] = new GuiButton("once", 200, 84,85,83, new Vector2(477, 382), Content);
            GUIanimaux[2] = new GuiButton("once", 200, 87,88,86, new Vector2(405, 417), Content);
            GUIanimaux[3] = new GuiButton("once", 200, 75,76,74, new Vector2(477, 417), Content);
            GUIanimaux[4] = new GuiButton("once", 200, 78,79,77, new Vector2(405, 452), Content);
            GUIanimaux[5] = new GuiButton("once", 200, 72,73,71, new Vector2(477, 452), Content);

            TIMERwin = new GameTimer(500);

            for (int i=0;i < BOOLmodule.Length;i++)
            {
                BOOLmodule[i] = false;
            }

            FONThover = new fontManager(0, "hover : " + GUIarrowRight.hover(), Vector2.Zero, Content);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public void winGame()
        {
            int result = 0;
            for (int i=0;i < BOOLmodule.Length;i++)
            {
                if (BOOLmodule[i] == true)
                    result++;
            }
            if (result == BOOLmodule.Length)
                TIMERwin.Start();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            TIMERwin.Update(gameTime);

            if (TIMERwin.stop)
                TransitionState = "GameWinScreen";

            GUIarrowRight.update(gameTime);
            GUIarrowUp.update(gameTime);
            GUIarrowLeft.update(gameTime);
            GUIarrowDown.update(gameTime);

            FONThover.texte = "hover : " + GUIarrowRight.hover();

            //-----------------------------------------------------------------
            //                          Module wire
            //-----------------------------------------------------------------

            if (!BOOLmodule[0])
            { 
                for (int i=0;i<GUIwire.Length;i++)
                {
                    GUIwire[i].update(gameTime);
                    if (GUIwire[2].timer.stop)
                    { 
                        BOOLmodule[0] = true;
                        GUIwire[2].image = spriteManager.Instance.Tblimage[17];
                        IMGmoduleLife[0].image = spriteManager.Instance.Tblimage[34];
                        winGame();
                    }
                    else if (GUIwire[i].timer.stop)
                        dropLife();
                }
            }

            //-----------------------------------------------------------------
            //                          Module number
            //-----------------------------------------------------------------
            if (!BOOLmodule[1])
            { 
                for (int i = 0; i < GUInumber.Length; i++)
                {
                         GUInumber[i].update(gameTime);
                    if (!GUInumber[6].repeat && !GUInumber[4].repeat)
                    {
                        BOOLmodule[1] = true;
                        GUInumber[6].image = spriteManager.Instance.Tblimage[53];
                        GUInumber[4].image = spriteManager.Instance.Tblimage[47];
                        IMGmoduleLife[2].image = spriteManager.Instance.Tblimage[34];
                        winGame();
                    }
                    else if (GUInumber[i].timer.stop && (i !=6 && i !=4))
                        dropLife();
                }
            }

            //-----------------------------------------------------------------
            //                          Module forme
            //-----------------------------------------------------------------

            if (!BOOLmodule[2])
            { 
                for (int i = 0; i < GUIforme.Length; i++)
                  { 
                        GUIforme[i].update(gameTime);
                    if (GUIforme[3].timer.stop)
                    {
                        BOOLmodule[2] = true;
                        IMGmoduleLife[1].image = spriteManager.Instance.Tblimage[34];
                        winGame();
                    }
                    else if (GUIforme[i].timer.stop)
                        dropLife();
                  }
            }

            //-----------------------------------------------------------------
            //                          Module animaux
            //-----------------------------------------------------------------

            if (!BOOLmodule[3])
            {
                for (int i = 0; i < GUIanimaux.Length; i++)
                {
                    GUIanimaux[i].update(gameTime);
                    if (GUIanimaux[0].timer.stop)
                    {
                        BOOLmodule[3] = true;
                        GUIanimaux[0].image = spriteManager.Instance.Tblimage[80];
                        IMGmoduleLife[4].image = spriteManager.Instance.Tblimage[34];
                        winGame();
                    }
                    else if (GUIanimaux[i].timer.stop)
                        dropLife();
                }
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
            spriteBatch.Draw(IMGmodule1.image, IMGmodule1.position, Color.White);

            for (int i = 0; i < IMGmoduleLife.Length; i++)
            {
                spriteManager sprite = IMGmoduleLife[i];

                if (i < 3)
                {
                    spriteBatch.Draw(sprite.image, sprite.position, null, Color.White, 0, new Vector2(sprite.image.Width / 2, sprite.image.Height / 2), 1, SpriteEffects.None, 0);
                }

                if (i > 2)
                {
                    spriteBatch.Draw(sprite.image, sprite.position, null, Color.White, 0, new Vector2(sprite.image.Width / 2, sprite.image.Height / 2), 1, SpriteEffects.FlipVertically, 0);
                }
            }

            for (int i=0;i < GUIwire.Length;i++)
            spriteBatch.Draw(GUIwire[i].image, GUIwire[i].position, Color.White);

            for (int i=0;i < GUInumber.Length;i++)
                spriteBatch.Draw(GUInumber[i].image, GUInumber[i].position, Color.White);

            for (int i = 0; i < GUIforme.Length; i++)
                spriteBatch.Draw(GUIforme[i].image, GUIforme[i].position, Color.White);

            for (int i = 0; i < GUIanimaux.Length; i++)
                spriteBatch.Draw(GUIanimaux[i].image, GUIanimaux[i].position, Color.White);
            //spriteBatch.DrawString(FONThover.font, FONThover.texte, FONThover.position, Color.Black);
        }
    }
}
