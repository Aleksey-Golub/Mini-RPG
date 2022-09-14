﻿using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Player_;

namespace Mini_RPG_Data.Controllers;

public class Player
{
    private readonly PlayerData _data;

    public Wallet Wallet { get; private set; }
    public Character Character { get; private set; }

    public Player(PlayerData data)
    {
        _data = data;

        Wallet = new Wallet(data.WalletData);
        Character = new Character(data.CharacterData);
    }

    internal void Init()
    {
        Character.Init();
    }
}
