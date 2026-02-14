using System;
using System.IO;
using System.Text;

string[] valasztas = System.IO.File.ReadAllLines("szavazatok.txt", Encoding.UTF8);

for (int i = 0; i < valasztas.Length; i++)
{
    Console.WriteLine(valasztas[i]);
}
foreach (var item in valasztas)
{
    Console.WriteLine(item);
}
Console.WriteLine($"A választáson {valasztas.Length} választó vett részt.");

//Hány válsztó vett részt?
int S = 0 ;
for (int i = 0; i < valasztas.Length; i++)
{
    string[] darab = valasztas[i].Split(' ');
    S+= int.Parse(darab[1]);
}