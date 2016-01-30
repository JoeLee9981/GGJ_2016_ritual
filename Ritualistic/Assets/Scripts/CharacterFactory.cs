using UnityEngine;
using System.Collections;
public enum CharacterType {
    PLAYER,
    EARTH_DEMON,
    AIR_DEMON,
    WATER_DEMON,
    FIRE_DEMON,
    METAL_DEMON,
    ENEMY,
    BOSS
}

public static class CharacterFactory {

	public static Character GetEnemyCharacter(CharacterType characterType) {
        Character character = new EnemyCharacter(characterType);
        return character;
    }

    public static Character GetPlayerCharacter(CharacterType character) {
        return null;
    }
}
