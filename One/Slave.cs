using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    class Slave : Agent
    {
        List<int> los = new List<int>();

        //int iter = new int();

        //Dictionary<string, int> slownik = new Dictionary<string, int>();

        //int wynik = new int();
        
        public Slave(int id, List<int> losy) : base(id)
        {
            Console.WriteLine("I'm in Slave");
            los = losy;
            wynik = 0;
            //iter = 0;
            SetSlave();
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



            for (int i = 0; i < los.Count() / 2; i++)
            {
                wynik += los[i];
                //Console.WriteLine("etap1");
                //System.Threading.Thread.Sleep(20);
            }
            Console.WriteLine("1 tappa Slave {0} lives with result of: {1}", Id, wynik);
            for (int i = los.Count() / 2; i < los.Count(); i++)
            {
                wynik += los[i];
                //Console.WriteLine("etap 2");
                //System.Threading.Thread.Sleep(10);
            }
            Console.WriteLine("2 tappa Slave {0} dies with result of: {1}", Id, wynik);

            Fin();
        }
    }
}
