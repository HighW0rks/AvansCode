class Device
{
    public string Naam { get; set; }
    public int Vermogen { get; set; }
    public int Uren { get; set; }
}

class Program
{
    static void Main()
    {
        int apparatenTotaal = 3;
        double prijs_kwh = 0.25;
        var apparaten = new List<Device>();
        for (int i = 0; i < apparatenTotaal; i++)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Apparaat Naam: ");
            string naam = Console.ReadLine() ?? "Unknown";
            int vermogen = CheckInput(false, "Verbruik van apparaat in Watt: ");
            int uren = CheckInput(true, "Gemiddeld aantal uren in gebruik per dag: ");

            apparaten.Add(new Device
            {
                Naam = naam,
                Vermogen = vermogen,
                Uren = uren
            });

            Console.WriteLine();
        }
        double totaal_kwh = 0;
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Berekenen van apparaten in kWh");
        Console.ForegroundColor = ConsoleColor.Cyan;
        foreach (var apparaat in apparaten)
        {
            double kwh = apparaat.Vermogen * apparaat.Uren / 1000.0;
            Console.WriteLine($"Naam: {apparaat.Naam} | kWh: {kwh:F2}");
            totaal_kwh += kwh;
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Totaal stroomverbruik per dag: kWh {totaal_kwh:F2}");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Stroomprijs per dag: €{(totaal_kwh * prijs_kwh):F2}");
        Console.WriteLine($"Stroomprijs per maand: €{(totaal_kwh * 30 * prijs_kwh):F2}");
        Console.WriteLine($"Stroomprijs per jaar: €{(totaal_kwh * 365 * prijs_kwh):F2}");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Co² uitstoot:");
        Console.WriteLine($"{totaal_kwh * 365 * 0.472:F1} kilo");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }

    static int CheckInput(bool uren, string text, int value = 0)
    {
        bool loop = true;
        while (loop)
        {
            Console.Write(text);
            string input = Console.ReadLine() ?? "0";
            if (int.TryParse(input, out _))
            {
                value = Convert.ToInt32(input);
                if (uren)
                {
                    if (value <= 24)
                    {
                        loop = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Max amount of hours is 24");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                else
                {
                    loop = false;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a number");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        return value;
    }
}
