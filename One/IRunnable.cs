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

        bool isSlave { get; }

        int wynik { get; }

        int initial { get; }

        IEnumerator<float> CoroutineUpdate();
        
        bool HasFinished { get; }

        Dictionary<string, int> slow { get; }
        

    }
}
