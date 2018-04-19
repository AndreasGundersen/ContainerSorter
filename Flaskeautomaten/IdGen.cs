using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    static class IdGen
    {
        static uint id = 0;
        static object idKey = new object();

        public static uint Id { get => id; set => id = value; }

        public static uint NewId()
        {
            lock(idKey)
            {
                return Id++;
            }
        }
    }
}
