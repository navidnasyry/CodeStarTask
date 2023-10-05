using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using FindTopThree.Models;


namespace FindTopThree
{
    public class ProblemSolver
    {
        public string StudentFilePath { get; set; }
        public string ScoreFilePath { get; set; }

        public List<StudentClass> StudentList { get; set; }
        public List<ScoreClass> ScoreList { get; set; }


        public ProblemSolver()
        {

        }
        public ProblemSolver(string studentFilePath, string scoreFilePath)
        {
            this.StudentFilePath = studentFilePath;
            this.ScoreFilePath = scoreFilePath;

            // Create Student List
            var stdJson = File.ReadAllText(studentFilePath);
            this.StudentList = JsonSerializer.Deserialize<List<StudentClass>>(stdJson);

            // Create Score List
            var scrJson = File.ReadAllText(scoreFilePath);
            this.ScoreList = JsonSerializer.Deserialize<List<ScoreClass>>(scrJson);

        }

        public void WriteStudentList()
        {
            Console.WriteLine("Student List : ");
            foreach (var student in this.StudentList)
            {
                student.WriteStudent();
            }
            Console.Write("\n");
            return;
        }
        public void WriteScoreList()
        {
            Console.WriteLine("Score List : ");
            foreach (var score in this.ScoreList)
            {
                score.WriteScore();
            }
            Console.Write("\n");
            return;
        }

        public void WriteTopThreeStudent()
        {
            var res = this.ScoreList
                .Join(this.StudentList, 
                scr => scr.StudentNumber,
                std => std.StudentNumber,
                (scr, std) => new {
                    StudentNumber = std.StudentNumber,
                    Score = scr.Score,
                    FirstName = std.FirstName,
                    LastName = std.LastName
                })
                .GroupBy(u => u.StudentNumber)
                .Select(g => new {
                    Average = g.Average(p => p.Score),
                    StdNum = g.Key,
                    Obj = g
                })
                .OrderBy(a => -a.Average)
                .ToList();

            // Console.WriteLine(test.Last().Average.ToString());
            // Console.WriteLine(string.Join(", ", test));

            for (int i = 0 ; i < 3 ; i++)
            {
                Console.WriteLine("{0}- StdNumber: {1} FName: {2} LName: {3} Averange: {4}",
                    i+1,
                    res[i].Obj.First().StudentNumber.ToString(),
                    res[i].Obj.First().FirstName.ToString(),
                    res[i].Obj.First().LastName.ToString(),
                    res[i].Average.ToString()
                );
            }
        }


    }
}