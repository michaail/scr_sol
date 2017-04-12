using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    class ConstantCountingAgent : Agent
    {
        private int counter = 0;

        public ConstantCountingAgent(int id) : base(id)
        {
            Console.WriteLine("cca I'm here alive {0}", id);
        }

        public override void Update()
        {
            if (counter++ >=10)
            {
                Console.WriteLine("cca {0} ctr {1}", Id, counter);
                Fin();
            }

        }
    }
}
