using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace One
{
    class Master : Agent
    {
        List<IRunnable> agenci = new List<IRunnable>();

        int ctr = 0;

        List<System.Threading.Thread> threads = new List<System.Threading.Thread>();

        //int wynik = new int();

        public Master(int id, List<IRunnable> runnables)
        {
            agenci = runnables;
            Console.WriteLine("I'm the Master");

        }
        public override void Initializes()
        {
            Init();
        }


        public override void Update()
        {

            Timer oTimer = new Timer();
            oTimer.Elapsed += new ElapsedEventHandler(OnTimeEvent);
            oTimer.Interval = 25;
            Fin();
        }

        private void OnTimeEvent(object oSource, ElapsedEventArgs oElapsedEventsArgs)
        {
            
        }
    }
}
