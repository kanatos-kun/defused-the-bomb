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

    class GameScreen : GameManager
    {
        GameTimer COUNTERbomb;

        spriteManager IMGbackground;
        spriteManager IMGmoduleWire;
        spriteManager IMGmoduleBomb;
        spriteManager IMGmalette;

        fontManager STRINGtimer;

        GuiButton GUIwire01;
        GuiButton GUIwire02;
        GuiButton GUIwire03;
        GuiButton GUIwire04;

        GuiButton GUIarrowRight;
        GuiButton GUIarrowLeft;
        GuiButton GUIarrowUp;
        GuiButton GUIarrowDown;


        public override void ContentLoad(ContentManager Content)
        {
            scene = "gameScreen";

            COUNTERbomb = new GameTimer(((1000) * 60) * 5);

            IMGbackground = new spriteManager(0,Vector2.Zero,Content);
            IMGmoduleWire = new spriteManager(9, new Vector2(234, 251), Content);
            IMGmoduleBomb = new spriteManager(24, new Vector2(394,251), Content);
            IMGmalette = new spriteManager(5,Vector2.Zero, Content);


            STRINGtimer = new fontManager(1,
            "0"+COUNTERbomb.CountMin+":"+"0"+COUNTERbomb.CountSec,
            new Vector2(437,276),Content);

            GUIwire01 = new GuiButton(20, new Vector2(244, 275), Content);
            GUIwire02 = new GuiButton(18, new Vector2(284, 275), Content);
            GUIwire03 = new GuiButton(16, new Vector2(324, 275), Content);
            GUIwire04 = new GuiButton(14, new Vector2(364, 275), Content);
            GUIarrowRight = new GuiButton(7, new Vector2(792,334), Content);
            GUIarrowRight.position += new Vector2(GUIarrowRight.image.Width / 2, GUIarrowRight.image.Height / 2);
            GUIarrowLeft = new GuiButton(7, new Vector2(116, 334), Content);
            GUIarrowLeft.position += new Vector2(GUIarrowLeft.image.Width / 2, GUIarrowLeft.image.Height / 2);
            GUIarrowUp = new GuiButton(7, new Vector2(438, 139), Content);
            GUIarrowUp.position += new Vector2(GUIarrowUp.image.Height / 2, GUIarrowUp.image.Width / 2);
            GUIarrowDown = new GuiButton(7, new Vector2(438, 556), Content);
            GUIarrowDown.position += new Vector2(GUIarrowDown.image.Height / 2, GUIarrowDown.image.Width / 2);

            COUNTERbomb.Start();
            base.ContentLoad(Content);
        }

        public GameScreen(ContentManager Content)
        {
            ContentLoad(Content);
        }

        public GameScreen()
        {

        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {

            COUNTERbomb.Update(gameTime);

            if (COUNTERbomb.CountMin>9 && COUNTERbomb.CountSec > 9)
                STRINGtimer.texte = (int)COUNTERbomb.CountMin + ":" + (int)COUNTERbomb.CountSec;
            else if (COUNTERbomb.CountMin>9)
                STRINGtimer.texte = (int)COUNTERbomb.CountMin + ":" + "0" + (int)COUNTERbomb.CountSec;
            else if (COUNTERbomb.CountSec > 9)
                STRINGtimer.texte = "0" + (int)COUNTERbomb.CountMin + ":" + (int)COUNTERbomb.CountSec;
            else
                STRINGtimer.texte = "0" + (int)COUNTERbomb.CountMin + ":" + "0" + (int)COUNTERbomb.CountSec;

            //Module wire
            //-----------------------------------------------------------------
            GUIwire01.update(gameTime);
            GUIwire02.update(gameTime);
            GUIwire03.update(gameTime);
            GUIwire04.update(gameTime);


            if (GUIwire02.timer.stop)
                transition = "GameOverScreen";
            if (GUIwire03.timer.stop)
                transition = "GameWinScreen";


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
            //-----------------------------------------------------------------

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(IMGbackground.image,IMGbackground.position,Color.White);

            spriteBatch.Draw(IMGmalette.image, IMGmalette.position, Color.White);
            spriteBatch.Draw(IMGmoduleWire.image, IMGmoduleWire.position, Color.White);
            spriteBatch.Draw(IMGmoduleBomb.image, IMGmoduleBomb.position, Color.White);

            spriteBatch.Draw(GUIwire01.image, GUIwire01.position, Color.White);
            spriteBatch.Draw(GUIwire02.image, GUIwire02.position, Color.White);
            spriteBatch.Draw(GUIwire03.image, GUIwire03.position, Color.White);
            spriteBatch.Draw(GUIwire04.image, GUIwire04.position, Color.White);
            spriteBatch.Draw(GUIarrowLeft.image, GUIarrowLeft.position,null,Color.White,0,new Vector2(GUIarrowLeft.image.Width/2,GUIarrowLeft.image.Height/2),
                1,SpriteEffects.None,0);
            spriteBatch.Draw(GUIarrowRight.image, GUIarrowRight.position, null, Color.White, MathHelper.Pi, new Vector2(GUIarrowRight.image.Width / 2, GUIarrowRight.image.Height / 2), 1, SpriteEffects.None, 0);
            spriteBatch.Draw(GUIarrowUp.image, GUIarrowUp.position, null, Color.White, MathHelper.PiOver2, new Vector2(GUIarrowUp.image.Width / 2, GUIarrowRight.image.Height / 2), 1, SpriteEffects.None, 0);
            spriteBatch.Draw(GUIarrowDown.image, GUIarrowDown.position, null, Color.White, MathHelper.PiOver2*3, new Vector2(GUIarrowDown.image.Width / 2, GUIarrowDown.image.Height / 2), 1, SpriteEffects.None, 0);

            spriteBatch.DrawString(STRINGtimer.font, STRINGtimer.texte, STRINGtimer.position,new Color(46,50,51));

            base.Draw(spriteBatch);
        }

    }
}
