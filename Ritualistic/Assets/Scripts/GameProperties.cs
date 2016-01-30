using UnityEngine;
using System.Collections;

/**
 * All game properties should be located here, they should be declared const
    as these properties should not change and should be static.
 */
public class GameProperties {

    public const float PLAYER_X_START = 0;
    public const float PLAYER_Y_START = 0.75f;
    public const float PLAYER_Z_START = 0;
    public const float PLAYER_DEFAULT_HEALTH = 100;
    public const float PLAYER_DEFAULT_ARMOR = 0.1f;
    public const float PLAYER_DEFAULT_DAMAGE = 10;
    public const float DEFAULT_ATTACK_SPEED = 1;
    public const float DEFAULT_ATTACK_BONUS = 0;
    public const float DEFAULT_MOVEMENT_SPEED = 4;
    public const float DEFAULT_MOVEMENT_BONUS = 0;
    public const float DEFAULT_SPRINT_BONUS = 0.25f;

    //default earth demon stats
    public const float EARTH_ARMOR = 0.2f;
    public const float EARTH_HEALTH = 150;
    public const float EARTH_DAMAGE = 15;

    //default water demon stats
    public const float WATER_ARMOR = 0.3f;
    public const float WATER_HEALTH = 200;
    public const float WATER_DAMAGE = 12;

    //default fire demon stats
    public const float FIRE_ARMOR = 0.12f;
    public const float FIRE_HEALTH = 130;
    public const float FIRE_DAMAGE = 25;

    //default air demon stats
    public const float AIR_ARMOR = 0.5f;
    public const float AIR_HEALTH = 400;
    public const float AIR_DAMAGE = 10;
    public const float AIR_SPEED = 0.3f;

    //default metal armor
    public const float METAL_ARMOR = 0.5f;
    public const float METAL_HEALTH = 400;
    public const float METAL_DAMAGE = 10;
    public const float METAL_ATTACK_SPEED = 0.5f;

    //default enemy stats
    public const float ENEMY_ARMOR = 0.0f;
    public const float ENEMY_HEALTH = 10;
    public const float ENEMY_DAMAGE = 30;

    //default boss stats
    public const float BOSS_ARMOR = 0.5f;
    public const float BOSS_HEALTH = 625;
    public const float BOSS_DAMAGE = 50;

    public static Vector3 GetDefaultPlayerVector() {
        return new Vector3(PLAYER_X_START, PLAYER_Y_START, PLAYER_Z_START);
    }
}
