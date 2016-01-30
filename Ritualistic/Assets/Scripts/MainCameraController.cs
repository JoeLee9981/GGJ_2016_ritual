using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {
    private PlayerController player;
    private GameObject mainFloor;
	// Use this for initialization
	void Start () {
        GameObject playerObject = GameController.GetInstance().ActivePlayer;
        if(playerObject != null)
        {
            player = playerObject.GetComponent<PlayerController>();
        }
        mainFloor = GameController.GetInstance().MainFloor;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += player.Direction * player.Speed;
        if(transform.position.x < mainFloor.transform.position.x)
        {
            //setPositionX(mainFloor.transform.position.x - 10);
        }
	}

    private void setPositionX(float x)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
