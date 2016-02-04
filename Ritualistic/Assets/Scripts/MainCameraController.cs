using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {
    private PlayerController player;
    public Vector3 Offset;

    // Use this for initialization
    void Start() {
        player = GameManager.GetInstance().PlayerController;
    }

    // Update is called once per frame
    void Update()
    {
        Offset.y -= Input.GetAxis("Mouse ScrollWheel");
        if (Offset.y > 5) { Offset.y = 5; }
        if (Offset.y < 1) { Offset.y = 1; }
    }

    void LateUpdate() {
        if (GameManager.GetInstance().Active) {
            transform.position = player.transform.position + Offset;
        }
    }
    /*
    private void setPositionX(float x) {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }*/
}
