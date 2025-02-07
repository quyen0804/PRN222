using System;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Collections.Generic;

class Program
{
    //IsPrime returns true if num is prime, else false
    private static bool IsPrime(int n)
    {
        bool result = true;
        if (n < 2) { return false; }

        for (var divisor = 2; divisor <= Math.Sqrt(n) && result == true; divisor++)
        {
            if (n % divisor == 0)
            {
                result = false;
            }
        }
        return result;
    }

    //GetPrimeList returns prime num by using sequential foreach
    private static IList<int> GetPrimeList(IList<int> numbers) => numbers.Where(IsPrime).ToList();

    //GetPrimeListWithParallel returns prime num by using Parallel.ForEach
    private static IList<int> GetPrimeListWithParallel(IList<int> numbers)
    {
        var primeNumbers = new ConcurrentBag<int>();
        Parallel.ForEach(numbers, number =>
        {
            if (IsPrime(number))
            {
                primeNumbers.Add(number);
            }
        });
        return primeNumbers.ToList();
    }


    static void Main()
    {
        //2m
        var limit = 2_000_000;
        var numbers = Enumerable.Range(0, limit).ToList();

        var watch = Stopwatch.StartNew();
        var primeNumFromForEach = GetPrimeList(numbers);
        watch.Stop();   

        var watchParallel = Stopwatch.StartNew();
        var primeNumFromParallel = GetPrimeListWithParallel(numbers);
        watchParallel.Stop();

        Console.WriteLine($"Classical foreach loop | Total prime numbers: "
            + $"{primeNumFromForEach.Count} | Time taken: "
            + $"{watch.ElapsedMilliseconds} ms.");

        Console.WriteLine($"Parallel foreach loop | Total prime numbers: "
            + $"{primeNumFromParallel.Count} | Time taken: "
            + $"{watchParallel.ElapsedMilliseconds} ms.");

        Console.WriteLine("Press any key to exit.");
        Console.ReadLine();

    }
}
