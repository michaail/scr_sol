using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    class Uklad : Agent
    {
        //private int counter = 0;

        public double u, u1, K1, e, K2, e1, K3, e2, A, y, y1, y2;
        public double wskaznik;

        public List<double> uchyby = new List<double>();

        //public double[] el;

        public Uklad(int id, List<double> eLista)
        {
            Console.WriteLine("Uklad Agent {0}", id);
        }

        public override void Initializes()
        {
            Init();
        }

        public override void Update()
        {

            Uchyb();

            Regulator();

            Fin();
        }

        public void Regulator()
        {
            //K1 = K2 = K3 = 1;

            u = u1 + K1 * e + K2 * e1 + K3 * e2;

        }

        public void Uchyb()
        {
            //Console.WriteLine("{0}", y);
            //A = 1;
            e = A - y;
            e1 = A - y1;
            e2 = A - y2;

        }

        public void Wskaznik()
        {
            for (int i = 0; i < 1000; i++)
            {
                wskaznik += Math.Abs(eList[i]) * Math.Pow(i, 2);
            }
        }
    }
}
