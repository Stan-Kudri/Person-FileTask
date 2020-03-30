using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Person[] persons = new Person[3];
            persons[0] = new Person(22,"Сергей","Широков",Sex.Male,new DateTime(1998,1,15));
            persons[1] = new Person(23, "Дмитрий", "Сущевский", Sex.Male, new DateTime(1996,10,3));
            persons[2] = new Person(23, "Алена", "Сущевская", Sex.Female, new DateTime(1997,3,10));

            string path = @"X:\person.dat";
            var work = new WorkWithData();
            work.DataRecording(path, persons);
            var array = work.RetrievingDataFromFile(path);
            work.OutputArray(array);

            Console.ReadLine();
        }
    }
}
