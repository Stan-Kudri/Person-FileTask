using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_FileTask
{
    [Serializable]
    public class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Sex Sex { get; set; }
        public DateTime BornDate { get; set; }

        public Person()
        {

        }

        public Person(int age, string firstName, string lastName, Sex sex, DateTime bornDate)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
            BornDate = bornDate;
        }
    }
}
