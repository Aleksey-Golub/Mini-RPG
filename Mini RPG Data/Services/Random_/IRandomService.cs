namespace Mini_RPG_Data.Services.Random_;

public interface IRandomService : IService
{
    int GetIntInclusive(int from, int to);
    float GetFloatExclusive(float from, float to);
    int Get1D6();
}
