using UnityEngine;
using System.Collections;

public class PlayerCharacter : Character {

    public PlayerCharacter() {
        MaxHealth = GameProperties.PLAYER_DEFAULT_ARMOR;
        Armor = GameProperties.PLAYER_DEFAULT_ARMOR;
        Damage = GameProperties.PLAYER_DEFAULT_DAMAGE;
        Health = MaxHealth;
    }
}
