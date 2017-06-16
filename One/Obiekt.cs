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

        private Timer oTimer;
        private System.Threading.Thread thread;


        //private Timer oTimer;

        //public static List<double> eList;

        public double u, u1, u2, y1, y2;
        public double K1, K2, K3, kp, Td, Ti;

        public Uklad uklad;

        

        public System.Threading.Mutex mut = new System.Threading.Mutex();

        public Obiekt(double tp)
        {
            this.Tp = tp;

        }

        public override void Initializes()
        {

            uklad = new Uklad(25, eList);
            uklad.Fin();

            oTimer = new Timer();
            oTimer.Elapsed += new ElapsedEventHandler(OnTimeEvent);
            oTimer.Interval = Tp;
            Console.WriteLine("nowy timer {0}", Tp);

            thread = new System.Threading.Thread(uklad.Run);
            thread.Start();

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
            //mut.WaitOne();
            

            
            //thread.Start();
            //oTimer.Start();

            oTimer.Enabled = true;
            Console.WriteLine("zakonczenie timera {0}", iter);
            Fin();

            //Fin();
            //mut.ReleaseMutex();
            //Console.WriteLine("Wykonanie obiektu");

        }
        private void OnTimeEvent(object oSource, ElapsedEventArgs oElapsedEventsArgs)
        {
            mut.WaitOne();
            iter++;
            if (iter >= 10000)
            {


                oTimer.Stop();
                Console.WriteLine("Tp = {2} -- y z obiekt: {0};; y z uklad {1} \t\t{3}", yList[yList.Count() - 1], uklad.e, Tp, iter);
                Console.ReadKey();
            }
            uklad.A = 1;

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
            
            //tu się ma uruchamiac uklad Run raz na wywoalanie timera
            uklad.UnFin();


            //thread.Start();
            



            //ze sie skonczyl uklad run
            //Console.WriteLine("czekam na semafor");
            Program.sem.WaitOne();
            //Console.WriteLine("po semaforze");

            uList.Add(uklad.u);
            y = a0 * uList[uList.Count()-1] + a1 * uList[uList.Count()-2] + a2 * uList[uList.Count()-3] - b1 * yList[yList.Count()-1] - b2 * yList[yList.Count()-2];
            //y2 = y1;
            //y1 = y;

            yList.Add(y);
            //uList.Add(uklad.u);
            //Console.WriteLine("Tp = {2} -- y z obiekt: {0};; y z uklad {1} \t\t{3}", yList[yList.Count() - 1], uklad.e, Tp, iter);
            //Console.WriteLine("Tp = {2} -- y z obiekt: {0};; y z uklad {1} \t\t{3}", y, uklad.e, Tp, iter);
            mut.ReleaseMutex();

          

            //Fin();
        }

        
    }
}
