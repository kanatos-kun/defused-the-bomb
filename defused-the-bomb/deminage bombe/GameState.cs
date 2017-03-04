using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace defused_the_bomb
{
    public class GameState
    {

        private static GameState instance;
        public static GameState Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameState();
                return instance;
            }
        }

        public string lastState { get; private set; }
        public string transition { get; private set; }


        Malette[] TblState= new Malette[6];
        public Malette state { get; private set; }

        public void ContentLoad(ContentManager Content)
        {
            TblState[0] = new MaletteFace();
            TblState[0].ContentLoad(Content);
            TblState[1] = new MaletteDroite();
            TblState[1].ContentLoad(Content);
            TblState[2] = new MaletteArriere();
            TblState[2].ContentLoad(Content);
            TblState[3] = new MaletteGauche();
            TblState[3].ContentLoad(Content);
            TblState[4] = new MaletteDessus();
            TblState[4].ContentLoad(Content);
            TblState[5] = new MaletteDessous();
            TblState[5].ContentLoad(Content);
            state = TblState[0];
        }

        public void UnloadContent()
        {

        }

        public int lifeDrop()
        {
            int lifeCount = 3;
            for (int i=0;i<3;i++)
            {
                if (TblState[0].life[i])
                    lifeCount--;
                if (TblState[1].life[i])
                    lifeCount--;
                if (TblState[2].life[i])
                    lifeCount--;
                if (TblState[3].life[i])
                    lifeCount--;
                if (TblState[4].life[i])
                    lifeCount--;
                if (TblState[5].life[i])
                    lifeCount--;
            }

            return lifeCount;
        }

        public void Update(GameTime gameTime)
        {

            lifeDrop();

            if (state.TransitionState != null)
            {
                transition = state.TransitionState;
                lastState = state.state;
                state.TransitionState = null;
                switch (transition)
                {
                    case "MaletteFace":
                        state = TblState[0];
                        state.lastState = lastState;
                        break;
                    case "MaletteDroite":
                        state = TblState[1];
                        state.lastState = lastState;
                        break;
                    case "MaletteArriere":
                        state = TblState[2];
                        state.lastState = lastState;
                        break;
                    case "MaletteGauche":
                        state = TblState[3];
                        state.lastState = lastState;
                        break;
                    case "MaletteDessus":
                        state = TblState[4];
                        state.lastState = lastState;
                        break;
                    case "MaletteDessous":
                        state = TblState[5];
                        state.lastState = lastState;
                        break;
                }
            Console.WriteLine("Changement de state : " + "\""+state.state + "\"");
            }
            state.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

    }
}
