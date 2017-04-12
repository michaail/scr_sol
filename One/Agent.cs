using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace One
{
    public abstract class Agent : IRunnable
    {

        protected float vTime = 0.0f;

        protected readonly float timeStep;

        public Agent (int id, float timeStep = 0.1f)
        {
            this.timeStep = timeStep;
            Id = id;
        }
        
        public IEnumerator<float> CoroutineUpdate()
        {
            //float n = new float(); //placeholder
            while(!HasFinished)
            {
                Update();
                vTime += timeStep;
                if (HasFinished)

                    break;
                else
                    yield return vTime;
            }
        }

        public void Run()
        {
            while(!HasFinished)
            {
                Update();
                vTime += timeStep;
                System.Threading.Thread.Sleep((int)Math.Round(timeStep*1000.0f)); //placeholder
            }
        }

        public void Fin()
        {
            this.HasFinished = true;
        }

        public abstract void Update();


        public bool HasFinished { get; private set; } = false;

        public int Id { get; private set; }
        

    }
}
