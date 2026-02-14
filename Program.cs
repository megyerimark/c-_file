using System;
using System.IO;
using System.Text;
using System.Collections.Generic;


// Beolvassuk a fájlt
string[] valasztas = File.ReadAllLines("szavazatok.txt", Encoding.UTF8);

// Kiíratjuk a sorokat
for (int i = 0; i < valasztas.Length; i++)
{
    Console.WriteLine(valasztas[i]);
}

foreach (var item in valasztas)
{
    Console.WriteLine(item);
}
Console.WriteLine($"A választáson {valasztas.Length} választó vett részt.\n");

// Hány választó vett részt?
int S = 0;
for (int i = 0; i < valasztas.Length; i++)
{
    string[] darab = valasztas[i].Split(' ');
    S += int.Parse(darab[1]);
}
Console.WriteLine($"A választáson {S} választó szavazott.");

// TISZT párt tagjai
Console.WriteLine("A tiszt párt tagjai:");
foreach (var sor in valasztas)
{
    string[] darabolt = sor.Split(' ');
    if (darabolt[4] == "TISZ")
    {
        Console.WriteLine(darabolt[2] + " " + darabolt[3]);
    }
}

// Létrehozzuk a listát 
List<Jelolt> jeloltek = new List<Jelolt>();
FileStream fs = new FileStream("szavazatok.txt", FileMode.Open);
StreamReader sr = new StreamReader(fs, Encoding.UTF8);
//while (sr.ReadLine() != null) de az első üres sornál megáll

while (!sr.EndOfStream)
{
    string[] sor = sr.ReadLine().Split(' ');
    Jelolt jelolt = new Jelolt();
    jelolt.korzet = int.Parse(sor[0]);
    jelolt.szavazatok = int.Parse(sor[1]);
    jelolt.nev = sor[2] + " " + sor[3];
    jelolt.part = sor[4];
    jeloltek.Add(jelolt); // A listám a Jelöltek
}
 int sum = 0 ;
foreach (Jelolt jelolt in jeloltek)
{
    sum += jelolt.szavazatok;
}
Console.WriteLine($"Összes szavazat: {sum}");
Console.WriteLine("A Tiszt párt jelöltjei:");
for (int i = 0; i < jeloltek.Count; i++)
{
    if (jeloltek[i].part == "TISZ")
    {
        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.WriteLine(jeloltek[i].nev);
        Console.ResetColor();
    }
}




struct Jelolt
{    public int korzet;
    public int szavazatok;
    public string nev;
    public string part;
}