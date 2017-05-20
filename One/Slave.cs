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
        private Dictionary<string, int> slownik = new Dictionary<string, int>();

        int iloscEtapow = new int();

        public Slave(int id, List<string> losy) : base(id)
        {
            Console.WriteLine("I'm in Slave {0}", id);
            los = losy;
            wynik = 0;

            SetSlave();
            iloscEtapow = 2;
            
        }
       

        public override void Update()
        {
         
            var podzielona = Extensions.ChunkBy(los, los.Count() / iloscEtapow);    //Podział fragmentu listy do pracy w etapach
            var dictionaries = new List<Dictionary<string, int>> { };

            for (int i = 0; i < podzielona.Count(); i++)
            {
                
                //Mapowanie ilości wystąpień słow we fragmencie listy
                var frequency = podzielona[i].GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
                dictionaries.Add(frequency);

                //Console.WriteLine("aktualny cykl: {0}", i);
                
            }

            var term = dictionaries.ToArray();
            //Console.WriteLine(term.Count());

            //Redukcja słowników cząstkowych powstałych w wyniku etapów 
            //do słownika wynikowego slow przekazywanego do master
            var result = term
            .SelectMany(d => d)
            .GroupBy(kvp => kvp.Key,
            (key, kvps) => new { Key = key, Value = kvps.Sum(kvp => kvp.Value) })
            .ToDictionary(x => x.Key, x => x.Value);

            slow = result;
            Console.WriteLine("slave {0} dlugosc: {1}",Id, slow.Count());
            //for (int d = 0; d < slow.Count(); d++)
            //{
            //    //Console.WriteLine("{0} - {1}", d, temp.ElementAt(d));
            //}

            Fin();
        }
    }
}
