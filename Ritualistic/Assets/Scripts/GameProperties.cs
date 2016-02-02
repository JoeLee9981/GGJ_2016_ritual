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
    public const int PLAYER_DEFAULT_HEALTH = 100;
    public const float PLAYER_DEFAULT_ARMOR = 0.1f;
    public const int PLAYER_DEFAULT_DAMAGE = 10;
    public const float DEFAULT_ATTACK_SPEED = 1;
    public const float DEFAULT_ATTACK_BONUS = 0;
    public const float DEFAULT_MOVEMENT_SPEED = 3;
    public const float DEFAULT_MOVEMENT_BONUS = 0;
    public const float DEFAULT_SPRINT_BONUS = 0.25f;
    public const float DEFAULT_ENEMY_SPEED = 2f;
    public const string PLAYER_MESH = "demon_hero";

    public const int HITS_TEXT_TIME = 1000;

    //default earth demon stats
    public const float EARTH_ARMOR = 0.2f;
    public const int EARTH_HEALTH = 150;
    public const int EARTH_DAMAGE = 15;
    public const string EARTH_MESH = "demon_rock";

    //default water demon stats
    public const float WATER_ARMOR = 0.3f;
    public const int WATER_HEALTH = 200;
    public const int WATER_DAMAGE = 12;
    public const string WATER_MESH = "demon_water";

    //default fire demon stats
    public const float FIRE_ARMOR = 0.12f;
    public const int FIRE_HEALTH = 130;
    public const int FIRE_DAMAGE = 25;
    public const string FIRE_MESH = "demon_fire";

    //default air demon stats
    public const float AIR_ARMOR = 0.5f;
    public const int AIR_HEALTH = 400;
    public const int AIR_DAMAGE = 10;
    public const float AIR_SPEED = 0.0f;
    public const string AIR_MESH = "demon_air";

    //default metal armor
    public const float METAL_ARMOR = 0.5f;
    public const int METAL_HEALTH = 400;
    public const int METAL_DAMAGE = 10;
    public const float METAL_ATTACK_SPEED = 0.5f;
    public const string METAL_MESH = "demon_metal";

    //default enemy stats
    public const float ENEMY_ARMOR = 0.0f;
    public const int ENEMY_HEALTH = 30;
    public const int ENEMY_DAMAGE = 10;
    public const string ENEMY_MESH = "demon_monk";

    //default boss stats
    public const float BOSS_ARMOR = 0.5f;
    public const int BOSS_HEALTH = 625;
    public const int BOSS_DAMAGE = 50;
    public const string BOSS_MESH = "demon_air";

    public static Vector3 GetDefaultPlayerVector() {
        return new Vector3(PLAYER_X_START, PLAYER_Y_START, PLAYER_Z_START);
    }
}
