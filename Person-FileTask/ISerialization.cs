using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Person_FileTask
{
    interface ISerialization
    {
        void Serialize(Stream stream, Person[] person);

        Person[] Desserialize(Stream stream);

        void Print(Person[] person);
        
    }
}
