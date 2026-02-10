public class MagicNumberService : IMagicNumberService
{
    private Random rnd = new Random();

    public List<int> GetMagicNumberList(int number)
    {
        List<int> numberList = new List<int>();
        for (int i = 0; i < number; i++)
        {
            numberList.Add(rnd.Next(0, 199));
        }
        return numberList;
    }  
}