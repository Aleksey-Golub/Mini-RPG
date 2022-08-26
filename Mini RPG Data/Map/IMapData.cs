namespace Mini_RPG_Data.Map;

public interface IMapData
{
    IReadOnlyDictionary<Vector2Int, IMapCell> Cells { get; }
}
