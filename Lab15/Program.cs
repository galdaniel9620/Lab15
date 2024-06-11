using Lab15;
using static System.Runtime.InteropServices.JavaScript.JSType;

List <Student> students = new List <Student> ();
students.Add(new Student() { Id = Guid.NewGuid(), FirstName = "Saarah", LastName = "Stevenson", Age = 22, Department = Department.Letters });
students.Add(new Student() { Id = Guid.NewGuid(), FirstName = "Maja", LastName = "Williamson", Age = 18, Department = Department.Letters });
students.Add(new Student() { Id = Guid.NewGuid(), FirstName = "Velma", LastName = "French", Age = 17, Department = Department.Informatics });
students.Add(new Student() { Id = Guid.NewGuid(), FirstName = "Yousuf", LastName = "Lovet", Age = 24, Department = Department.Constructions });
students.Add(new Student() { Id = Guid.NewGuid(), FirstName = "Yousuf", LastName = "Jede", Age = 24, Department = Department.Constructions });
students.Add(new Student() { Id = Guid.NewGuid(), FirstName = "Lottie", LastName = "Woodward", Age = 32, Department = Department.Constructions });
students.Add(new Student() { Id = Guid.NewGuid(), FirstName = "Delores", LastName = "Lin", Age = 28, Department = Department.Letters });
students.Add(new Student() { Id = Guid.NewGuid(), FirstName = "Derek", LastName = "Ferguson", Age = 25, Department = Department.Informatics });
students.Add(new Student() { Id = Guid.NewGuid(), FirstName = "Dan", LastName = "Spence", Age = 25, Department = Department.Informatics });
students.Add(new Student() { Id = Guid.NewGuid(), FirstName = "Helen", LastName = "Brennan", Age = 25, Department = Department.Constructions });


// 1. Afisati cel mai in varsta student de la Informatica
Console.WriteLine("Afisati cel mai in varsta student de la Informatica");
var maxAgeFromInformatics = students.Where(x => x.Department == Department.Informatics).Max(x => x.Age);
var oldestStudentFromInformatics = students.Where(x => x.Department == Department.Informatics && x.Age == maxAgeFromInformatics).ToList();

if (oldestStudentFromInformatics.Any())
{
    oldestStudentFromInformatics.ForEach(x => Console.WriteLine($"Oldest: {x.FirstName} is {x.Age}"));
}
else
{
    Console.WriteLine("No students in Informatics department.");
}

// 2.  Afisati cel mai tanar student
Console.WriteLine("\r\nAfisati cel mai tanar student");
var minAge = students.Min(x => x.Age);
var youngestStudentFromInformatics1 = students.Where(x => x.Age == minAge).ToList();
var youngestStudentFromInformatics2 = students.OrderByDescending(x => x.Age).LastOrDefault();


if (youngestStudentFromInformatics1.Any())
{
    youngestStudentFromInformatics1.ForEach(x => Console.WriteLine($"Youngest: {x.FirstName} is {x.Age}"));
}
else
{
    Console.WriteLine("No students in Informatics department.");
}

Console.WriteLine($"Youngest: {youngestStudentFromInformatics2.FirstName} is {youngestStudentFromInformatics2.Age}");

// 3. Afisati in ordine crescatoare a varstei toti,studentii de la litere
Console.WriteLine("\r\nAfisati in ordine crescatoare a varstei toti,studentii de la litere");

var orderByAgeStudentsFromLetters = students.Where(x => x.Department == Department.Letters).OrderBy(x => x.Age).ToList();

if (orderByAgeStudentsFromLetters.Any())
{
    orderByAgeStudentsFromLetters.ForEach(x => Console.WriteLine($"{x.FirstName} {x.Age}"));
}

// 4. Afisati primul student de la constructii cu varsta de peste 20 de ani
Console.WriteLine("\r\nAfisati primul student de la constructii cu varsta de peste 20 de ani");
var firstFromConstruction = students.Where(x => x.Department == Department.Constructions && x.Age > 20).First();
Console.WriteLine($"{firstFromConstruction.FirstName} {firstFromConstruction.LastName} {firstFromConstruction.Age}");

// 5. Afisati studentii avand varsta egala cu varsta medie a studentilor
Console.WriteLine("\r\nAfisati studentii avand varsta egala cu varsta medie a studentilor");

var averageAge = students.Average(x => x.Age);
var averageAgeStudents = students.FindAll(x => x.Age == averageAge).ToList();
if (averageAgeStudents.Any())
{
    averageAgeStudents.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));
}

// 6.  Afisati, in ordinea descrescatoare a varstei, si in ordine alfabetica, dupa numele de familie si dupa numele mic, toti studentii cu varsta cuprinsa intre 18 si 35 de ani
Console.WriteLine("\r\nAfisati, in ordinea descrescatoare a varstei, si in ordine alfabetica, dupa numele de familie si dupa numele mic, toti studentii cu varsta cuprinsa intre 18 si 35 de ani");

var filterStudent = students
    .Where(x => x.Age > 18 && x.Age < 35)
    .OrderByDescending(x => x.Age)
    .ThenBy(x => x.LastName)
    .ThenBy(x => x.FirstName)
    .ToList();

if(filterStudent.Any())
{
    filterStudent.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName} {x.Age}"));
}

// 7. Afisati ultimul elev din lista
Console.WriteLine("\r\nAfisati ultimul elev din lista");

var lastStudentFromList = students.LastOrDefault();
Console.WriteLine($"{lastStudentFromList.FirstName} {lastStudentFromList.LastName}");


// 8. Afisati mesajul “Exista si minori” daca in lista creeata exista si persone cu varsta mai mica de 18 ani. In caz contar afesati “Nu exista minori”
Console.WriteLine("\r\nAfisati mesajul “Exista si minori” daca in lista creeata exista si persone cu varsta mai mica de 18 ani. In caz contar afesati “Nu exista minori");

var studentUnder18 = students.Any(x => x.Age < 18);
if (studentUnder18)
{
    Console.WriteLine("Exista si minori");
}
else
{
    Console.WriteLine("Nu exista minori");
}


// 9. Folosind GroupBy, afisati toti studentii grupati in functie de varsta sub forma urmatoare
Console.WriteLine();

var groupedStudents = students.OrderBy(x => x.Age).ToList();

IEnumerable<IGrouping<int, string>> query = groupedStudents.GroupBy(x => x.Age, x => x.FirstName);

foreach (IGrouping<int, string> e in query)
{
    Console.WriteLine(e.Key);
    foreach (string name in e)
        Console.WriteLine("  {0}", name);
}