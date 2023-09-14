// See https://aka.ms/new-console-template for more information

using Bogus;
using ClassWork_C39;

Console.WriteLine("ClassWork_C39");
int idSeed = 0;

Faker<Student> student = new Faker<Student>()
                .StrictMode(true)
                .RuleFor(student => student.Id, Id => idSeed++)
                .RuleFor(student => student.FirstName, Name => Name.Person.FirstName)
                .RuleFor(student => student.LastName, Name => Name.Person.LastName);

var students = student.Generate(50);

students.ForEach(Console.WriteLine);
