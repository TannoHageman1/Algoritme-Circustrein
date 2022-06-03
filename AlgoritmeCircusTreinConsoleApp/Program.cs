using AlgoritmeCircusTreinLibrary;
using AlgoritmeCircusTreinLibrary.Entities;

TreinLogica treinLogica = new TreinLogica();
List<Dier> dieren = new List<Dier>();
dieren.Add(new Dier(false, 3));
dieren.Add(new Dier(true, 5));
dieren.Add(new Dier(false, 5));
dieren.Add(new Dier(true, 1));
dieren.Add(new Dier(false, 3));
Trein trein = new Trein();

treinLogica.VulTrein(trein, dieren);
int index = 1;

foreach (Wagon w in trein.WagonList)
{
    Console.WriteLine(
        $"Wagon nummer: {index}, bezetheid: {w.GetBezetheid()}\n" +
        $"|------------------|");

    foreach (Dier d in w.GetDieren())
    {
        Console.WriteLine(
            $"|---{(d.IsCarnivoor ? "Carnivoor" : "Herbivoor")}, {d.Grootte}---|");
    }

    Console.WriteLine("|------------------|");
    Console.WriteLine("ooo------ooo-----ooo\n");
    index++;
}

Console.WriteLine(
    $"  O o\n" +
    $"      °\n" +
    $"\n" +
    $"     __\n" +
    $"   _ || _\n" +
    $"    ||||\n" +
    $"   .----.\n" +
    $" | o <> o |\n" +
    @"  ////\\\\" + "\n" +
    @"   / -- \" + "\n" +
    @"   /----\"
    );
Console.ReadKey();