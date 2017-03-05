using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deminage_bombe
{
    class fontManager
    {
        private static fontManager instance;
        public ContentManager Content { get; set; }
        public SpriteFont[] TblFont = new SpriteFont[1];
        public SpriteFont font;
        public Vector2 position;
        public string texte;

        public static fontManager Instance
        {
            get
            { 
             if (instance == null)
             instance = new fontManager();
             return instance;
            }
        }

        public fontManager()
        {
            position = Vector2.Zero;
        }

        public fontManager(int pFont,string pText,Vector2 pPosition,ContentManager Content)
        {
            this.LoadContent(Content);
            position = pPosition;
            texte = pText;
            font = TblFont[pFont];
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            TblFont[0] = Content.Load<SpriteFont>("font/arial");
        }

        public void unloadContent()
        {

        }

    }
}
