﻿
HashSet<string> companyTeams = new(){ "Ferrari", "McLaren", "Mercedes" };
HashSet<string> traditionalTeams = new() { "Ferrari", "McLaren" };
HashSet<string> privateTeams = new(){ "Red Bull", "Toro Rosso", "Force India", "Sauber" };

if (privateTeams.Add("Williams"))
{
    Console.WriteLine("Williams added");
}

if (!companyTeams.Add("McLaren"))
{
    Console.WriteLine("McLaren was already in this set");
}
if (traditionalTeams.IsSubsetOf(companyTeams))
{
    Console.WriteLine("traditionalTeams is subset of companyTeams");
}
if (companyTeams.IsSupersetOf(traditionalTeams))
{
    Console.WriteLine("companyTeams is a superset of traditionalTeams");
}


traditionalTeams.Add("Williams");

if (privateTeams.Overlaps(traditionalTeams))
{
    Console.WriteLine("At least one team is the same with traditional and private teams");
}

SortedSet<string> allTeams = new(companyTeams);
allTeams.UnionWith(privateTeams);
allTeams.UnionWith(traditionalTeams);
Console.WriteLine();
Console.WriteLine("all teams");
foreach (var team in allTeams)
{
    Console.WriteLine(team);
}


allTeams.ExceptWith(privateTeams);
Console.WriteLine();
Console.WriteLine("no private team left");
foreach (var team in allTeams)
{
    Console.WriteLine(team);
}