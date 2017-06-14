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

        public Agent ()
        {
            
        }

        public Agent (int id, List<double> lista)
        {
            Id = id;
            
        }
        
        public Agent (int id)
        {
            Id = id;
        }
        
        public IEnumerator<float> CoroutineUpdate()
        {
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
                //System.Threading.Thread.Sleep((int)Math.Round(timeStep*1000.0f)); //placeholder
            }
        }

        public void Initialize()
        {
            while(!HasInitialized)
            {
                Initializes();
            }
        }

        public void Fin()
        {
            this.HasFinished = true;
        }

        public void UnFin()
        {
            this.HasFinished = false;
        }

        public void Init()
        {
            this.HasInitialized = true;
        }

        static public List<double> uList = new List<double>();
        static public List<double> eList = new List<double>();
        static public List<double> yList = new List<double>();


        public abstract void Initializes();
        public abstract void Update();

        public bool HasFinished { get; private set; } = false;

        public bool HasInitialized { get; private set; } = false;

        public int Id { get; private set; }

    }
}
