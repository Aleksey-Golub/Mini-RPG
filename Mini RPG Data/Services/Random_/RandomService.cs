namespace Mini_RPG_Data.Services.Random_;

public class RandomService : IRandomService
{
    private readonly Random _random;

    public RandomService()
    {
        _random = new Random();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="throwCount">Have to be greate then 0</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public int Get1D6(int throwCount = 1)
    {
        if (throwCount < 1)
            throw new ArgumentException($"{throwCount} have to be greate then 0");

        int sum = 0;
        for (int i = 0; i < throwCount; i++)
            sum += GetIntInclusive(1, 6);
        
        return sum;
    }

    public float GetFloatExclusive(float from, float to)
    {
        if (from > to)
            throw new ArgumentOutOfRangeException($"{from} greater then {to}");

        float res = _random.NextSingle();
        res *= to - from;
        res += from;
        return res;
    }

    public int GetIntInclusive(int from, int to)
    {
        if (from > to)
            throw new ArgumentOutOfRangeException($"{from} greater then {to}");

        return _random.Next(from, to + 1);
    }
}
