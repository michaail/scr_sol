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

        System.Collections.Generic.Dictionary<string, int> slownik { get; }
        
        bool HasFinished { get; }

        //List<int> losy { get; }
        

    }
}
