using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person_FileTask.Serializable;
using System.IO;

namespace Person_FileTask
{
    class Program
    {
        /*Напиши класс Person с полями Age(int), FirstName(string), LastName(string), Sex(Enum(Male, Female)), BornDate(DateTime) .
          Нужно написать 2 метода:
            1)Первый принимает массив Person и путь куда сохранить массив(и сохраняет массив объектов в файл).
            2)Второй метод принимает путь к файлу и возвращает массив Person,(загружает из файла).
        */

        public static void Print(Person[] person)
        {
            foreach (var people in person)
            {
                Console.WriteLine($"{people.Age} - {people.FirstName} - {people.LastName} - {people.Sex.ToString()} - {people.BornDate.ToString()}");
            }
        }

        static void Main(string[] args)
        {
            Person[] person = new Person[3];
            person[0] = new Person(22, "Сергей", "Широков", Sex.Male, new DateTime(1998, 1, 15));
            person[1] = new Person(23, "Дмитрий", "Сущевский", Sex.Male, new DateTime(1996, 10, 3));
            person[2] = new Person(23, "Алена", "Сущевская", Sex.Female, new DateTime(1997, 3, 10));

            //Бинарное чтение и запись

            string path = @"X:\person.dat";
            var work = new StandartSerialization();
            using (Stream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                work.Serialize(stream, person);
            }
            Person[] array;
            using (Stream stream = new FileStream(path, FileMode.Open))
            {
                array = work.Desserialize(stream);
            }
            Print(array);

            Console.WriteLine();

            //Бинарная сериализация
            
            string pathSerializables = @"X:\personSerializables.dat";
            var workSerializables = new CustomSerialization();
            Person[] arraySerializables;
            using (Stream stream = new FileStream(pathSerializables, FileMode.OpenOrCreate))
            {
                workSerializables.Serialize(stream, person);
            }
            using (Stream stream = new FileStream(pathSerializables, FileMode.Open))
            {
                arraySerializables = workSerializables.Desserialize(stream);
            }
            Print(arraySerializables);

            Console.WriteLine();

            //xml сериализация

            string pathXML = @"X:\person.xml";
            var workXML = new XMLSerialization();
            Person[] arrayXML;
            using(Stream stream = new FileStream(pathXML, FileMode.OpenOrCreate))
            {
                workXML.Serialize(stream, person);
            }
            using (Stream stream = new FileStream(pathXML, FileMode.Open))
            {
                arrayXML = workXML.Desserialize(stream);
            }
            Print(arrayXML);

            Console.WriteLine();

            //json сериализация

            string pathJSON = @"X:\person.json";
            var workJSON = new XMLSerialization();
            Person[] arrayJSON;
            using (Stream stream = new FileStream(pathJSON, FileMode.OpenOrCreate))
            {
                workJSON.Serialize(stream, person);
            }
            using (Stream stream = new FileStream(pathJSON, FileMode.Open))
            {
                arrayJSON = workJSON.Desserialize(stream);
            }
            Print(arrayJSON);

            Console.ReadLine();
        }
    }
}
