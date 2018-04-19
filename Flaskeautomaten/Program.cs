using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    class Program
    {   
       
       

        static void Main(string[] args)
        {   //Creating objects
            Producer containerProducer = new Producer();
            Sorter SortContainers = new Sorter(containerProducer.ContainerQueue);
            Consumer aConsumer = new Consumer(SortContainers.PantA);
            Consumer bConsumer = new Consumer(SortContainers.PantB);

            //Creating threads
            Thread producer = new Thread(containerProducer.Produce);
            Thread producer1 = new Thread(containerProducer.Produce);
            Thread Sorter = new Thread(SortContainers.Sort);
            Thread aConsume = new Thread(aConsumer.Recycle);
            Thread bConsume = new Thread(bConsumer.Recycle);

            //Starting Threads
            producer.Start();
            producer1.Start();
            Sorter.Start();
            aConsume.Start();
            bConsume.Start();


            
            

            Console.Read();


           


        


            
            
            


            

            

           
        }
    }
}
