using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Person_FileTask.Serializable
{
    class WorkWithDataSerializable
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        public void Serialize(Stream stream, Person[] person)
        {
            try
            {
                binaryFormatter.Serialize(stream, person);                
            }
            catch
            {
                
            }
        }

        public Person[] Desserialize(Stream stream)
        {
            try
            {
                return (Person[])binaryFormatter.Deserialize(stream);
            }
            catch
            {
                return null;
            }
        }

        public void Print(Person[] person)
        {
            foreach (var people in person)
            {
                Console.WriteLine($"{people.Age} - {people.FirstName} - {people.LastName} - {people.Sex.ToString()} - {people.BornDate.ToString()}");
            }
        }
    }
}
