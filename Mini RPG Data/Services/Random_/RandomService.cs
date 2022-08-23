namespace Mini_RPG_Data.Services.Random_;

internal class RandomService : IRandomService
{
    private readonly Random _random;

    public RandomService()
    {
        _random = new Random();
    }

    public int Get1D6() => GetIntInclusive(1, 6);

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
