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

        public void DataRecording(string path, PersonSerializable[] person)
        {
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    binaryFormatter.Serialize(fileStream, person);
                }
            }
            catch
            {
                Console.WriteLine("Возникло исключение!");
            }
        }

        public PersonSerializable[] RetrievingDataFromFile(string path)
        {
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    return (PersonSerializable[])binaryFormatter.Deserialize(fileStream);
                }
            }
            catch
            {
                Console.WriteLine("Возникло исключение!");
                return null;
            }
        }

        public void OutputArray(PersonSerializable[] person)
        {
            foreach (var people in person)
            {
                Console.WriteLine($"{people.Age} - {people.FirstName} - {people.LastName} - {people.Sex.ToString()} - {people.BornDate.ToString()}");
            }
        }
    }
}
