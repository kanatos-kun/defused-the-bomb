using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace defused_the_bomb
{
    public class SceneManager
    {
        public GameManager scene { private set; get; }
        GameManager[] TblScene = new GameManager[9];
        ContentManager Content;

        public void ContentLoad(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            TblScene[0] = new TitleScreen();
            TblScene[0].ContentLoad(Content);
            TblScene[1] = new GameOverScreen();
            TblScene[1].ContentLoad(Content);
            TblScene[2] = new GameWinScreen();
            TblScene[2].ContentLoad(Content);
            TblScene[3] = new GameScreen();
            TblScene[3].ContentLoad(Content);
            scene = TblScene[0];
        }

        public void Transition(string txt)
        {
            switch (txt)
            {
                case "TitleScreen":
                    Console.WriteLine("la scene actuelle est \"TitleScreen\"");
                    scene = TblScene[0];
                    break;
                case "GameOverScreen":
                    Console.WriteLine("la scene actuelle est \"GameOverScreen\"");
                    scene = TblScene[1];
                    break;
                case "GameWinScreen":
                    Console.WriteLine("la scene actuelle est \"GameWinScreen\"");
                    scene = TblScene[2];
                    break;
                case "gameScreen":
                    Console.WriteLine("la scene actuelle est \"gameScreen\"");
                    scene = TblScene[3];
                    break;
                default:
                case "":
                    scene = TblScene[0];
                    break;
            }
        }


    }
}
