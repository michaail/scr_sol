using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    class RegQuality : Agent
    {
        private int counter = 0;

        public RegQuality(int id)
        {
            Console.WriteLine("Reg Quality {0}", id);
        }

        public override void Initializes()
        {
            Init();
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
