using Mini_RPG_Data.Datas;

namespace Mini_RPG_Data.Controllers.Map_;

public interface IMapCell
{
    Vector2Int Position { get; }
    CellType CellType { get; }
    CellState CellState { get; }
    int ImageIndex { get; }
}
