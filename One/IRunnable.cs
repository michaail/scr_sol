using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    public interface IRunnable
    {
        void Run();

        IEnumerator<float> CoroutineUpdate();
        
        bool HasFinished { get; }
        
        
    }
}
