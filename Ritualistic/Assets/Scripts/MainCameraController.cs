using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {
    private PlayerController player;
    public Vector3 Offset;

    // Use this for initialization
    void Start() {
        GameObject playerObject = GameManager.GetInstance().ActivePlayer;
        if (playerObject != null) {
            player = playerObject.GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    void LateUpdate() {
        if (GameManager.GetInstance().Active) {
            transform.position = player.transform.position + Offset;
        }
    }

    private void setPositionX(float x) {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
