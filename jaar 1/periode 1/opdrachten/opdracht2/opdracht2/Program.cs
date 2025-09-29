namespace opdracht2
{
    class EnergieMeting
    {
        public class DayUsage
        {
            public int Dag { set; get; }
            public double Verbruik { set; get; }
        }
    
        // setting global variables
        public static List<DayUsage> perDagUsage = [];
        public static List<int> dagenPerMaand = [];
        public static double jaarGebruik;
        public static List<double> energyConsumed = [];


        static void Main()
        {
            Console.WriteLine();
            // genereert eerst een lijst met verschillende waardes
            GenereerLijst();

            // Opdracht 1 Jaaroverzicht
            Opdracht1();
            Console.WriteLine();

            // Dagen per maand bepalen
            for (int maand = 1; maand <= 12; maand++)
            {
                dagenPerMaand.Add(DateTime.DaysInMonth(DateTime.Now.Year, maand));
            }

            // Variable bepalen
            List<double> energyMonth = [];
            int month = 1;
            int checkDays = dagenPerMaand[month - 1];
            double consumedDay = 0;
            double consumedMonth = 0;
            double old_value = energyConsumed[0];

            // Opdracht 2 Verbruik per maand 
            // Alle dagen opslaan en maandelijks gebruik opslaan
            for (int i = 0; i < energyConsumed.Count; i++)
            {
                double new_value = energyConsumed[i];
                if (new_value > old_value)
                {
                    consumedDay = new_value - old_value;
                    consumedMonth += consumedDay;
                    perDagUsage.Add(new DayUsage
                    {
                        Dag = i,
                        Verbruik = consumedDay
                    });
                    consumedDay = 0;
                    old_value = new_value;
                }
                // check of alle dagen in de maand verbruikt zijn en slaat ze op
                if (i == checkDays - 1)
                {
                    energyMonth.Add(consumedMonth);
                    EnhancedText($"Consumed in month {(Maanden)month}: ", ConsoleColor.Gray, false);
                    EnhancedText($"{consumedMonth:F2} ", ConsoleColor.Yellow, false);
                    EnhancedText("kWh", ConsoleColor.Gray, true);
                    consumedMonth = 0;
                    month += 1;
                    if (month <= 12)
                    {
                        checkDays += dagenPerMaand[month - 1];
                    }
                }
            }
            Console.WriteLine();
            
            // Opdracht 3 maandoverzicht in een nieuwe lijst
            EnhancedText($"Checken jaarGebruik vs maand gebruik (opgeteld)", ConsoleColor.DarkGray, true);
            EnhancedText("Jaar: ", ConsoleColor.DarkBlue, false);
            EnhancedText($"{jaarGebruik}", ConsoleColor.Cyan, true);
            EnhancedText("Maand: ", ConsoleColor.DarkBlue, false);
            EnhancedText($"{energyMonth.Sum()}", ConsoleColor.Cyan, true);

            if (jaarGebruik == energyMonth.Sum())
            {
                EnhancedText("Check klopt!", ConsoleColor.Green, true);
            }
            else
            {
                EnhancedText("Check klopt niet!", ConsoleColor.Red, true);
            }
            Console.WriteLine();

            // Opdracht 4 Hoe groot is het huishouden?
            Opdracht4();
            Console.WriteLine();
            UitdagingOpdracht();
            Console.WriteLine();
        }

        static void GenereerLijst()
        {
            double currentValue = 4245.25;
            for (int i = 0; i < 365; i++)
            {
                energyConsumed.Add(Math.Round(currentValue, 2));

            // daily increase: 1.00 – 100.00
                double dailyIncrease = Math.Round(new Random().NextDouble() * 20 + 1, 2);
                currentValue += dailyIncrease;
            }
        }

        static void Opdracht1()
        {
            double begin = energyConsumed[0];
            double end = energyConsumed[energyConsumed.Count - 1];
            jaarGebruik = end - begin;

            EnhancedText($"De beginstand op 1 januari is: ", ConsoleColor.Gray, false);
            EnhancedText($"{begin} ", ConsoleColor.Yellow, false);
            EnhancedText("kWh", ConsoleColor.Gray, true);

            EnhancedText($"De eindstand op 31 december is: ", ConsoleColor.Gray, false);
            EnhancedText($"{end} ", ConsoleColor.Yellow, false);
            EnhancedText("kWh", ConsoleColor.Gray, true);

            EnhancedText($"Het jaarverbruik is: ", ConsoleColor.Gray, false);
            EnhancedText($"{jaarGebruik:F2} ", ConsoleColor.Yellow, false);
            EnhancedText("kWh", ConsoleColor.Gray, true);
        }

        static void Opdracht4()
        {
            string huishouden;
            
            // Let op: de grenswaarden tussen de categorieën zijn gebaseerd op de middens (gemiddelden) tussen 1-, 2-, 3- en 4-persoonshuishoudens.
            switch (jaarGebruik)
            {
                case >= 0 and < (1640 + 2550) / 2:
                    huishouden = "1";
                    break;
                case >= (1640 + 2550) / 2 and < (2550 + 3080) / 2:
                    huishouden = "2";
                    break;
                case >= (2550 + 3080) / 2 and < (3080 + 3600) / 2:
                    huishouden = "3";
                    break;
                case >= (3080 + 3600) / 2 and < (3600 + 3980):
                    huishouden = "4";
                    break;
                default:
                    huishouden = "5+";
                    break;
            }
            EnhancedText($"Op basis van het jaarverbruik behoort dit huishouden waarschijnlijk tot de categorie: {huishouden} man groot", ConsoleColor.Magenta, true);
            
        }
        static void UitdagingOpdracht()
        {
            var top3 = perDagUsage
                        .OrderByDescending(d => d.Verbruik)
                        .Take(3)
                        .ToList();
            foreach (var top in top3)
            {
                int Dag = top.Dag;
                int maand = 0;
                while (Dag > dagenPerMaand[maand])
                {
                    Dag -= dagenPerMaand[maand];
                    maand++;
                }
                maand++; // Zorgt ervoor dat Januari (1) correct word weergeven
                Console.WriteLine($"Je hebt op {Dag} {(Maanden)maand}: {top.Verbruik:F2} kWh verbruikt");
            }
        }
        
        static void EnhancedText(string text, ConsoleColor color, bool WriteLine)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            if (WriteLine)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }
            Console.ForegroundColor = originalColor;
        }
    }
}
