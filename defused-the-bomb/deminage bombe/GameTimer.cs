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
            stop = true;
            start = false;
            Console.WriteLine("Le timer est terminé!");
        }

        public void Update(GameTime gameTime)
        {
            time = gameTime;
            if (start)
            {
            msec += time.ElapsedGameTime.TotalMilliseconds;
            sec += time.ElapsedGameTime.TotalSeconds;
            min += time.TotalGameTime.Minutes;
            //Console.WriteLine("milliseconde : " + msec + " seconde : " + sec + " minute : " + min);
            }


            if (msec > elapsed && !stop)
                Stop();
        }

        public GameTimer(double pElapsed)
        {
            elapsed = pElapsed;
        }
    }
}
