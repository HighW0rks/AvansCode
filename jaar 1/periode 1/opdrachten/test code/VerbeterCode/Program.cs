double a = 0;
double b = 1;
double result_new = 0;
double result_prev = 5;

for (int i = 0; i < 20; i++)
{
    a = a + b;
    b = b + a;
    result_new = b / a;
    if ((result_prev - result_new) > 0.000001)
    {
        Console.WriteLine(result_new);
        result_prev = result_new;
    }
    else
    {
        break;
    }

    

}