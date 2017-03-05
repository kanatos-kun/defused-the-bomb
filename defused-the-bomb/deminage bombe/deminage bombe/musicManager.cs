using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace defused_the_bomb
{
    class musicManager
    {
        private static musicManager instance;
        public ContentManager Content { get; private set; }
        public SoundEffect sons;
        public SoundEffect[] Tblsons = new SoundEffect[2];


        public static musicManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new musicManager();
                return instance;
            }
        }

        public musicManager(SoundEffect pSons,ContentManager Content)
        {
            this.LoadContent(Content);
            sons = pSons;
        }

        public musicManager()
        {
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            Tblsons[0] = Content.Load<SoundEffect>("sons/sfx/DM-CGS-01");
            Tblsons[1] = Content.Load<SoundEffect>("sons/sfx/DM-CGS-04");
        }

        public void unloadContent()
        {

        }

    }
}
