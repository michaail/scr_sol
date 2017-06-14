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

        int iter = 0;

        public double a0, a1, a2, b1, b2;
        public double Tp { get; set; }
        public double y { get; set; }

        //private Timer oTimer;

        //public static List<double> eList;

        public double u, u1, u2, y1, y2;
        public double K1, K2, K3, kp, Td, Ti;

        public Uklad uklad = new Uklad(25, eList);

        

        public System.Threading.Mutex mut = new System.Threading.Mutex();

        public Obiekt(double tp)
        {
            this.Tp = tp;

        }

        public override void Initializes()
        {
            
            eList.Add(0.0);
            eList.Add(0.0);
            uList.Add(0.0);
            uList.Add(0.0);
            yList.Add(0.0);
            yList.Add(0.0);

            Td = 0;
            Ti = 1000;
            kp = 1;

            //eList.Add(0.0);
            double Tp2 = Math.Pow(Tp, 2);

            a0 = (Tp2) / (4 + 4 * Tp + 3 * (Tp2));
            a1 = (2 * (Tp2)) / (4 + 4 * Tp + 3 * (Tp2));
            a2 = a0;

            b1 = (6 * (Tp2) - 8) / (4 + 4 * Tp + 3 * (Tp2));
            b2 = (4 - 4 * Tp + 3 * (Tp2)) / (4 + 4 * Tp + 3 * (Tp2));

            K1 = kp * (1 + (Tp / Ti) + (Td / Tp));
            K2 = -1 * kp * (1 + 2 * (Td / Tp));
            K3 = kp * (Td / Tp);

            Console.WriteLine("Koniec Procedury inicjalizacji ukladu {0}", Tp);
            Console.WriteLine("a0 = {0}; a1 = {1}; a2 = {2}; b1 = {3}; b2 = {4}", a0, a1, a2, b1, b2);

            for (int i = 0; i < eList.Count(); i++)
            {
                Console.WriteLine(eList[i]);
            }

            //wystawienie flagi o zakończonym procesie
            Init();
        }

        public override void Update()
        {


            Timer oTimer = new Timer();
            oTimer.Elapsed += new ElapsedEventHandler(OnTimeEvent);
            oTimer.Interval = Tp;
            oTimer.Enabled = true;

            //Fin();
            //Console.WriteLine("Wykonanie obiektu");
            
        }
        private void OnTimeEvent(object oSource, ElapsedEventArgs oElapsedEventsArgs)
        {
            iter++;
            
            

            Fin();
            var thread = new System.Threading.Thread(uklad.Run);
            //Console.WriteLine("witeczka z tp {0}", Tp);
            uklad.A = 1;

            mut.WaitOne();
            y1 = yList[yList.Count() - 1];
            y2 = yList[yList.Count() - 2];

            u1 = uList[uList.Count() - 1];
            u2 = uList[uList.Count() - 2];
            
            uklad.K1 = K1;
            uklad.K2 = K2;
            uklad.K3 = K3;

            uklad.u1 = u1;
            uklad.y = y;
            uklad.y1 = y1;
            uklad.y2 = y2;

            //tutaj start wątku
            
            thread.Start();
            uklad.UnFin();

            uList.Add(uklad.u);

             

            y = a0 * uklad.u + a1 * uklad.u1 + a2 * u1 - b1 * y1 - b2 * y2;
            y2 = y1;
            y1 = y;

            yList.Add(y);
            uList.Add(uklad.u);

            Console.WriteLine("Tp = {2} -- y z obiekt: {0};; y z uklad {1} \t\t{3}", y, uklad.e, Tp, iter);
            mut.ReleaseMutex();

          

            //Fin();
        }

        
    }
}
