using System;
using System.Collections;
using System.Collections.Generic;


class FootballPlayer
{
    public string Name { get; set; }
    public string Position { get; set; }
    public int Number { get; set; }

    public FootballPlayer(string name, string position, int number)
    {
        Name = name;
        Position = position;
        Number = number;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"#{Number} {Name} - {Position}");
    }
}


class FootballTeam : IEnumerable<FootballPlayer>
{
    private List<FootballPlayer> players = new List<FootballPlayer>();

    public void AddPlayer(FootballPlayer player)
    {
        players.Add(player);
    }

    public IEnumerator<FootballPlayer> GetEnumerator()
    {
        return players.GetEnumerator();
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
        FootballTeam team = new FootballTeam();

        team.AddPlayer(new FootballPlayer("John Smith", "Defender", 4));
        team.AddPlayer(new FootballPlayer("Michael Johnson", "Forward", 9));
        team.AddPlayer(new FootballPlayer("David Brown", "Midfielder", 7));

        Console.WriteLine("Football team lineup:");
        foreach (var player in team)
        {
            player.DisplayInfo();
        }
    }
}
