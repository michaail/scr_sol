using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace One
{
    class Obiekt : Agent
    {
        List<string> los = new List<string>();
        IRunnable oUklad;

        public double a0, a1, a2, b1, b2;
        public double Tp { get; set; }
        public double y { get; set; }

        public double u, u1, u2, y1, y2;

        public Uklad uklad = new Uklad(25);

        public Obiekt(double tp, IRunnable runnable)
        {
            this.Tp = tp;
            oUklad = runnable;

        }

        public override void Initializes()
        {
            
            double Tp2 = Math.Pow(Tp, 2);

            a0 = (Tp2) / (4 + 4 * Tp + 3 * (Tp2));
            a1 = (2 * (Tp2)) / (4 + 4 * Tp + 3 * (Tp2));
            a2 = a0;

            b1 = (6 * (Tp2) - 8) / (4 + 4 * Tp + 3 * (Tp2));
            b2 = (4 - 4 * Tp + 3 * (Tp2)) / (4 + 4 * Tp + 3 * (Tp2));

            Console.WriteLine("Koniec Procedury inicjalizacji ukladu {0}", Tp);
            Console.WriteLine("a0 = {0}; a1 = {1}; a2 = {2}; b1 = {3}; b2 = {4}", a0, a1, a2, b1, b2);

            //wystawienie flagi o zakończonym procesie
            Init();
        }

        public override void Update()
        {
            

            Timer oTimer = new Timer();
            oTimer.Elapsed += new ElapsedEventHandler(OnTimeEvent);
            oTimer.Interval = Tp;
            oTimer.Enabled = true;

            
            //Console.WriteLine("Wykonanie obiektu");
            
        }
        private void OnTimeEvent(object oSource, ElapsedEventArgs oElapsedEventsArgs)
        {
            Console.WriteLine("witeczka z tp {0}", Tp);



            y = a0 * u + a1 * u1 + a2 * u2 - b1 * y1 - b2 * y2;
            y2 = y1;
            y1 = y;

            Fin();
        }
    }
}
