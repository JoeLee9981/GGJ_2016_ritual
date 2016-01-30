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

    // Use this for initialization
    void Start() {
        ActiveRitual = Ritual.NONE;
    }

    // Update is called once per frame
    void Update() {
        Direction.x = Input.GetAxis("Horizontal");
        Direction.z = Input.GetAxis("Vertical");
        transform.position += Direction * Speed;

        if (Input.GetButtonDown("Ritual")) {
            UpdateMesh();
        }
        if (Input.GetButtonDown("Rotate")) {
            RotateRitual();
        }
    }
    void FixedUpdate() {
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

    private void UpdateMesh() {

        Debug.Log("You have pressed R");
        switch (ActiveRitual) {
            case Ritual.AIR:
                GameController.GetInstance().ActivePlayer.GetComponent<Renderer>().material.color = Color.magenta;
                break;
            case Ritual.EARTH:
                GameController.GetInstance().ActivePlayer.GetComponent<Renderer>().material.color = Color.green;
                break;
            case Ritual.FIRE:
                GameController.GetInstance().ActivePlayer.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case Ritual.METAL:
                GameController.GetInstance().ActivePlayer.GetComponent<Renderer>().material.color = Color.grey;
                break;
            case Ritual.WATER:
                GameController.GetInstance().ActivePlayer.GetComponent<Renderer>().material.color = Color.blue;
                break;
            default:
                GameController.GetInstance().ActivePlayer.GetComponent<Renderer>().material.color = Color.red;
                break;
        }
    }

    private void RotateRitual() {
        ActiveRitual++;
        if (ActiveRitual > Ritual.METAL) {
            ActiveRitual = 0;
        }
    }
}