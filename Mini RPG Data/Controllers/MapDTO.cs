using Mini_RPG_Data.Map;

public class MapDTO
{
    public MapDTO(IMapData mapData, int minX, int maxX, int minY, int maxY)
    {
        MapData = mapData;
        MinX = minX;
        MaxX = maxX;
        MinY = minY;
        MaxY = maxY;
    }

    public IMapData MapData { get; }
    public int MinX { get; }
    public int MaxX { get; }
    public int MinY { get; }
    public int MaxY { get; }
}
