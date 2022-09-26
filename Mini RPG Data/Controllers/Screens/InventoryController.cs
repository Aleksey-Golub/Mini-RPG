using Mini_RPG_Data.Controllers.Character_;

namespace Mini_RPG_Data.Controllers.Screens;

public class InventoryController
{
    private readonly Character _character;

    public InventoryController(ICharacter character)
    {
        _character = character as Character;
    }
}
