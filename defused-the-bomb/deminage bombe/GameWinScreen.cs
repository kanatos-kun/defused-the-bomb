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
    public class GameWinScreen:GameManager
    {
        spriteManager IMGBackground;
        public override void ContentLoad(ContentManager Content)
        {
            scene = "GameWinScreen";

            IMGBackground = new spriteManager(26,Vector2.Zero,Content);
            base.ContentLoad(Content);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(IMGBackground.image,IMGBackground.position,Color.White);
            base.Draw(spriteBatch);
        }
    }

}
