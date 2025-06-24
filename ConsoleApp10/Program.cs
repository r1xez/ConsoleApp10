using System;
using System.Collections;
using System.Collections.Generic;


abstract class SeaCreature
{
    public string Name { get; set; }
    public string Species { get; set; }

    public SeaCreature(string name, string species)
    {
        Name = name;
        Species = species;
    }

    public abstract void DisplayInfo();
}


class Shark : SeaCreature
{
    public Shark(string name) : base(name, "Shark") { }

    public override void DisplayInfo()
    {
        Console.WriteLine($" Shark: {Name}");
    }
}

class Dolphin : SeaCreature
{
    public Dolphin(string name) : base(name, "Dolphin") { }

    public override void DisplayInfo()
    {
        Console.WriteLine($" Dolphin: {Name}");
    }
}

class Octopus : SeaCreature
{
    public Octopus(string name) : base(name, "Octopus") { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Octopus: {Name}");
    }
}


class Oceanarium : IEnumerable<SeaCreature>
{
    private List<SeaCreature> creatures = new List<SeaCreature>();

    public void AddCreature(SeaCreature creature)
    {
        creatures.Add(creature);
    }

    public IEnumerator<SeaCreature> GetEnumerator()
    {
        return creatures.GetEnumerator();
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
        Oceanarium oceanarium = new Oceanarium();

        oceanarium.AddCreature(new Shark("Bruce"));
        oceanarium.AddCreature(new Dolphin("Flipper"));
        oceanarium.AddCreature(new Octopus("Inky"));

        Console.WriteLine("Residents of oceanarium:");
        foreach (var creature in oceanarium)
        {
            creature.DisplayInfo();
        }
    }
}
