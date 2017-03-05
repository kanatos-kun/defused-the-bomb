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
    public class MaletteGauche : Malette
    {
        public override void ContentLoad(ContentManager Content)
        {
            base.ContentLoad(Content);
            state = "MaletteGauche";

            IMGmalette = new spriteManager(6, Vector2.Zero, Content);

        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            GUIarrowRight.update(gameTime);
            GUIarrowUp.update(gameTime);
            GUIarrowLeft.update(gameTime);
            GUIarrowDown.update(gameTime);

            if (GUIarrowRight.timer.stop)
                TransitionState = "MaletteFace";

            if (GUIarrowLeft.timer.stop)
                TransitionState = "MaletteArriere";

            if (GUIarrowUp.timer.stop)
            {
                if (TransitionState == "MaletteDessous")
                    TransitionState = "MaletteDessus";
                if (TransitionState == "MaletteDessus")
                    TransitionState = "MaletteDessus";
                else
                    TransitionState = "MaletteDessus";

            }

            if (GUIarrowDown.timer.stop)
            {
                if (TransitionState == "MaletteDessous")
                    TransitionState = "MaletteDessous";
                if (TransitionState == "MaletteDessus")
                    TransitionState = "MaletteDessous";
                else
                    TransitionState = "MaletteDessous";

            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Draw(IMGmalette.image, IMGmalette.position, Color.White);

        }
    }
}
