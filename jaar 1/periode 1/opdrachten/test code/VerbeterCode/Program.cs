decimal saldo = 0.33m;
decimal transactieBedrag = 49.95m;
decimal kredietLimiet = -1000.0m;

if (saldo - transactieBedrag >= 0)
{
    saldo -= transactieBedrag;
    Console.WriteLine("verwerk transactie");
}
else if (saldo - transactieBedrag > kredietLimiet)
{
    saldo -= transactieBedrag;
    Console.WriteLine("verwerk transactie");
    Console.WriteLine("Let op: Saldo negatief");
}
else
{
     Console.WriteLine("Blokkeer transactie");
}

Console.WriteLine($"Uw saldo is: {saldo}");
