namespace Mini_RPG_Data.Services.Random_;

public interface IRandomService : IService
{
    int GetIntInclusive(int from, int to);
    float GetFloatExclusive(float from, float to);
    int Get1D3(int throwCount = 1);
    int Get1D6(int throwCount = 1);
}
