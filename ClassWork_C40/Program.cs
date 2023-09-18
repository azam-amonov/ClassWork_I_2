// See https://aka.ms/new-console-template for more information

using ClassWork_C40.ClassWork.Services;

Console.WriteLine("Hello, World!");
var doSomething = new AccountService();

doSomething.RegisterAsync("Hello", "World!");
