using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTopThree.Models
{
    public class ScoreClass
    {
        public string StudentNumber { get; set; }

        public string Lesson { get; set; }

        public string Score { get; set; }
        public ScoreClass()
        {

        }

        public ScoreClass(string studentNumber, string lesson, string score)
        {
            this.StudentNumber = studentNumber;
            this.Lesson = lesson;
            this.Score = score;

        }

        public void WriteScore()
        {
            Console.WriteLine(
                "SNumber : {0} , Lesson: {1} , Score: {2}",
                this.StudentNumber, this.Lesson, this.Score
            );
            return;
        }





    }
}