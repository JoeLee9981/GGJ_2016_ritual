using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    GameManager manager;

    // Use this for initialization
    void Start () {
        manager = GameManager.GetInstance();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel")) {
            if(manager.Active) {
                PauseGame();
            }
            else {
                ResumeGame();
            }
        }
        if(Input.GetButtonDown("Action")) {
            if(manager.Dead) {
                //revive and resume
                ResetPlayerCharacter();
                ResumeGame();
            }
        }
    }

    private void ResetPlayerCharacter() {
        if (manager.ActivePlayer != null) {
            manager.ActivePlayer.GetComponent<PlayerController>().ResetPlayer();
        }
    }

    private void PauseGame() {
        Time.timeScale = 0;
        manager.Active = false;
    }

    private void ResumeGame() {
        Time.timeScale = 1;
        manager.Active = true;
    }

    public void GameOver() {
        /**
         *  Perform game over clean up here
         */
        PauseGame();
        manager.Dead = true;
    }
}
