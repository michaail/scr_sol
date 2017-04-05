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

        }

        public override void Update()
        {
            if (counter++ >=10)
            {
                Console.WriteLine(Id);
            }

        }
    }
}
