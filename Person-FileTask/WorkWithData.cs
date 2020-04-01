using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Person_FileTask
{
    class WorkWithData
    {
        public void Serialize(BinaryWriter binaryWriter, Person[] person)
        {
            try
            {
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

        public Person[] Desserialize(BinaryReader binaryWriter)
        {
            try
            {
                List<Person> people = new List<Person>();
                while (binaryWriter.PeekChar()>-1)
                {
                    int age = binaryWriter.ReadInt32();
                    string firstName = binaryWriter.ReadString();
                    string lastName = binaryWriter.ReadString();
                    Sex sex = (Sex) Enum.Parse(typeof(Sex),binaryWriter.ReadString());
                    DateTime bornTime = DateTime.Parse(binaryWriter.ReadString());
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
