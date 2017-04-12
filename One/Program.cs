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
    class Program
    {
        //public static List<CountingAgent> ca = new List<CountingAgent> { };
        //public static List<ConstantCountingAgent> cca = new List<ConstantCountingAgent> { };
        //public static List<SineGeneratingAgent> sga = new List<SineGeneratingAgent> { };

        //public static System.Threading.Thread t0 = new System.Threading.Thread(ca[0].Run);

        static void Main(string[] args)
        {
            Console.WriteLine("One");
            Console.WriteLine("zmiana na gita");
            //GenerateRunnables();
            RunThreads(GenerateRunnables());
            //RunFibres(GenerateRunnables());
            Console.WriteLine("koniec");
            Console.ReadLine();
        }


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

        //Generowanie List Agentów po 10 sztuk

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
            return runnables;
        }





        /*
        public static void GenerateRunnables()
        {
            
            for (int i = 0; i<10; i++)
            {
                ca.Add(new CountingAgent(i));
                cca.Add(new ConstantCountingAgent(i));
                sga.Add(new SineGeneratingAgent(i));
                
                //Console.WriteLine(ca[i].Id);
            }
        }
        */
        /*
        static void RunThreads()
        {
            t0.Start();
        }
        */
    }
}
