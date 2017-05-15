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

        List<int> los = new List<int>();
        int iloscEtapow = new int();

        //int iter = new int();

        //Dictionary<string, int> slownik = new Dictionary<string, int>();

        //int wynik = new int();
        
        public Slave(int id, List<int> losy) : base(id)
        {
            Console.WriteLine("I'm in Slave {0}", id);
            los = losy;
            wynik = 0;
            //iter = 0;
            SetSlave();
            iloscEtapow = 10;
            
            //Extensions dodatki = new Extensions();
        }
       

        public override void Update()
        {
            /*
            for (int i = 0; i < los.Count(); i++)
            {
                if(!slownik.Any(d => d.Key==los[i]))
                {
                    slownik.Add(los[i], 2);
                    //iter++;
                }
                else
                {
                    int currentCount;
                    slownik.TryGetValue(los[i], out currentCount);
                    slownik[los[i]] = currentCount +1;
                    //slownik.va
                    //slownik[los[i], ];
                }
                //if (los.Any(slownik[]))

                //if(los[i] == slownik[])

                //Console.WriteLine(los[i]);
            }

            foreach (KeyValuePair<string, int> kvp in slownik)
            {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            //Console.WriteLine(slownik.Keys[i]);
            */


            var podzielona = Extensions.ChunkBy(los, los.Count()/iloscEtapow);
            //List<List<int>> podzielona = Extensions.ChunkBy<>

            for (int i = 0; i < podzielona.Count(); i++)
            {
                for (int j = 0; j < podzielona[i].Count(); j++)
                {
                    wynik += podzielona[i][j];
                }
                Console.WriteLine("Slave {2} wynik po {0} etapie: {1}", i, wynik, Id);
            }

            //Console.WriteLine(podzielona.Count());
           

            Fin();
        }
    }
}
