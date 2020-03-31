using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person_FileTask.Serializable;

namespace Person_FileTask
{
    class Program
    {
        /*Напиши класс Person с полями Age(int), FirstName(string), LastName(string), Sex(Enum(Male, Female)), BornDate(DateTime) .
          Нужно написать 2 метода:
            1)Первый принимает массив Person и путь куда сохранить массив(и сохраняет массив объектов в файл).
            2)Второй метод принимает путь к файлу и возвращает массив Person,(загружает из файла).
        */

        static void Main(string[] args)
        {
            Person[] person = new Person[3];
            person[0] = new Person(22,"Сергей","Широков",Sex.Male,new DateTime(1998,1,15));
            person[1] = new Person(23, "Дмитрий", "Сущевский", Sex.Male, new DateTime(1996,10,3));
            person[2] = new Person(23, "Алена", "Сущевская", Sex.Female, new DateTime(1997,3,10));

            string path = @"X:\person.dat";
            var work = new WorkWithData();
            work.DataRecording(path, person);
            var array = work.RetrievingDataFromFile(path);
            work.OutputArray(array);

            Console.WriteLine();

            PersonSerializable[] personSerializables = new PersonSerializable[3];
            personSerializables[0] = new PersonSerializable(22, "Сергей", "Широков", Sex.Male, new DateTime(1998, 1, 15));
            personSerializables[1] = new PersonSerializable(23, "Дмитрий", "Сущевский", Sex.Male, new DateTime(1996, 10, 3));
            personSerializables[2] = new PersonSerializable(23, "Алена", "Сущевская", Sex.Female, new DateTime(1997, 3, 10));

            string pathSerializables = @"X:\personSerializables.dat";
            var workSerializables = new WorkWithDataSerializable();
            workSerializables.DataRecording(pathSerializables, personSerializables);
            var arraySerializables = workSerializables.RetrievingDataFromFile(pathSerializables);
            workSerializables.OutputArray(arraySerializables);


            Console.ReadLine();
        }
    }
}
