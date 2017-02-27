using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace defused_the_bomb
{
    public class spriteManager
    {
        public Texture2D[] Tblimage = new Texture2D[31];
        public SpriteFont font;
        public ContentManager Content { private set; get; }
        public Texture2D image;
        public Vector2 position;
        public Vector2 size;
        private static spriteManager instance;

        public static spriteManager Instance
        {
            get
            {
                if (instance == null)
                instance = new spriteManager();
                return instance;
            }
        }

        public spriteManager(int pNumber,Vector2 pPosition,ContentManager Content)
        {
            this.LoadContent(Content);
            image = Tblimage[pNumber];
            position = pPosition;
            //size = new Vector2(Tblimage[pNumber].Width, Tblimage[pNumber].Height);
        }

        public spriteManager()
        {
            image = null;
            position = Vector2.Zero;
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            Tblimage[0] = Content.Load<Texture2D>("image/background");
            Tblimage[1] = Content.Load<Texture2D>("image/bomb_arriere");
            Tblimage[2] = Content.Load<Texture2D>("image/bomb_dessous");
            Tblimage[3] = Content.Load<Texture2D>("image/bomb_dessus");
            Tblimage[4] = Content.Load<Texture2D>("image/bomb_droite");
            Tblimage[5] = Content.Load<Texture2D>("image/bomb_face");
            Tblimage[6] = Content.Load<Texture2D>("image/bomb_gauche");
            Tblimage[7] = Content.Load<Texture2D>("image/double-left-arrows-angles");
            Tblimage[8] = Content.Load<Texture2D>("image/title");

            //module_wire
            Tblimage[9] = Content.Load<Texture2D>("image/module/module_wire/module");
            Tblimage[10] = Content.Load<Texture2D>("image/module/module_wire/wire_black");
            Tblimage[11] = Content.Load<Texture2D>("image/module/module_wire/wire_black_cut");
            Tblimage[12] = Content.Load<Texture2D>("image/module/module_wire/wire_white");
            Tblimage[13] = Content.Load<Texture2D>("image/module/module_wire/wire_white_cut");
            Tblimage[14] = Content.Load<Texture2D>("image/module/module_wire/wire_yellow");
            Tblimage[15] = Content.Load<Texture2D>("image/module/module_wire/wire_yellow_cut");
            Tblimage[16] = Content.Load<Texture2D>("image/module/module_wire/wire_green");
            Tblimage[17] = Content.Load<Texture2D>("image/module/module_wire/wire_green_cut");
            Tblimage[18] = Content.Load<Texture2D>("image/module/module_wire/wire_blue");
            Tblimage[19] = Content.Load<Texture2D>("image/module/module_wire/wire_blue_cut");
            Tblimage[20] = Content.Load<Texture2D>("image/module/module_wire/wire_red");
            Tblimage[21] = Content.Load<Texture2D>("image/module/module_wire/wire_red_cut");

            //gui button inactive
            Tblimage[22] = Content.Load<Texture2D>("image/GUI/new_game_inactive");
            Tblimage[23] = Content.Load<Texture2D>("image/GUI/quit_inactive");

            //module bomb
            Tblimage[24] = Content.Load<Texture2D>("image/module/module_bomb/module_bomb");

            //gameover et win
            Tblimage[25] = Content.Load<Texture2D>("image/game_over");
            Tblimage[26] = Content.Load<Texture2D>("image/win");

            //gui button active
            Tblimage[27] = Content.Load<Texture2D>("image/GUI/new_game_active");
            Tblimage[28] = Content.Load<Texture2D>("image/GUI/quit_active");

            //gui button hover
            Tblimage[29] = Content.Load<Texture2D>("image/GUI/new_game_hover");
            Tblimage[30] = Content.Load<Texture2D>("image/GUI/quit_hover");

        }

        public void unloadContent()
        {

        }
        
    }
}
