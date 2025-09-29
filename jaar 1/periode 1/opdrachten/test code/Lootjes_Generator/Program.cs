List<int> alle5 = [];
List<int> alle10 = [];

for (int i = 0; i <= 2000; i += 5)
{
    alle5.Add(i);
}

for (int i = alle5.Count - 1; i >= 0; i--)
{
    if (alle5[i] % 10 == 0)
    {
        alle10.Add(alle5[i]);
        alle5.RemoveAt(i);
    }
}


foreach (int getal in alle10)
{
    Console.WriteLine(getal);
}