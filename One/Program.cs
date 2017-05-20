/*
Tytuł: Pierwszy projekt w Solucji Sol ćwiczenie 2.2 IRunnable
Opis: 
Autor: Michał Kłos
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    static class Program
    {
        static int slaveCount = 10;
        static List<int> losowe = new List<int>();
      
        static void Main(string[] args)
        {
            //Console.WriteLine("One");
            //Console.WriteLine("zmiana na gita");
            //GenerateRunnables();

            //Wywołanie działania programu na wątkach
            RunThreads(GenerateRunnables());
            //RunFibres(GenerateRunnables());

            Console.WriteLine("koniec");
            Console.ReadLine();
        }

        //Działanie na wątkach
        static void RunThreads(IEnumerable<IRunnable> runnables)
        {
            var threads = new List<System.Threading.Thread>(runnables.Count());

            foreach (var run in runnables)
            {
                var thread = new System.Threading.Thread(run.Run);
                threads.Add(thread);
                thread.Start();
                
            }

            bool allFin = false;
            while (!allFin)
            {
                System.Threading.Thread.Sleep(100);
                allFin = true;
                foreach (var runnable in runnables)
                {
                    if (!runnable.HasFinished)
                    {
                        allFin = false;
                        break;
                    }
                }
                
            }
        }
        
        //Działanie na włóknach
        static void RunFibres(IEnumerable<IRunnable> runnables)
        {
            var enumerator = runnables.Select(r => r.CoroutineUpdate());
            bool allFin = false;
            var timeStep = 0.0f;

            while (!allFin)
            {
                foreach (var enu in enumerator)
                {
                    if (enu.MoveNext())
                    {
                        timeStep = enu.Current;
                    }
                }

                allFin = !runnables.Any(r => !r.HasFinished);
                System.Threading.Thread.Sleep(100);
            }            
        }

        static List<IRunnable> GenerateRunnables()
        {
            
            var runnables = new List<IRunnable>(1000);
            
            //Pobranie pliku tekstowego text.txt
            string text = System.IO.File.ReadAllText(@"C:\SCR\IRunnable\Sol\One\text.txt");
            string[] split = text.Split(new Char[] { });    //Podział pliku na listę string

            List<string> podzielona = split.ToList();

            Console.WriteLine(split.Count());   //ilość słów ogółem

            var lista = ChunkBy(podzielona, podzielona.Count()/slaveCount); //Podział listy słów na ilość części slaveCount
            
            for (int i = 0; i<slaveCount; i++)
            {
                //Utworzenie agentów slave otrzymującyh fragmenty listy słów
                runnables.Add(new Slave(i, lista[i]));
            }
            
            //Utworzenie agenta master nadzorującego pracę slave i redukującego ich wyniki do jednego
            runnables.Add(new Master(1000, runnables));        
            return runnables;

        }
        
        //Metoda dzieląca listę na części o długości chunkSize
        static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
