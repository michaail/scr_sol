using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    class Master : Agent
    {
        List<IRunnable> agenci = new List<IRunnable>();
        
        Dictionary<string, int> temp = new Dictionary<string, int>();
        List<List<KeyValuePair<string, int>>> wLiscie = new List<List<KeyValuePair<string, int>>>();

        public Master(int id, List<IRunnable> runnables) : base(id)
        {
            agenci = runnables;
            Console.WriteLine("I'm in Master");
            Console.WriteLine(agenci.Count());
            
        }

        public override void Update()
        {
            while (!agenci.Any(d => d.HasFinished == true))
            {
                System.Threading.Thread.Sleep(10);
            }

            var dictionaries = new List<Dictionary<string, int>> { };
            foreach (var a in agenci)
            {
                if (a.slow != null)
                {
                    dictionaries.Add(a.slow);
                    Console.WriteLine(dictionaries.Count());
                }
            }

            //Console.WriteLine(dictionaries.Count());
            var term = dictionaries.ToArray();
            //Console.WriteLine(term.Count());

            //for (int d = 0; d < term.Count(); d++)
            //{
            //      Console.WriteLine("{0} - {1}", d, term[0].ElementAt(d));
            //}

            //Redukcja słowników ze slaveów do słownika wynikowego
            var result = term
                .SelectMany(d => d)
                .GroupBy(kvp => kvp.Key, 
                (key, kvps) => new { Key = key, Value = kvps.Sum(kvp => kvp.Value) })
                .ToDictionary(x => x.Key, x => x.Value);
                //temp = result;
            //GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            //Console.WriteLine(term.Count());
            for (int d = 0; d < result.Count(); d++)
            {
                Console.WriteLine("{0} - {1}", d, result.ElementAt(d));
            }
            
            Console.WriteLine("KONIEC MASTERA!!!!!!!!!!!!!!!!!! wynik: {0}");
            //Console.WriteLine(wynik);
            Fin();
        }

        
    }
}
