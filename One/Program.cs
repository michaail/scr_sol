/*
Tytuł: Pierwszy projekt w Solucji Sol ćwiczenie 2.2 IRunnable
Opis: 
Autor: Michał Kłos
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace One
{
    static class Program
    {
        static List<int> losowe = new List<int>();

        public static System.Threading.Mutex mut = new System.Threading.Mutex();

        public static Semaphore sem = new Semaphore(0, 1);

        static void Main(string[] args)
        {
            //Console.WriteLine("One");
            //Console.WriteLine("zmiana na gita");
            //GenerateRunnables();
            Console.WriteLine("start");


            RunThreads(GenerateRunnables());
            //RunFibres(GenerateRunnables());

            Console.WriteLine("koniec");
            Console.ReadLine();
        }

        static void RunThreads(IEnumerable<IRunnable> runnables)
        {
            var initThreads = new List<System.Threading.Thread>(runnables.Count());
            var runThreads = new List<System.Threading.Thread>(runnables.Count());

            foreach (var run in runnables)
            {

                var thread = new System.Threading.Thread(run.Initialize);
                initThreads.Add(thread);
                thread.Start();
                
            }

            bool allInit = false;
            while (!allInit)
            {
                System.Threading.Thread.Sleep(100);
                allInit = true;
                foreach (var runnable in runnables)
                {
                    if (!runnable.HasInitialized)
                    {
                        allInit = false;
                        break;
                    }
                }
                //Master mistrz = new Master(100, slaves);
            }
            if (allInit)
            {
                foreach (var run in runnables)
                {
                    var thread = new System.Threading.Thread(run.Run);
                    runThreads.Add(thread);
                    thread.Start();
                }
                bool allFin = false;
                while(!allFin)
                {
                    allFin = true;
                    foreach (var runnable in runnables)
                    {
                        if(!runnable.HasFinished)
                        {
                            allFin = false;
                            break;
                        }
                    }
                }
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
            //var u1 = new Uklad(1);
            var runnables = new List<IRunnable>(1000);
            
            runnables.Add(new Obiekt(105));
            
            //runnables.Add(new Obiekt(50));
            //runnables.Add(new Obiekt(75));
            //runnables.Add(new Obiekt(100));
            //runnables.Add(new Obiekt(125));

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
