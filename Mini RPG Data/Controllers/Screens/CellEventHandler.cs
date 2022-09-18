using Mini_RPG_Data.Map_;

namespace Mini_RPG_Data.Controllers.Screens;

internal class CellEventHandler
{
    internal void HandlePlayerCell(Map map)
    {
        map.Explore(map.PlayerPosition);
        switch (map.PlayerCell.CellType)
        {
            case CellType.Empty:

                break;
            case CellType.Town:

                break;
            case CellType.Enemy:

                break;
            case CellType.Loot:

                break;
            case CellType.LockedChest:

                break;
            case CellType.HiddedLoot:

                break;
            case CellType.Trap:

                break;
            case CellType.None:
            default:
                break;
        }
    }
}
