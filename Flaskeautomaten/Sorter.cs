using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    class Sorter
    {

        private Queue<Container> pantA = new Queue<Container>(); //Creating 2 new queues for the sorter to sort into. 
        private Queue<Container> pantB = new Queue<Container>();
        private Queue<Container> mix;

        public Queue<Container> Mix { get => mix; set => mix = value; }
        public Queue<Container> PantA { get => pantA; set => pantA = value; }
        public Queue<Container> PantB { get => pantB; set => pantB = value; }

        public Sorter(Queue<Container> list) //Creating our sorter with the queue we want it to sort 
        {
            Mix = list;
        }

        public void Sort()
        {
            
            while (true) //keep going..
            {

                Container sort; 

                lock (Mix)
                {
                    while (Mix.Count() < 1) //while there is nothing in the queue, wait. 
                    {
                        Monitor.Wait(Mix);
                    }
                    sort = Mix.Dequeue(); //when there is something in mix, dequeue a container. 
                    
                }


                if (sort.Type == 'A') //if the container is of type: A
                {
                    lock (PantA)
                    {
                        while (PantA.Count() >= 5) //as long as the new queue is full, wait for the something to be put into it 
                        {
                            Console.WriteLine("Waiting on space in Pant A line");
                            Monitor.Wait(PantA);
                        }
                        PantA.Enqueue(sort); //when there is room in the queue, place the item into it. 
                        Console.WriteLine($"Container id: {sort.Id} type: {sort.Type} sorted into Pant A line");
                        Monitor.Pulse(PantA); //Tells waiting threads that we are done with the queue (when we leave the lock)
                    }


                }
                if (sort.Type == 'B') //Like above, but for containers of type: B
                {
                    lock (PantB)
                    {
                        while (PantB.Count() >= 5)
                        {
                            Console.WriteLine("Waiting on space in Pant B line");
                            Monitor.Wait(PantB);
                            
                        }
                        PantB.Enqueue(sort);
                        Console.WriteLine(($"Container id: {sort.Id} type: {sort.Type} sorted into Pant B line"));
                        Monitor.Pulse(PantB);
                    }


                }


                Thread.Sleep(500); //Wait 0,5 seconds before sorting the next item. 
            }
        }
    }
}
