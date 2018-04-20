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
        {
            char[] returntypes = new char[] { 'Y', 'I', 'D' };

            //Creating objects
            Producer containerProducer = new Producer();
            Sorter SortContainers = new Sorter(containerProducer.ContainerQueue);
            Consumer aConsumer = new Consumer(SortContainers.PantA);
            Consumer bConsumer = new Consumer(SortContainers.PantB);

            //Creating threads
            Thread producer = new Thread(delegate() { containerProducer.Produce(returntypes); });
            Thread producer1 = new Thread(delegate () { containerProducer.Produce(returntypes); });
            Thread Sorter = new Thread(delegate () { SortContainers.Sort(returntypes); });
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
