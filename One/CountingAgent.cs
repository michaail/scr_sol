using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    class CountingAgent : Agent
    {
        private int counter = 0;

        public CountingAgent(int id) : base(id)
        {
            Console.WriteLine("ca I'm here alive {0}", id);
        }

        public override void Update()
        {
            if (counter++ <= this.Id)
            {
                Console.WriteLine("ca {0}", Id);
                Fin();
            }
            //throw new NotImplementedException();
        }
    }
}
