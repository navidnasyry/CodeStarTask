using System.Text.Json;
using FindTopThree.Models;


Console.WriteLine("Init Project...");

ScoreClass first = new ScoreClass(123, "123", 123.23f);


first.WriteScore();


StudentClass fir = new StudentClass(123, "N", "NN");

fir.WriteStudent();


string stdFilePath = "./Students.json";
string scrFilePaht = "./Sccore.json";


var json = File.ReadAllText(stdFilePath);

var std = JsonSerializer.Deserialize<List<StudentClass>>(json);

Console.WriteLine(std.ToString());