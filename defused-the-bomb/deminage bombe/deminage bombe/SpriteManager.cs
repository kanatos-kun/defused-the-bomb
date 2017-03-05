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
        public Texture2D[] Tblimage = new Texture2D[103];
        public SpriteFont font;
        public ContentManager Content { private set; get; }
        public Texture2D image;
        public Vector2 position;
        public Vector2 size;
        public Vector2 origin;
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
            origin = Vector2.Zero;
            //size = new Vector2(Tblimage[pNumber].Width, Tblimage[pNumber].Height);
        }

        public spriteManager()
        {
            image = null;
            position = Vector2.Zero;
            origin = Vector2.Zero;
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

            //module timer
            Tblimage[24] = Content.Load<Texture2D>("image/module/module_bomb/timer");

            //gameover et win
            Tblimage[25] = Content.Load<Texture2D>("image/game_over");
            Tblimage[26] = Content.Load<Texture2D>("image/win");

            //gui button active
            Tblimage[27] = Content.Load<Texture2D>("image/GUI/new_game_active");
            Tblimage[28] = Content.Load<Texture2D>("image/GUI/quit_active");

            //gui button hover
            Tblimage[29] = Content.Load<Texture2D>("image/GUI/new_game_hover");
            Tblimage[30] = Content.Load<Texture2D>("image/GUI/quit_hover");

            //vie
            Tblimage[31] = Content.Load<Texture2D>("image/life");
            Tblimage[32] = Content.Load<Texture2D>("image/life_out");
            Tblimage[33] = Content.Load<Texture2D>("image/module/module_end");
            Tblimage[34] = Content.Load<Texture2D>("image/module/module_end_reussi");

            // module nombre
            Tblimage[35] = Content.Load<Texture2D>("image/module/module_nombre/00_active");
            Tblimage[36] = Content.Load<Texture2D>("image/module/module_nombre/00_inactive");
            Tblimage[37] = Content.Load<Texture2D>("image/module/module_nombre/00_hover");

            Tblimage[38] = Content.Load<Texture2D>("image/module/module_nombre/01_active");
            Tblimage[39] = Content.Load<Texture2D>("image/module/module_nombre/01_inactive");
            Tblimage[40] = Content.Load<Texture2D>("image/module/module_nombre/01_hover");

            Tblimage[41] = Content.Load<Texture2D>("image/module/module_nombre/02_active");
            Tblimage[42] = Content.Load<Texture2D>("image/module/module_nombre/02_inactive");
            Tblimage[43] = Content.Load<Texture2D>("image/module/module_nombre/02_hover");

            Tblimage[44] = Content.Load<Texture2D>("image/module/module_nombre/03_active");
            Tblimage[45] = Content.Load<Texture2D>("image/module/module_nombre/03_inactive");
            Tblimage[46] = Content.Load<Texture2D>("image/module/module_nombre/03_hover");

            Tblimage[47] = Content.Load<Texture2D>("image/module/module_nombre/04_active");
            Tblimage[48] = Content.Load<Texture2D>("image/module/module_nombre/04_inactive");
            Tblimage[49] = Content.Load<Texture2D>("image/module/module_nombre/04_hover");

            Tblimage[50] = Content.Load<Texture2D>("image/module/module_nombre/05_active");
            Tblimage[51] = Content.Load<Texture2D>("image/module/module_nombre/05_inactive");
            Tblimage[52] = Content.Load<Texture2D>("image/module/module_nombre/05_hover");

            Tblimage[53] = Content.Load<Texture2D>("image/module/module_nombre/06_active");
            Tblimage[54] = Content.Load<Texture2D>("image/module/module_nombre/06_inactive");
            Tblimage[55] = Content.Load<Texture2D>("image/module/module_nombre/06_hover");

            Tblimage[56] = Content.Load<Texture2D>("image/module/module_nombre/07_active");
            Tblimage[57] = Content.Load<Texture2D>("image/module/module_nombre/07_inactive");
            Tblimage[58] = Content.Load<Texture2D>("image/module/module_nombre/07_hover");

            Tblimage[59] = Content.Load<Texture2D>("image/module/module_nombre/08_active");
            Tblimage[60] = Content.Load<Texture2D>("image/module/module_nombre/08_inactive");
            Tblimage[61] = Content.Load<Texture2D>("image/module/module_nombre/08_hover");

            Tblimage[62] = Content.Load<Texture2D>("image/module/module_nombre/09_active");
            Tblimage[63] = Content.Load<Texture2D>("image/module/module_nombre/09_inactive");
            Tblimage[64] = Content.Load<Texture2D>("image/module/module_nombre/09_hover");

            //module forme
            Tblimage[65] = Content.Load<Texture2D>("image/module/module_forme/element_blue_diamond");
            Tblimage[66] = Content.Load<Texture2D>("image/module/module_forme/element_green_square");
            Tblimage[67] = Content.Load<Texture2D>("image/module/module_forme/element_purple_cube_glossy");
            Tblimage[68] = Content.Load<Texture2D>("image/module/module_forme/element_purple_diamond");
            Tblimage[69] = Content.Load<Texture2D>("image/module/module_forme/element_red_square");
            Tblimage[70] = Content.Load<Texture2D>("image/module/module_forme/element_yellow_diamond");

            //module animaux
            Tblimage[71] = Content.Load<Texture2D>("image/module/module_animaux/cochon_active");
            Tblimage[72] = Content.Load<Texture2D>("image/module/module_animaux/cochon_inactive");
            Tblimage[73] = Content.Load<Texture2D>("image/module/module_animaux/cochon_hover");

            Tblimage[74] = Content.Load<Texture2D>("image/module/module_animaux/lapin_active");
            Tblimage[75] = Content.Load<Texture2D>("image/module/module_animaux/lapin_inactive");
            Tblimage[76] = Content.Load<Texture2D>("image/module/module_animaux/lapin_hover");

            Tblimage[77] = Content.Load<Texture2D>("image/module/module_animaux/vache_active");
            Tblimage[78] = Content.Load<Texture2D>("image/module/module_animaux/vache_inactive");
            Tblimage[79] = Content.Load<Texture2D>("image/module/module_animaux/vache_hover");

            Tblimage[80] = Content.Load<Texture2D>("image/module/module_animaux/lion_active");
            Tblimage[81] = Content.Load<Texture2D>("image/module/module_animaux/lion_inactive");
            Tblimage[82] = Content.Load<Texture2D>("image/module/module_animaux/lion_hover");

            Tblimage[83] = Content.Load<Texture2D>("image/module/module_animaux/rinoceros_active");
            Tblimage[84] = Content.Load<Texture2D>("image/module/module_animaux/rinoceros_inactive");
            Tblimage[85] = Content.Load<Texture2D>("image/module/module_animaux/rinoceros_hover");

            Tblimage[86] = Content.Load<Texture2D>("image/module/module_animaux/singe_active");
            Tblimage[87] = Content.Load<Texture2D>("image/module/module_animaux/singe_inactive");
            Tblimage[88] = Content.Load<Texture2D>("image/module/module_animaux/singe_hover");

            Tblimage[89] = Content.Load<Texture2D>("image/module/module_wire/wire_black_hover");
            Tblimage[90] = Content.Load<Texture2D>("image/module/module_wire/wire_white_hover");
            Tblimage[91] = Content.Load<Texture2D>("image/module/module_wire/wire_green_hover");
            Tblimage[92] = Content.Load<Texture2D>("image/module/module_wire/wire_yellow_hover");
            Tblimage[93] = Content.Load<Texture2D>("image/module/module_wire/wire_red_hover");
            Tblimage[94] = Content.Load<Texture2D>("image/module/module_wire/wire_blue_hover");

            Tblimage[95] = Content.Load<Texture2D>("image/module/module_forme/element_blue_diamond_hover");
            Tblimage[96] = Content.Load<Texture2D>("image/module/module_forme/element_green_square_hover");
            Tblimage[97] = Content.Load<Texture2D>("image/module/module_forme/element_purple_cube_glossy_hover");
            Tblimage[98] = Content.Load<Texture2D>("image/module/module_forme/element_purple_diamond_hover");
            Tblimage[99] = Content.Load<Texture2D>("image/module/module_forme/element_red_square_hover");
            Tblimage[100] = Content.Load<Texture2D>("image/module/module_forme/element_yellow_diamond_hover");

            Tblimage[101] = Content.Load<Texture2D>("image/mouse");
            Tblimage[102] = Content.Load<Texture2D>("image/double-left-arrows-angles_hover");

        }

        public void unloadContent()
        {

        }
        
    }
}
