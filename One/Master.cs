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

        //int wynik = new int();

        public Master(int id, List<IRunnable> runnables) : base(id)
        {
            agenci = runnables;
            Console.WriteLine("I'm in Master");
            wynik = 0;
        }

        public override void Update()
        {
            while (!agenci.Any(d => d.HasFinished == true))
            {
                System.Threading.Thread.Sleep(10);
            }

            foreach (var a in agenci)
            {
                wynik += a.wynik;
            }
            Console.WriteLine("KONIEC MASTERA!!!!!!!!!!!!!!!!!! wynik: {0}", wynik);
            //Console.WriteLine(wynik);
            Fin();
        }
    }
}
