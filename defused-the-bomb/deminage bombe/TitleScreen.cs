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
    public class TitleScreen : GameManager
    {
        spriteManager IMGbackground;

        GuiButton GUInewGame;
        GuiButton GUIquit;

        fontManager FONTnewGame;
        fontManager FONThover;
        fontManager FONTclick;
        fontManager FONTclickRelease;

        MouseState mouse;



        public override void ContentLoad(ContentManager Content)
        {
            //***************************************************************
            //  [CONTENT_MANAGE]   -state,timer-
            //***************************************************************

            scene = "titleScreen";

            //***************************************************************
            //  [CONTENT_MANAGE]        -image-
            //***************************************************************

            IMGbackground = new spriteManager(8, Vector2.Zero, Content);

            //***************************************************************
            //  [CONTENT_MANAGE]        -gui-
            //***************************************************************

            GUInewGame = new GuiButton(22, new Vector2(277, 353), Content);
            GUInewGame.timer.elapsed = 500;
            GUIquit = new GuiButton(23, new Vector2(277, 492), Content);

            //***************************************************************
            //  [CONTENT_MANAGE]       -font-
            //***************************************************************

            FONTnewGame = new fontManager(0,
                                            "position mouseX : "         + mouse.X+
                                            " \n" + "position mouseY : " + mouse.Y+
                                            "",Vector2.Zero, Content);
            FONThover = new fontManager(0, "Hover : " + GUInewGame.hover(), new Vector2(0, 45), Content);
            FONTclick = new fontManager(0, "Click : " + GUInewGame.click(), new Vector2(0, 65), Content);
            FONTclickRelease = new fontManager(0, "ClickRelease : " + GUInewGame.clickRelease(), new Vector2(0, 85), Content);

            base.ContentLoad(Content);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public TitleScreen(ContentManager Content)
        {
            ContentLoad(Content);
        }

        public TitleScreen()
        {

        }

        public override void Update(GameTime gameTime)
        {
            //***************************************************************
            //  [UPDATE_MANAGE]    -mouse-
            //***************************************************************

            mouse = Mouse.GetState();

            //***************************************************************
            //  [UPDATE_MANAGE]    -font-
            //***************************************************************

            FONTnewGame.texte = ("position mouseX : " + mouse.X + " \n" + "position mouseY : " + mouse.Y + "");
            FONThover.texte = ("Hover : " + GUInewGame.hover());
            FONTclick.texte = ("Click : " + GUInewGame.click());
            FONTclickRelease.texte = ("ClickRelease : " + GUInewGame.clickRelease());

            //***************************************************************
            //  [UPDATE_MANAGE]    -gui-
            //***************************************************************

            GUInewGame.update(gameTime);
            if (GUInewGame.timer.stop)
                transition = "GameScreen";

            //***************************************************************
            //  [UPDATE_MANAGE]    -time-
            //***************************************************************
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //***************************************************************
            //  [DRAW_MANAGE]     -image-
            //***************************************************************
            spriteBatch.Draw(IMGbackground.image, IMGbackground.position, Color.White);
            //***************************************************************
            //  [DRAW_MANAGE]      -gui-
            //***************************************************************
            spriteBatch.Draw(GUInewGame.image, GUInewGame.position, Color.White);
            spriteBatch.Draw(GUIquit.image, GUIquit.position, Color.White);
            //***************************************************************
            //  [DRAW_MANAGE]      -font-
            //***************************************************************
            //spriteBatch.DrawString(FONTnewGame.font, FONTnewGame.texte, FONTnewGame.position, Color.Black);
            //spriteBatch.DrawString(FONThover.font, FONThover.texte, FONThover.position, Color.Black);
            //spriteBatch.DrawString(FONTclick.font, FONTclick.texte, FONTclick.position, Color.Black);
            //spriteBatch.DrawString(FONTclickRelease.font, FONTclickRelease.texte, FONTclickRelease.position, Color.Black);
            base.Draw(spriteBatch);
        }

    }
}
