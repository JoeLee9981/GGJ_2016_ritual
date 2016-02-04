using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private GameManager manager;
    private PlayerController playerController;

    // Use this for initialization
    void Start() {
        manager = GameManager.GetInstance();
        playerController = manager.PlayerController;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            if (manager.Active) {
                PauseGame();
            }
            else {
                ResumeGame();
            }
        }
        if (Input.GetButtonDown("Action")) {
            if (manager.Dead) {
                //revive and resume
                ResetPlayerCharacter();
                GameObject gameOverCanvas = GameObject.FindGameObjectWithTag("GameOver");
                if (gameOverCanvas != null) {
                    gameOverCanvas.GetComponent<Canvas>().enabled = false;
                }
                ResumeGame();
            }
        }
    }

    private void ResetPlayerCharacter() {
        playerController.GetComponent<PlayerController>().ResetPlayer();
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
        GameObject gameOverCanvas = GameObject.FindGameObjectWithTag("GameOver");
        if(gameOverCanvas != null) {
            gameOverCanvas.GetComponent<Canvas>().enabled = true;
        }
        manager.Dead = true;
    }
}
