using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    class Consumer
    {
        Queue<Container> recykleFrom; 

        public Queue<Container> ConsumeFrom { get => recykleFrom; set => recykleFrom = value; }

        public Consumer(Queue<Container> consumeFrom) //create the consumer with a list from where it should consume (recycle). 
        {
            recykleFrom = consumeFrom;
        }

        public void Recycle()
        {
            while (true)
            {
                Container recycleContainer;

                lock (recykleFrom)
                {
                    while (recykleFrom.Count() < 1) // if there are no items to consume, wait. 
                    {
                        Monitor.Wait(recykleFrom);
                    }
                    recycleContainer = recykleFrom.Dequeue(); //when there are items to consume, do just that. 

                }
                Console.WriteLine($"Container type: {recycleContainer.Type} id: {recycleContainer.Id} recyled from queue");
                Thread.Sleep(500);
            }
        }
    }
}
