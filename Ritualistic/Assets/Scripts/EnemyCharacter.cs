﻿using UnityEngine;
using System.Collections;

public class EnemyCharacter : Character {

    CharacterType characterType;

    public EnemyCharacter(CharacterType characterType) {
        this.characterType = characterType;
        SetupCharacter();
    }

    private void SetupCharacter() {
        switch(characterType) {
            case CharacterType.BOSS:
                SetupBoss();
                break;
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
                SetupEnemey();
                break;
        }
    }

    private void SetupAir() {
        MaxHealth = GameProperties.AIR_HEALTH;
        Armor = GameProperties.AIR_ARMOR;
        Damage = GameProperties.AIR_DAMAGE;
        SpeedBonus = GameProperties.AIR_SPEED;
        Health = MaxHealth;
    }

    private void SetupMetal() {
        MaxHealth = GameProperties.METAL_HEALTH;
        Armor = GameProperties.METAL_ARMOR;
        Damage = GameProperties.METAL_DAMAGE;
        AttackSpeedBonus = GameProperties.METAL_ATTACK_SPEED;
        Health = MaxHealth;
    }

    private void SetupBoss() {
        MaxHealth = GameProperties.BOSS_HEALTH;
        Armor = GameProperties.BOSS_ARMOR;
        Damage = GameProperties.BOSS_DAMAGE;
        Health = MaxHealth;
    }

    private void SetupFire() {
        MaxHealth = GameProperties.FIRE_HEALTH;
        Armor = GameProperties.FIRE_ARMOR;
        Damage = GameProperties.FIRE_DAMAGE;
        Health = MaxHealth;
    }

    private void SetupEarth() {
        MaxHealth = GameProperties.EARTH_HEALTH;
        Armor = GameProperties.EARTH_ARMOR;
        Damage = GameProperties.EARTH_DAMAGE;
        Health = MaxHealth;
    }

    private void SetupWater() {
        MaxHealth = GameProperties.WATER_HEALTH;
        Armor = GameProperties.WATER_ARMOR;
        Damage = GameProperties.WATER_DAMAGE;
        Health = MaxHealth;
    }

    private void SetupEnemey() {
        MaxHealth = GameProperties.ENEMY_HEALTH;
        Armor = GameProperties.ENEMY_ARMOR;
        Damage = GameProperties.ENEMY_DAMAGE;
        Health = MaxHealth;
    }
}
