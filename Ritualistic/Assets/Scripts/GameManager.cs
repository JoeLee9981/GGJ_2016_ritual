using UnityEngine;
using System.Collections;

public class GameManager {
    private static GameManager gameController;

    public PlayerController PlayerController { get; private set; }

    public bool Active;
    public bool Dead;

    public static GameManager GetInstance() {
        if (gameController == null) {
            gameController = new GameManager();
        }
        return gameController;
    }

    private GameManager() {
        Active = true;
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
        if(gameObject != null) {
            PlayerController = gameObject.GetComponent<PlayerController>();
        }
    }
}
