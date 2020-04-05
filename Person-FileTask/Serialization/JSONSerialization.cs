using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;

namespace Person_FileTask.Serialization
{
    class JSONSerialization:ISerialization
    {
        DataContractJsonSerializer ContractJsonSerializer = new DataContractJsonSerializer(typeof(Person[]));

        public void Serialize(Stream stream, Person[] person)
        {
            try
            {
                ContractJsonSerializer.WriteObject(stream, person);
            }
            catch
            {
            }
        }

        public Person[] Desserialize(Stream stream)
        {
            try
            {                
                return (Person[])ContractJsonSerializer.ReadObject(stream);
            }
            catch
            {
                return null;
            }
        }
    }
}
