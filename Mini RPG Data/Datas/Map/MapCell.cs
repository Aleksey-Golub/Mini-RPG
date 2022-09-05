using Mini_RPG_Data.Datas;

namespace Mini_RPG_Data.Map_;

public class MapCell : IMapCell
{
    public MapCell(Vector2Int position, CellType cellType = CellType.Empty, CellState cellState = CellState.Unexplored)
    {
        Position = position;
        CellType = cellType;
        CellState = cellState;
    }

    public Vector2Int Position { get; set; }
    public CellType CellType { get; set; }
    public CellState CellState { get; set; }

    internal Vector2Int[] GetNeighborsPositions()
    {
        int neighborsCount = 4;
        Vector2Int[] result = new Vector2Int[neighborsCount];

        result[0] = new Vector2Int(Position.X - 1, Position.Y);
        result[1] = new Vector2Int(Position.X + 1, Position.Y);
        result[2] = new Vector2Int(Position.X, Position.Y - 1);
        result[3] = new Vector2Int(Position.X, Position.Y + 1);

        return result;
    }
}
