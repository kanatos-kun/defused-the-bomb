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
    public class MaletteDessus : Malette
    {

        public override void ContentLoad(ContentManager Content)
        {
            base.ContentLoad(Content);
            state = "MaletteDessus";

            IMGmalette = new spriteManager(3, Vector2.Zero, Content);

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
            { 
            if (lastState == "MaletteFace")
                TransitionState = "MaletteDroite";
            if (lastState == "MaletteDroite")
                TransitionState = "MaletteArriere";
            if (lastState == "MaletteArriere")
                TransitionState = "MaletteGauche";
            if (lastState == "MaletteGauche")
                TransitionState = "MaletteFace";
            }

            if (GUIarrowLeft.timer.stop)
            { 
            if (lastState == "MaletteFace")
                TransitionState = "MaletteGauche";
            if (lastState == "MaletteDroite")
                TransitionState = "MaletteFace";
            if (lastState == "MaletteArriere")
                TransitionState = "MaletteDroite";
            if (lastState == "MaletteGauche")
                TransitionState = "MaletteArriere";
            }

            if (GUIarrowUp.timer.stop)
            { 
            if (lastState == "MaletteFace")
                TransitionState = "MaletteArriere";
            if (lastState == "MaletteDroite")
                TransitionState = "MaletteGauche";
            if (lastState == "MaletteArriere")
                TransitionState = "MaletteFace";
            if (lastState == "MaletteGauche")
                TransitionState = "MaletteDroite";
            }

            if (GUIarrowDown.timer.stop)
            { 
            if (lastState == "MaletteFace")
                TransitionState = "MaletteFace";
            if (lastState == "MaletteDroite")
                TransitionState = "MaletteDroite";
            if (lastState == "MaletteArriere")
                TransitionState = "MaletteArriere";
            if (lastState == "MaletteGauche")
                TransitionState = "MaletteGauche";
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            
            spriteBatch.Draw(IMGmalette.image, IMGmalette.position, Color.White);
        }
    }
}
