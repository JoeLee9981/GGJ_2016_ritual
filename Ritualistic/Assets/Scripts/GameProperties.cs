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

    public static Vector3 GetDefaultPlayerVector() {
        return new Vector3(PLAYER_X_START, PLAYER_Y_START, PLAYER_Z_START);
    }
}
