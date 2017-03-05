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

        fontManager FONTquit;
        fontManager FONThover;
        fontManager FONTclick;
        fontManager FONTclickRelease;

        MouseState mouse;



        public override void ContentLoad(ContentManager Content)
        {
            scene = "titleScreen";

            IMGbackground = new spriteManager(8, Vector2.Zero, Content);

            GUInewGame = new GuiButton("repeat",100,22,29,27, new Vector2(230, 353), Content);
            GUIquit = new GuiButton("repeat", 100, 23,30,28, new Vector2(230, 492), Content);

            FONTquit = new fontManager(0,
                                            "position mouseX : "         + mouse.X+
                                            " \n" + "position mouseY : " + mouse.Y+
                                            "",Vector2.Zero, Content);
            FONThover = new fontManager(0, "Hover : " + GUIquit.hover(), new Vector2(0, 45), Content);
            FONTclick = new fontManager(0, "Click : " + GUIquit.click(), new Vector2(0, 65), Content);
            FONTclickRelease = new fontManager(0, "ClickRelease : " + GUIquit.clickRelease(), new Vector2(0, 85), Content);

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
            GUIquit.update(gameTime);
            GUInewGame.update(gameTime);

            mouse = Mouse.GetState();

            FONTquit.texte = ("position mouseX : " + mouse.X + " \n" + "position mouseY : " + mouse.Y + "");
            FONThover.texte = ("Hover : " + GUIquit.hover());
            FONTclick.texte = ("Click : " + GUIquit.click());
            FONTclickRelease.texte = ("ClickRelease : " + GUIquit.clickRelease());

            if (GUInewGame.timer.stop)
                transition = "gameScreen";

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(IMGbackground.image, IMGbackground.position, Color.White);

            spriteBatch.Draw(GUInewGame.image, GUInewGame.position, Color.White);
            spriteBatch.Draw(GUIquit.image, GUIquit.position, Color.White);

            //spriteBatch.DrawString(FONTquit.font, FONTquit.texte, FONTquit.position, Color.Black);
            //spriteBatch.DrawString(FONThover.font, FONThover.texte, FONThover.position, Color.Black);
            //spriteBatch.DrawString(FONTclick.font, FONTclick.texte, FONTclick.position, Color.Black);
            //spriteBatch.DrawString(FONTclickRelease.font, FONTclickRelease.texte, FONTclickRelease.position, Color.Black);
            base.Draw(spriteBatch);
        }

    }
}
