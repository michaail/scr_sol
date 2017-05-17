using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    class Slave : Agent
    {

        //Extensions dodatki = new Extensions();

        List<string> los = new List<string>();
        Dictionary<string, int> slownik = new Dictionary<string, int>();

        int iloscEtapow = new int();

        //int iter = new int();

        //Dictionary<string, int> slownik = new Dictionary<string, int>();

        //int wynik = new int();
        
        public Slave(int id, List<string> losy) : base(id)
        {
            Console.WriteLine("I'm in Slave {0}", id);
            los = losy;
            wynik = 0;
            //iter = 0;
            SetSlave();
            iloscEtapow = 4;
            
            //Extensions dodatki = new Extensions();
        }
       

        public override void Update()
        {
            //for (int i = 0; i < los.Count(); i++)
            //{
            //    Console.WriteLine(los[i]);
            //}
            var podzielona = Extensions.ChunkBy(los, los.Count() / iloscEtapow);
            for (int i = 0; i < podzielona.Count(); i++)
            {
                var frequency = podzielona[i].GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
                slownik = frequency;
                System.Threading.Thread.Sleep(1000);
                for (int d = 0; d < slownik.Count(); d++)
                {
                    //Console.WriteLine("{0} - {1}", i, slownik.ElementAt(d));
                }

            }

            //slow = slownik;
           

            Fin();
        }
    }
}
