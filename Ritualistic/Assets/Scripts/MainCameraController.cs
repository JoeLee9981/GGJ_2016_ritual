using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {
    private PlayerController player;
    private GameObject mainFloor;

    public Vector3 Offset;

    // Use this for initialization
    void Start() {
        GameObject playerObject = GameManager.GetInstance().ActivePlayer;
        if (playerObject != null) {
            player = playerObject.GetComponent<PlayerController>();
        }
        mainFloor = GameManager.GetInstance().MainFloor;
    }

    // Update is called once per frame
    void Update() {
        
    }

    void LateUpdate() {
        if (GameManager.GetInstance().Active) {
            transform.position = player.transform.position + Offset;
            if (transform.position.x < mainFloor.transform.position.x) {
                //setPositionX(mainFloor.transform.position.x - 10);
            }
        }
    }

    private void setPositionX(float x) {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
