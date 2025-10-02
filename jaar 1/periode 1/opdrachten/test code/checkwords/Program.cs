List<string> woordlijst = ["Annebella", "Abba", "apenrots", "Anemonenvijver", "Aap"];

foreach (string woord in woordlijst)
{
    if (woord.StartsWith('A') && woord.Length > 7)
    {
        char[] temp = woord.ToCharArray();
        Array.Reverse(temp);
        string woord_reverse = new(temp);
        Console.WriteLine(woord_reverse);
    }
}