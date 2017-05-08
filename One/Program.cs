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
        static List<int> losowe = new List<int>();
      
        static void Main(string[] args)
        {
            //Console.WriteLine("One");
            //Console.WriteLine("zmiana na gita");
            //GenerateRunnables();

            RunThreads(GenerateRunnables());
            //RunFibres(GenerateRunnables());

            Console.WriteLine("koniec");
            Console.ReadLine();
        }

        static void RunThreads(IEnumerable<IRunnable> runnables)
        {
            var threads = new List<System.Threading.Thread>(runnables.Count());

            //var slaves = runnables.Where(r => r.isSlave==true);
            //Console.WriteLine(runnables.Count().ToString());

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
                //Master mistrz = new Master(100, slaves);
            }
        }

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
            int id = 0;

            
            for (; id < 10; ++id)
                runnables.Add(new CountingAgent(id));

            int limit = runnables.Count() + 10;
            for (; id < limit; ++id)
                runnables.Add(new SineGeneratingAgent(id));

            limit = runnables.Count() + 100;
            for (; id < limit; ++id)
                runnables.Add(new ConstantCountingAgent(id));
            /*    
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                losowe.Add(rnd.Next(1, 1000));
                //Console.WriteLine(losowe[i]);
            }

            string text = System.IO.File.ReadAllText(@"C:\SCR\IRunnable\Sol\One\text.txt");
            string[] split = text.Split(new Char[] { ' ', '\n' });
            List<string> podzielona = split.ToList();
            
            var lista = ChunkBy(podzielona, podzielona.Count());
            */
            //for (int i = 0; i < lista[0].Count(); i++)
            //{

            //    //Console.WriteLine("one: {0} ;; two: {1}", lista[0][i], lista[1][i]);
            //}
            /*
            for (int i = 0; i<=0; i++)
            {
                runnables.Add(new Slave(i, lista[i]));

                //Console.WriteLine("liczba el w talicy skroc: {0}", lista[i].Count);
                //Console.WriteLine(lista[i][2].ToString());
                //runnables.Add(new Slave(i, lista[i]));

            }
            */
            
            //for (int i = 0; i < split.Count(); i++)
            //{
            //    Console.WriteLine(split[i]);
            //}
            //var slaves = runnables.Where(r => r.isSlave == true);
            

            //runnables.Add(new Master(1000, runnables));

            
            return runnables;
        }
        
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
