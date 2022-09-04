using Mini_RPG_Data.Datas;

namespace Mini_RPG_Data.Map;

public interface IMapCell
{
    Vector2Int Position { get; }
    CellType CellType { get; }
    CellState CellState { get; }
}
