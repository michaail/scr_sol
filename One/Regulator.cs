using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    class Regulator : Agent
    {
        
        public float Output { get; set; }

        public Regulator(int id)
        {
            Console.WriteLine("sga I'm here alive {0} ", id);
        }

        public override void Initializes()
        {
            Init();
        }

        public override void Update()
        {
            Output = (float)Math.Sin(vTime);
            if (vTime >= Id % 10)
            {
                Console.WriteLine("sga {0} ", Id);
                Fin();
            }
        }
    }
}
