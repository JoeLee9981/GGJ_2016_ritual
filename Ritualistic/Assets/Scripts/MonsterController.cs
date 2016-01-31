using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
    public Vector3 Direction;
    public Transform[] Waypoints;
    private int currentWaypoint;

    // Collision Detection Rays
    private int range;
    private bool playerCollisionDetected;
    private bool collisionDetected;
    private RaycastHit hit;
    private float rotationSpeed;
    public GameObject target;

    public CharacterType characterType;
    public Character enemyCharacter;
    private PlayerController playerController;

    // Use this for initialization
    void Start() {
        enemyCharacter = CharacterFactory.GetEnemyCharacter(characterType);
        currentWaypoint = 0;
        range = 80;
        rotationSpeed = 15f;

        GameObject playerObject = GameManager.GetInstance().ActivePlayer;
        if (playerObject != null) {
            playerController = playerObject.GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.GetInstance().Active) {
            if (collisionDetected || !playerCollisionDetected) {
                if (Vector3.Distance(transform.position, Waypoints[currentWaypoint].position) < .1 || collisionDetected) {
                    CycleWaypoint();
                }

                //transform.position += GetDirectionVector(transform.position, Waypoints[currentWaypoint].position) * enemyCharacter.MovementSpeed * Time.deltaTime;
            }
            else {
                if (Vector3.Distance(transform.position, GameManager.GetInstance().ActivePlayer.transform.position) < 7f) {
                    Vector3 transformVec = GetDirectionVector(transform.position, GameManager.GetInstance().ActivePlayer.transform.position) * enemyCharacter.MovementSpeed * Time.deltaTime;
                    transformVec.y = 0;
                    transform.position += transformVec;
                }
                else {
                    playerCollisionDetected = false;
                }
            }
        }

        PerformCollisionDetection();
    }

    void FixedUpdate() {

        if (GameManager.GetInstance().Active) {
            // Generate a plane that intersects the transform's position with an upwards normal.
            Plane playerPlane = new Plane(Vector3.up, transform.position);

            // Generate a ray from the cursor position
            Ray ray = Camera.main.ScreenPointToRay(playerController.GetComponent<Transform>().position);

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
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter(Collision col) {

        if (col.gameObject.name == "Hero") {

            //playerController.activeCharacter.DealDamage(enemyCharacter.Damage, (PlayerCharacter)playerController.activeCharacter);
            //Debug.Log(playerController.activeCharacter.Health);
        }
    }


    private void PerformCollisionDetection() {

        Vector3 rayDirection = playerController.transform.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit, range)) {
            if (hit.collider.gameObject.CompareTag("Player")) {
                playerCollisionDetected = true;
                transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
            }
            if (hit.collider.gameObject.CompareTag("Walls")) {
                collisionDetected = true;
            }
        }
        /*
        // Collision Detection Rays - Front
        Transform leftRay = transform;
        Transform rightRay = transform;

        if (Physics.Raycast(leftRay.position + (transform.right * 7), transform.forward, out hit, range)
            || Physics.Raycast(rightRay.position - (transform.right * 7), transform.forward, out hit, range))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                playerCollisionDetected = true;
            }
            if (hit.collider.gameObject.CompareTag("Walls"))
            {
                collisionDetected = true;
                transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
            }
        }

        // Collision Detection Rays - Back
        if (Physics.Raycast(transform.position - (transform.forward * 4), transform.right, out hit, 10)
            || Physics.Raycast(transform.position - (transform.forward * 4), -transform.right, out hit, 10))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                playerCollisionDetected = true;
            }
            if (hit.collider.gameObject.CompareTag("Walls"))
            {
                collisionDetected = false;
            }
        }*/
    }

    public bool DealDamage(int damage, PlayerCharacter character) {
        return enemyCharacter.DealDamage(damage, character);
    }

    private Vector3 GetDirectionVector(Vector3 coord1, Vector3 coord2) {
        return (coord2 - coord1) / (coord2 - coord1).magnitude;
    }

    private void CycleWaypoint() {
        currentWaypoint++;
        if (currentWaypoint >= Waypoints.Length) {
            currentWaypoint = 0;
        }
    }
}
