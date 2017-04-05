using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace One
{
    public abstract class Agent : IRunnable
    {

        public Agent (int id)
        {
            Id = id;
        }
        
        public IEnumerator<float> CoroutineUpdate()
        {
            float n = new float(); //placeholder
            while(!HasFinished)
            {
                if (HasFinished)
                    yield break;
                else
                    yield return n;
            }
        }

        public void Run()
        {
            while(!HasFinished)
            {
                System.Threading.Thread.Sleep(10); //placeholder
            }
        }

        public abstract void Update();


        public bool HasFinished { get; private set; } = false;

        public int Id { get; private set; }
        

    }
}
