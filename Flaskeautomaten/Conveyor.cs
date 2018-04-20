using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    class Conveyor
    {
        private Queue<Container> containerQueue = new Queue<Container>();
        private string conveyortype;
        private int conveyorSize;

        public int ConveyorSize { get => conveyorSize; set => conveyorSize = value; }
        public string Conveyortype { get => conveyortype; set => conveyortype = value; }
        
        

        public Conveyor(int size)
        {
            ConveyorSize = size;
            Conveyortype = "Mixed";
        }

        public Conveyor(int size, string type)
        {
            ConveyorSize = size;
            Conveyortype = Convert.ToString(type);
        }


        //public void AddContainer(Container c)
        //{
        //    containerQueue.Enqueue(c);
        //}

        //public Container RemoveContainer()
        //{
        //    Container RemovedContainer;

        //    RemovedContainer = containerQueue.Dequeue();

        //    return RemovedContainer;
        //}
    }
}
