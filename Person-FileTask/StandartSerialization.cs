using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Person_FileTask
{
    class StandartSerialization:ISerialization
    {
        public void Serialize(Stream stream, Person[] person)
        {
            try
            {
                BinaryWriter binaryWriter = new BinaryWriter(stream);
                foreach(Person date in person)
                {
                    binaryWriter.Write(date.Age);
                    binaryWriter.Write(date.FirstName);
                    binaryWriter.Write(date.LastName);
                    binaryWriter.Write(date.Sex.ToString());
                    binaryWriter.Write(date.BornDate.ToString());
                }
            }
            catch
            {
            }
        }

        public Person[] Desserialize(Stream stream)
        {
            try
            {
                BinaryReader binaryReader = new BinaryReader(stream);
                List<Person> people = new List<Person>();
                while (binaryReader.PeekChar()>-1)
                {
                    int age = binaryReader.ReadInt32();
                    string firstName = binaryReader.ReadString();
                    string lastName = binaryReader.ReadString();
                    Sex sex = (Sex) Enum.Parse(typeof(Sex), binaryReader.ReadString());
                    DateTime bornTime = DateTime.Parse(binaryReader.ReadString());
                    people.Add(new Person(age,firstName,lastName, sex, bornTime));
                }

                return people.ToArray();
            }
            catch
            {
                return null;
            }
        }

        public void Print(Person[] person)
        {
            foreach(var people in person)
            {
                Console.WriteLine($"{people.Age} - {people.FirstName} - {people.LastName} - {people.Sex.ToString()} - {people.BornDate.ToString()}");
            }
        }
    }
}
