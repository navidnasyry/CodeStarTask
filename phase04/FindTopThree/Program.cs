using FindTopThree.Models;
using FindTopThree;

Console.WriteLine("Init Project...");
string stdFilePath = "./Students.json";
string scrFilePaht = "./Scores.json";

ProblemSolver ps = new ProblemSolver(stdFilePath, scrFilePaht);

// ps.WriteStudentList();
// ps.WriteScoreList();
ps.WriteTopThreeStudent();
