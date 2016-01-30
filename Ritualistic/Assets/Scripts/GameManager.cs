using UnityEngine;
using System.Collections;

public class GameManager {
    private static GameManager gameController;

    private GameObject _activePlayer;
    public GameObject ActivePlayer {
        get {
            if (_activePlayer == null)
                _activePlayer = GameObject.FindGameObjectWithTag("Player");
            return _activePlayer;
        }
    }

    private GameObject _mainFloor;
    public GameObject MainFloor {
        get {
            if (_mainFloor == null)
                _mainFloor = GameObject.FindGameObjectWithTag("MainFloor");
            return _mainFloor;
        }
    }

    public bool Active;

    public static GameManager GetInstance() {
        if (gameController == null) {
            gameController = new GameManager();
        }
        return gameController;
    }

    private GameManager() {
        Active = true;
    }
}
