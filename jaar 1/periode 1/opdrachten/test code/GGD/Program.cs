int nummer1 = 48;
int nummer2 = 72;
int smallest = (nummer1 < nummer2) ? nummer1 : nummer2;
int ggd = 0;
for (int i = 1; i <= smallest; i++)
{
    if (nummer1 % i == 0 && nummer2 % i == 0)
    {
        ggd = i;
    }
}
Console.WriteLine(ggd);