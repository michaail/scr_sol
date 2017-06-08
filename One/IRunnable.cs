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

        void Initialize();

        void Init();

        //bool isSlave { get; }

        //int wynik { get; }

        //int initial { get; }

        IEnumerator<float> CoroutineUpdate();
        
        bool HasFinished { get; }

        bool HasInitialized { get; }
        //List<int> losy { get; }
        

    }
}
