using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    class Producer
    {
        //Declaring a random object and our containerqueue (this is where we want to put our A + B containers)
        private Random rnd = new Random();
        private Queue<Container> containerQueue = new Queue<Container>();

        public Queue<Container> ContainerQueue { get => containerQueue; set => containerQueue = value; }
        public Random Rnd { get => rnd; set => rnd = value; }

        public Producer()
        {

        }


        public void Produce(char[] type)
        {
            char[] ReturnType = type;

            while (true) //The producer will keep trying to produce Containers
            {
                if (ContainerQueue.Count() < 20) //Check if there are less than 20 Containers in the queue
                {
                    lock (ContainerQueue) //lock the queue to make sure nobbody else can use it while we produce
                    {
                        for (int i = 0; i < rnd.Next(1, 11); i++) //run this loop for 1-10
                        {
                            int ContainerType = rnd.Next(0, ReturnType.Length); //Provide a random int between 0-1
                            Container container;
                            container = new Container(ReturnType[ContainerType], IdGen.NewId());
                            ContainerQueue.Enqueue(container);

                            Console.WriteLine($"Machine {Thread.CurrentThread.ManagedThreadId} placed Container: {container.Id} type: {container.Type} onto conveyor");
                            
                        }
                        Monitor.Pulse(ContainerQueue); //Tells waiting threads that we are done with the queue (when we leave the lock)
                    }
                }
                Thread.Sleep(rnd.Next(1000, 2000)); //sleep for 1-2 seconds

            }
        }
    }
}
