using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTopThree.Models
{
    public class StudentClass
    {
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public StudentClass()
        {

        }
        public StudentClass(int studentNumber, string firstName, string lastName)
        {

            this.StudentNumber = studentNumber;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public void WriteStudent()
        {
            Console.WriteLine(
                "SNumber: {0} , FName: {1} , LName: {2}",
                this.StudentNumber, this.FirstName, this.LastName
            );
            return;
        }


    }
}