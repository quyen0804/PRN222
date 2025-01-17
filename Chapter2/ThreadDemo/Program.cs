using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void PrintNumber(string message)
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"{message}:{i}");
            Thread.Sleep(1000);
        }
    }

    static void Main(string[] args) {
        Thread.CurrentThread.Name = "Main";
        //create a task by using a lambda expression
        Task task01 = new Task(() => PrintNumber("Task 1"));
        task01.Start();
        //create a task by using delegate and run the task
        Task task02 = Task.Run(delegate
        {
            PrintNumber("Task 02");
        });
        //create a task by using a action delegate
        Task task03 = new Task(new Action(() =>
        {
            PrintNumber("Task 03");
        }));
        task03.Start();
        Console.WriteLine($"Thread '{Thread.CurrentThread.Name}'");
        Console.ReadKey();
    }
}