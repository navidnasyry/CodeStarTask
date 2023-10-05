using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTopThree.Models
{
    public class ScoreClass
    {
        public int StudentNumber { get; set; }

        public string Lesson { get; set; }

        public float Score { get; set; }
        public ScoreClass()
        {

        }

        public ScoreClass(int studentNumber, string lesson, float score)
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