using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel")) {
            if(Time.timeScale == 0) {
                Time.timeScale = 1;
            }
            else {
                Time.timeScale = 0;
            }
            GameManager.GetInstance().Active = !GameManager.GetInstance().Active;
        }

    }

    public void GameOver() {
        /**
         *  Perform game over clean up here
         */
        GameManager.GetInstance().Active = false;
    }
}
