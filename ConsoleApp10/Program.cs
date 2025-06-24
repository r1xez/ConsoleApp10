using System;
using System.Collections;
using System.Collections.Generic;


class CafeWorker
{
    public string Name { get; set; }
    public string Position { get; set; }

    public CafeWorker(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Position}: {Name}");
    }
}


class Cafe : IEnumerable<CafeWorker>
{
    private List<CafeWorker> workers = new List<CafeWorker>();

    public void AddWorker(CafeWorker worker)
    {
        workers.Add(worker);
    }

    public IEnumerator<CafeWorker> GetEnumerator()
    {
        return workers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Cafe myCafe = new Cafe();

        myCafe.AddWorker(new CafeWorker("Olena", "Barista"));
        myCafe.AddWorker(new CafeWorker("Andriy", "Chef"));
        myCafe.AddWorker(new CafeWorker("Iryna", "Waitress"));

        Console.WriteLine("Cafe Staff:");
        foreach (var worker in myCafe)
        {
            worker.DisplayInfo();
        }
    }
}
