internal class RandomNumber
{
    private static System.Random randomNumber;

    static RandomNumber()
    {
        randomNumber = new System.Random();
    }

    public static int Next(int exclusiveMax)
    {
        return randomNumber.Next(exclusiveMax);
    }
}