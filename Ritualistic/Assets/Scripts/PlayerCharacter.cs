using UnityEngine;
using System.Collections;

public class PlayerCharacter : Character {

    CharacterType characterType;

    public PlayerCharacter(CharacterType characterType) {
        this.characterType = characterType;
        SetupCharacter();
    }

    private void SetupCharacter() {
        switch (characterType) {
            case CharacterType.METAL_DEMON:
                SetupMetal();
                break;
            case CharacterType.AIR_DEMON:
                SetupAir();
                break;
            case CharacterType.FIRE_DEMON:
                SetupFire();
                break;
            case CharacterType.WATER_DEMON:
                SetupWater();
                break;
            case CharacterType.EARTH_DEMON:
                SetupEarth();
                break;
            default:
                SetupPlayer();
                break;

        }
    }

    private void SetupPlayer() {
        MaxHealth = GameProperties.PLAYER_DEFAULT_ARMOR;
        Armor = GameProperties.PLAYER_DEFAULT_ARMOR;
        Damage = GameProperties.PLAYER_DEFAULT_DAMAGE;
        Health = MaxHealth;
        CharacterMesh = GameProperties.PLAYER_MESH;
    }
    private void SetupAir() {
        MaxHealth = GameProperties.AIR_HEALTH;
        Armor = GameProperties.AIR_ARMOR;
        Damage = GameProperties.AIR_DAMAGE;
        SpeedBonus = GameProperties.AIR_SPEED;
        Health = MaxHealth;
        CharacterMesh = GameProperties.AIR_MESH;
    }

    private void SetupMetal() {
        MaxHealth = GameProperties.METAL_HEALTH;
        Armor = GameProperties.METAL_ARMOR;
        Damage = GameProperties.METAL_DAMAGE;
        AttackSpeedBonus = GameProperties.METAL_ATTACK_SPEED;
        Health = MaxHealth;
        CharacterMesh = GameProperties.METAL_MESH;
    }

    private void SetupFire() {
        MaxHealth = GameProperties.FIRE_HEALTH;
        Armor = GameProperties.FIRE_ARMOR;
        Damage = GameProperties.FIRE_DAMAGE;
        Health = MaxHealth;
        CharacterMesh = GameProperties.FIRE_MESH;
    }

    private void SetupEarth() {
        MaxHealth = GameProperties.EARTH_HEALTH;
        Armor = GameProperties.EARTH_ARMOR;
        Damage = GameProperties.EARTH_DAMAGE;
        Health = MaxHealth;
        CharacterMesh = GameProperties.EARTH_MESH;
    }

    private void SetupWater() {
        MaxHealth = GameProperties.WATER_HEALTH;
        Armor = GameProperties.WATER_ARMOR;
        Damage = GameProperties.WATER_DAMAGE;
        Health = MaxHealth;
        CharacterMesh = GameProperties.WATER_MESH;
    }
}
