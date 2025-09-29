using OllamaSharp;

namespace opdracht3
{
    class ApparaatInfo
    {
        public required string Naam { get; set; }
        public required string Label { get; set; }
    }

    class ApparaatOpslaan
    {
        public static List<ApparaatInfo> apparaten = [];
        public static bool stopApp = false;
        static void Main()
        {

            while (!stopApp)
            {
                Menu();
            }
        }
        static void Menu()
        {
            int nummer;
            Console.WriteLine(); //Wit regel voor beter overzicht
            EnhancedText("ApparaatBeheer 0.1", ConsoleColor.Green, true);
            EnhancedText("Kies een optie:", ConsoleColor.Gray, true);
            EnhancedText("1. Apparaat toevoegen", ConsoleColor.White, true);
            EnhancedText("2. Apparaat verwijderen", ConsoleColor.White, true);
            EnhancedText("3. Alle apparaten zien", ConsoleColor.White, true);
            EnhancedText("4. Vraag energieadvies aan", ConsoleColor.White, true);
            EnhancedText("5. Stoppen", ConsoleColor.White, true);

            while (true)
            {
                string keuze = Console.ReadLine() ?? "0";
                if (int.TryParse(keuze, out _))
                {
                    nummer = Convert.ToInt32(keuze);
                    break;
                }
                else
                {
                    EnhancedText("Please enter a number: ", ConsoleColor.Red, true);
                }
            }

            Console.WriteLine(); //Wit regel voor beter overzicht

            switch (nummer)
            {
                case 1:
                    ApparaatToevoegen();
                    break;
                case 2:
                    ApparaatVerwijderen();
                    break;
                case 3:
                    ApparatenInzien();
                    break;
                case 4:
                    AdviesVragen().GetAwaiter().GetResult();
                    break;
                case 5:
                    stopApp = true;
                    break;
                default:
                    EnhancedText("Voer een geldig optie in!", ConsoleColor.Red, true);
                    break;
            }
        }

        static void ApparaatToevoegen()
        {
            string apparaat;
            while (true)
            {
                EnhancedText("Welk apparaat wil je toevoegen?", ConsoleColor.Gray, true);
                apparaat = Console.ReadLine() ?? "Onbekend";
                if (apparaten.Find(a => a.Naam == apparaat) != null)
                {
                    EnhancedText($"Apparaat met naam: {apparaat} bestaat al!", ConsoleColor.Red, true);
                }
                else
                {
                    break;
                }
            }
            EnhancedText("Wat is je energielabel (A-G)?", ConsoleColor.Gray, true);
            string energielabel = Console.ReadLine() ?? "Z";
            while (!"ABCDEFG".Contains(energielabel.ToUpper()))
            {
                EnhancedText("Voer een geldig label in (A-G)", ConsoleColor.Red, true);
                energielabel = Console.ReadLine() ?? "Z";
            }
            apparaten.Add(new ApparaatInfo
            {
                Naam = apparaat,
                Label = energielabel
            });
            EnhancedText("Apparaat opgeslagen!", ConsoleColor.Green, true);
        }

        static void ApparaatVerwijderen()
        {
            EnhancedText("Lijst van opgeslagen apparaten: ", ConsoleColor.Gray, true);
            foreach (ApparaatInfo apparaat in apparaten)
            {
                EnhancedText($"Naam: {apparaat.Naam} | Label: {apparaat.Label}", ConsoleColor.Cyan, true);
            }
            EnhancedText("Welk apparaat wil je verwijderen?", ConsoleColor.Yellow, true);
            EnhancedText("Let op! Type het juiste apparaat in!", ConsoleColor.DarkGray, true);
            while (true)
            {
                string teVerwijderen = Console.ReadLine() ?? "";
                ApparaatInfo? gevondenApparaat = apparaten.FirstOrDefault(a => a.Naam == teVerwijderen);
                if (gevondenApparaat != null)
                {
                    apparaten.Remove(gevondenApparaat);
                    EnhancedText("Apparaat verwijderd!", ConsoleColor.Green, true);
                    break;
                }
                else
                {
                    EnhancedText("Apparaat niet gevonden!", ConsoleColor.Red, true);
                }
            }
        }

        static void ApparatenInzien()
        {
            EnhancedText("Lijst van opgeslagen apparaten: ", ConsoleColor.Gray, true);
            foreach (ApparaatInfo apparaat in apparaten)
            {
                EnhancedText($"Naam: {apparaat.Naam} | Label: {apparaat.Label}", ConsoleColor.Cyan, true);
            }
        }

        static async Task AdviesVragen()
        {
            EnhancedText("Wat is uw geschatte jaarverbruik in kWh?: ", ConsoleColor.Gray, true);
            string rawkWh = Console.ReadLine() ?? "0";
            while (!int.TryParse(rawkWh, out _))
            {
                EnhancedText("Please enter a number!", ConsoleColor.Red, true);
                rawkWh = Console.ReadLine() ?? "0";
            }
            int kWh = Convert.ToInt32(rawkWh);
            
            // Count devices by energy label
            var labelCounts = new Dictionary<string, int>
            {
                ["A"] = 0,
                ["B"] = 0,
                ["C"] = 0,
                ["D"] = 0,
                ["E"] = 0,
                ["F"] = 0,
                ["G"] = 0
            };

            foreach (ApparaatInfo apparaat in apparaten)
            {
                string label = apparaat.Label.ToUpper();
                if (labelCounts.TryGetValue(label, out int count))
                {
                    labelCounts[label] = count + 1;
                }
            }

            // Create device description string
            var deviceDescriptions = new List<string>();
            foreach (var label in labelCounts)
            {
                if (label.Value > 0)
                {
                    string apparaatTekst = label.Value == 1 ? "apparaat" : "apparaten";
                    deviceDescriptions.Add($"{label.Value} {apparaatTekst} met label {label.Key}");
                }
            }

            string apparatenBeschrijving = deviceDescriptions.Count > 0
                ? string.Join(", ", deviceDescriptions)
                : "geen apparaten";
            
            var uri = new Uri("http://localhost:11434");
            var ollamaClient = new OllamaApiClient(uri)
            {
                SelectedModel = "gemma3:4b"
            };

            string prompt = $"""
            Gedraag je als een vriendelijke en deskundige energieadviseur. 

            Mijn huidige situatie is als volgt:
            - Jaarlijks energieverbruik: {kWh} kWh
            - Mijn apparaten: {apparatenBeschrijving}.

            Geef mij een kort, motiverend en persoonlijk energieadvies in het Nederlands van maximaal 3 alinea's. 
            Focus op het vervangen van de apparaten met de slechtste energielabels (D en F) en geef twee concrete, makkelijk uitvoerbare tips om direct te beginnen met besparen. 
            Schrijf op een manier die zowel duidelijk als bemoedigend is.
            """;

            await foreach (var stream in ollamaClient.GenerateAsync(prompt))
            {
                Console.Write(stream.Response);
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