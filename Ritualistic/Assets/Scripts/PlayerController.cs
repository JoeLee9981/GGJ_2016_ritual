using UnityEngine;
using System.Collections;

public enum Ritual {
    NONE,
    EARTH,
    AIR,
    FIRE,
    WATER,
    METAL,
};

public class PlayerController : MonoBehaviour {
    public float Speed;
    public float TurnSpeed;
    public Vector3 Direction;
    public Ritual ActiveRitual;
    public Ritual ActiveForm;
    //container class for player character stats and behavior
    public PlayerCharacter playerCharacter;

    private GameController controller;

    private bool XDown;
    private bool YDown;


    // Use this for initialization
    void Start() {
        playerCharacter = new PlayerCharacter();
        ActiveRitual = Ritual.NONE;
        GameObject gameObj = GameObject.FindGameObjectWithTag("GameController");
        if (gameObj != null) {
            controller = gameObj.GetComponent<GameController>();
        }
    }

    // Update is called once per frame
    void Update() {

        if (GameManager.GetInstance().Active) {
            if (playerCharacter.IsDead()) {
                controller.GameOver();
            }

            if (Input.GetKey("d")) {
                Direction.x = 1;
            }
            else if (Input.GetKey("a")) {
                Direction.x = -1;
            }
            else {
                Direction.x = 0;
            }

            if (Input.GetKey("w")) {
                Direction.z = 1;
            }
            else if (Input.GetKey("s")) {
                Direction.z = -1;
            }
            else {
                Direction.z = 0;
            }

            if (Direction.x != 0 || Direction.z != 0) {
                transform.position += Direction.normalized * Speed * Time.deltaTime;
            }

            if (Input.GetButtonDown("Ritual")) {
                UpdateMesh();
            }
            if (Input.GetButtonDown("Rotate")) {
                RotateRitual();
            }

            if (transform.position.y < -30) {
                playerCharacter.Health = 0;
            }
        }
    }
    void FixedUpdate() {

        if (GameManager.GetInstance().Active) {
            // Generate a plane that intersects the transform's position with an upwards normal.
            Plane playerPlane = new Plane(Vector3.up, transform.position);

            // Generate a ray from the cursor position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Determine the point where the cursor ray intersects the plane.
            // This will be the point that the object must look towards to be looking at the mouse.
            // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
            //   then find the point along that ray that meets that distance.  This will be the point
            //   to look at.
            float hitdist = 0.0f;
            // If the ray is parallel to the plane, Raycast will return false.
            if (playerPlane.Raycast(ray, out hitdist)) {
                // Get the point along the ray that hits the calculated distance.
                Vector3 targetPoint = ray.GetPoint(hitdist);

                // Determine the target rotation.  This is the rotation if the transform looks at the target point.
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

                // Smoothly rotate towards the target point.
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
            }
        }
    }

    private void UpdateMesh() {

        Debug.Log("You have pressed R");
        switch (ActiveRitual) {
            case Ritual.AIR:
                GameManager.GetInstance().ActivePlayer.GetComponent<Renderer>().material.color = Color.magenta;
                break;
            case Ritual.EARTH:
                GameManager.GetInstance().ActivePlayer.GetComponent<Renderer>().material.color = Color.green;
                break;
            case Ritual.FIRE:
                GameManager.GetInstance().ActivePlayer.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case Ritual.METAL:
                GameManager.GetInstance().ActivePlayer.GetComponent<Renderer>().material.color = Color.grey;
                break;
            case Ritual.WATER:
                GameManager.GetInstance().ActivePlayer.GetComponent<Renderer>().material.color = Color.blue;
                break;
            default:
                GameManager.GetInstance().ActivePlayer.GetComponent<Renderer>().material.color = Color.red;
                break;
        }
    }

    private void RotateRitual() {
        ActiveRitual++;
        if (ActiveRitual > Ritual.METAL) {
            ActiveRitual = 0;
        }
    }

    public void ResetPlayer() {
        transform.position = GameProperties.GetDefaultPlayerVector();
        playerCharacter.Health = GameProperties.PLAYER_DEFAULT_HEALTH;
        playerCharacter.Armor = GameProperties.PLAYER_DEFAULT_ARMOR;
        playerCharacter.Damage = GameProperties.PLAYER_DEFAULT_DAMAGE;
    }
}