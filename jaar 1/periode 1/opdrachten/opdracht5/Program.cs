namespace Opdracht5
{
    class Program
    {
        public static List<Product> Producten = MaakProducten();
        public static List<Product> Winkelwagen = [];
        static void Main()
        {
            while (Menu()) { }
        }
        
        static List<Product> MaakProducten()
        {
            return
            [
                new() {Naam = "Laptop", Prijs = 999.99m, Beschrijving = "Een snelle laptop for werk"},
                new() {Naam = "Smartphone", Prijs = 499.99m, Beschrijving = "Een smartphone met een goed camera"},
                new() {Naam = "Headphones", Prijs = 199.99m, Beschrijving = "Noise-cancelling headphones"},
                new() {Naam = "Smartwatch", Prijs = 299.99m, Beschrijving = "Een smartwatch met veel functies"},
                new() {Naam = "Tablet", Prijs = 399.99m, Beschrijving = "Een tablet voor entertainment"},
                new() {Naam = "Camera", Prijs = 599.99m, Beschrijving = "Een digitale camera met hoge resolutie"},
                new() {Naam = "Printer", Prijs = 149.99m, Beschrijving = "Een all-in-one printer"},
                new() {Naam = "Monitor", Prijs = 249.99m, Beschrijving = "Een 27-inch 4K monitor"},
                new() {Naam = "Keyboard", Prijs = 89.99m, Beschrijving = "Een mechanisch keyboard"},
                new() {Naam = "Mouse", Prijs = 49.99m, Beschrijving = "Een draadloze muis"}
            ];
        }

        static bool Menu()
        {
            Console.WriteLine(); //white line

            List<string> opties = ["1. Toon producten", "2. Voeg product toe", "3. Bekijk winkelwagen", "4. Afsluiten"];
            foreach (string text in opties)
            {
                EnhancedText(text, ConsoleColor.Gray, true);
            }

            string optie = Console.ReadLine() ?? "";

            Console.WriteLine(); // White Line

            switch (optie)
            {
                case "1":
                    ToonProduct();
                    break;
                case "2":
                    VoegProduct();
                    break;
                case "3":
                    BekijkWinkelwagen();
                    break;
                case "4":
                    return false;
                default:
                    break;
            }
            return true;
        }

        static void ToonProduct()
        {
            foreach (Product item in Producten)
            {
                EnhancedText($"{item.Id} | {item.Naam} | {item.Prijs}", ConsoleColor.Green, true);
            }
        }

        static void VoegProduct()
        {
            EnhancedText("Type de product ID in om toe te voegen:", ConsoleColor.Gray, false);
            while (true)
            {
                string idString = Console.ReadLine() ?? "";
                if (idString.ToLower() == "stop"){ break; }
                int id = 0;
                if (int.TryParse(idString, out id))
                {
                    Product? product = Producten.Find(p => p.Id == id) ?? null;
                    if (product != null && product.Id > 0)
                    {
                        Winkelwagen.Add(product);
                        EnhancedText($"{product.Naam} is toegevoegd in de winkelwagen.", ConsoleColor.Gray, true);
                        break;
                    }
                    else
                    {
                        EnhancedText("Onbekend product ingevoerd!", ConsoleColor.Red, true);
                        continue;
                    }
                }
                else
                {
                    EnhancedText("Geen geldig nummer in getypt!", ConsoleColor.Red, true);
                    continue;
                }
            }
        }

        static void BekijkWinkelwagen()
        {
            decimal balans = 0m;
            EnhancedText("Je winkelwagen bevat:", ConsoleColor.Gray, true);
            foreach (Product item in Winkelwagen)
            {
                balans += item.Prijs;
                EnhancedText($"Item: {item.Naam} | Prijs: {item.Prijs}", ConsoleColor.Green, true);
            }
            Console.WriteLine(); // White line1
            EnhancedText($"Het totaal bedrag is: €{balans}", ConsoleColor.Blue, true);
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