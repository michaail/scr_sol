using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    class SineGeneratingAgent : Agent
    {
        private int counter;
        public SineGeneratingAgent(int id) : base(id)
        {

        }

        public override void Update()
        {
            if (counter++ <= this.Id)
            {
                Console.WriteLine(Id);
            }
            //throw new NotImplementedException();
        }
    }
}
