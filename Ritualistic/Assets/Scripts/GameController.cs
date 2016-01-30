using UnityEngine;
using System.Collections;

public class GameController
{
    private static GameController gameController;

    private GameObject _activePlayer;
    public GameObject ActivePlayer
    {
        get
        {
            if(_activePlayer == null)
                _activePlayer = GameObject.FindGameObjectWithTag("Player");
            return _activePlayer;
        }
    }

    private GameObject _mainFloor;
    public GameObject MainFloor
    {
        get
        {
            if (_mainFloor == null)
                _mainFloor = GameObject.FindGameObjectWithTag("MainFloor");
            return _mainFloor;
        }
    }    

    public static GameController GetInstance()
    {
        if(gameController == null)
        {
            gameController = new GameController();
        }
        return gameController;
    }

    private GameController()
    {
    }
}
