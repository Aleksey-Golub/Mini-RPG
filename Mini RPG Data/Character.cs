﻿namespace Mini_RPG_Data;

public class Character
{
    private readonly Abilities _abilities;

    public Character(string name, string avatarFilePath, Race race, Abilities baseAbilities)
    {
        Name = name;
        AvatarFilePath = avatarFilePath;
        Race = race;
        _abilities = Abilities.Get(baseAbilities, race);

        Level = new Level();
        Health = new Health(this);
    }

    public string Name { get; }
    public string AvatarFilePath { get; }
    public Race Race { get; }
    public Level Level { get; }
    public IAbilities Abilities => _abilities;
    public Health Health { get; }
}
