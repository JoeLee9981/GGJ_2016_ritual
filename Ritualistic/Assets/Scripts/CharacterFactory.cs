using UnityEngine;
using System.Collections;
public enum CharacterType {
    EARTH_DEMON,
    AIR_DEMON,
    WATER_DEMON,
    FIRE_DEMON,
    METAL_DEMON,
    ENEMY,
    BOSS
}

public static class CharacterFactory {

	public static Character GetCharacter(CharacterType characterType) {
        Character character = new EnemyCharacter(characterType);
        return character;
    }
}
