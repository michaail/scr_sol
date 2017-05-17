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

        //new int wynik = new int();
        //int iter = 0;
        public Master(int id, List<IRunnable> runnables) : base(id)
        {
            agenci = runnables;
            Console.WriteLine("I'm in Master");
            Console.WriteLine(agenci.Count());
            
            //wynik = 0;
        }

        public override void Update()
        {
            while (!agenci.Any(d => d.HasFinished == true))
            {
                System.Threading.Thread.Sleep(10);
            }

            //while (agenci.Any(d => d.slow == null))
            //{
            //    Console.WriteLine("pusty slow");
            //    System.Threading.Thread.Sleep(100);
            //}

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

            for (int d = 0; d < term.Count(); d++)
            {
                //Console.WriteLine("{0} - {1}", d, term[0].ElementAt(d));
            }


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

            //if (!slownik.Any(d => d.Key == ))
            //{
            //    slownik.Add(los[i], 1);
            //    //iter++;
            //}
            //else
            //{
            //    int currentCount;
            //    slownik.TryGetValue(los[i], out currentCount);
            //    slownik[los[i]] = currentCount + 1;
            //    //slownik.va
            //    //slownik[los[i], ];
            //}

            Console.WriteLine("KONIEC MASTERA!!!!!!!!!!!!!!!!!! wynik: {0}");
            //Console.WriteLine(wynik);
            Fin();
        }

        
    }
}
