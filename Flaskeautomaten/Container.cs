using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    public class Container
    {
        //Container properties
        //id is an unique number to track the container.
        //type is the return type of the container. 
        private uint id;

        private char type;

        
        public char Type { get => type; set => type = value; }
        public uint Id { get => id; set => id = value; }


        //Constructor for Container, initiating with a return type (A or B for now) and an ID. 
        public Container (char ContainerType, uint ID)
        {
            Id = ID;
            Type = ContainerType;
        }
    }

       



    
}
