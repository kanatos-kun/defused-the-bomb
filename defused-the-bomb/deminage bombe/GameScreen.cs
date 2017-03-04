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

    public class GameScreen : GameManager
    {

        spriteManager IMGbackground;
        spriteManager IMGtimer;
        spriteManager[] IMGcompteurLife = new spriteManager[3];

        GameTimer COUNTERbomb;
        GameTimer COUNTERgameOver;

        fontManager STRINGtimer;

        public string selection;

        public override void ContentLoad(ContentManager Content)
        {
            scene = "gameScreen";

            GameState.Instance.ContentLoad(Content);

            IMGbackground = new spriteManager(0, Vector2.Zero, Content);
            IMGtimer = new spriteManager(24, new Vector2(397, 23), Content);

            for (int i=0;i < IMGcompteurLife.Length;i++)
            { 
            IMGcompteurLife[i] = new spriteManager(31, new Vector2(441+(i*23), 4), Content);
            }

            COUNTERbomb = new GameTimer(((1000) * 60) * 2);
            COUNTERgameOver = new GameTimer(500);

            STRINGtimer = new fontManager(1,"0" + COUNTERbomb.CountMin + ":" + "0" + COUNTERbomb.CountSec,new Vector2(433, 23), Content);

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
            COUNTERgameOver.Update(gameTime);

            if (COUNTERbomb.CountMin > 9 && COUNTERbomb.CountSec > 9)
                STRINGtimer.texte = (int)COUNTERbomb.CountMin + ":" + (int)COUNTERbomb.CountSec;
            else if (COUNTERbomb.CountMin > 9)
                STRINGtimer.texte = (int)COUNTERbomb.CountMin + ":" + "0" + (int)COUNTERbomb.CountSec;
            else if (COUNTERbomb.CountSec > 9)
                STRINGtimer.texte = "0" + (int)COUNTERbomb.CountMin + ":" + (int)COUNTERbomb.CountSec;
            else
                STRINGtimer.texte = "0" + (int)COUNTERbomb.CountMin + ":" + "0" + (int)COUNTERbomb.CountSec;

            GameState.Instance.Update(gameTime);

            if (COUNTERbomb.stop)
                COUNTERgameOver.Start();

            if (COUNTERgameOver.stop)
                transition = "GameOverScreen";

            if (GameState.Instance.lifeDrop() == 0)
            { 
                IMGcompteurLife[0].image = spriteManager.Instance.Tblimage[32];
                IMGcompteurLife[1].image = spriteManager.Instance.Tblimage[32];
                IMGcompteurLife[2].image = spriteManager.Instance.Tblimage[32];
                COUNTERgameOver.Start();
            }
            else if (GameState.Instance.lifeDrop() == 1)
            { 
               IMGcompteurLife[0].image = spriteManager.Instance.Tblimage[32];
               IMGcompteurLife[1].image = spriteManager.Instance.Tblimage[32];
               IMGcompteurLife[2].image = spriteManager.Instance.Tblimage[31];
            }
            else if (GameState.Instance.lifeDrop() == 2)
            { 
               IMGcompteurLife[0].image = spriteManager.Instance.Tblimage[32];
               IMGcompteurLife[1].image = spriteManager.Instance.Tblimage[31];
               IMGcompteurLife[2].image = spriteManager.Instance.Tblimage[31];
            }

            if (GameState.Instance.transition == "GameWinScreen")
                transition = "GameWinScreen";

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(IMGbackground.image, IMGbackground.position, Color.White);
            spriteBatch.Draw(IMGtimer.image, IMGtimer.position, Color.White);
            for (int i = 0; i < IMGcompteurLife.Length; i++)
            {
                spriteBatch.Draw(IMGcompteurLife[i].image, IMGcompteurLife[i].position, Color.White);
            }

            spriteBatch.DrawString(STRINGtimer.font, STRINGtimer.texte, STRINGtimer.position, new Color(251, 215, 170));

            GameState.Instance.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }

    }
}
