// See https://aka.ms/new-console-template for more information

using ClassWork_55_00;

Console.WriteLine("Hello, World!");
var finder = new FileFinder();
var result = finder.FindFile("/Users/azamammon",
                "some.txt").ToList();
foreach (var item in result)
{
    Console.WriteLine(item);
}
