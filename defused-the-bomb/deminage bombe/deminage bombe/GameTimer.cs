using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace defused_the_bomb
{
    public class GameTimer
    {
        public GameTime time;
        public double elapsed;
        public double msec { get; private set; }
        public double sec { get; private set; }
        public double min { get; private set; }

        public double CountMsec { get; private set; }
        public double CountSec { get; private set; }
        public double CountMin { get; private set; }

        public double totalTime { get; private set; }


        public bool start { get; private set; } = false;
        public bool stop = false;

        public void Start()
        {
            msec = 0;
            sec = 0;
            min = 0;
            stop = false;
            start = true;
        }

        private void Stop()
        {
            msec = 0;
            sec = 0;
            min = 0;
            totalTime = 0;
            stop = true;
            start = false;
            Console.WriteLine("Le timer est terminé!");
        }

        public void Update(GameTime gameTime)
        {
            if (stop)
              stop = false;

            time = gameTime;
            if (start)
            {
                msec += time.ElapsedGameTime.TotalMilliseconds;
                sec += time.ElapsedGameTime.TotalSeconds;
                totalTime += time.ElapsedGameTime.TotalMilliseconds;
                if (msec > 1000)
                    msec = 0;
                if (sec > 60)
                {
                    min += 1;
                    sec = 0;
                }

                CountMsec -= time.ElapsedGameTime.TotalMilliseconds;
                if (CountMsec < 0)
                { 
                    CountMsec = 1000;
                    CountSec--;
                }
                if (CountSec < 0)
                {
                    CountSec = 59;
                    CountMin--;
                }
                if (min > 60)
                min = 0;
            }

            if (totalTime > elapsed && !stop)
                Stop();
        }

        public GameTimer(double pElapsed)
        {
            elapsed = pElapsed;
            CountMsec = pElapsed % (1000);
            CountSec = ((pElapsed/(1000))%60);
            CountMin = ((pElapsed/(1000*60))%60);
        }
    }
}
