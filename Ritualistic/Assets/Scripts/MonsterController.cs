using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour
{

    public float Speed;
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

    // Use this for initialization
    void Start()
    {
        currentWaypoint = 0;
        range = 80;
        rotationSpeed = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetInstance().Active)
        {
            if (collisionDetected || !playerCollisionDetected)
            {
                if (Vector3.Distance(transform.position, Waypoints[currentWaypoint].position) < .1 || collisionDetected)
                {
                    CycleWaypoint();
                }

                transform.position += GetDirectionVector(transform.position, Waypoints[currentWaypoint].position) * Speed * Time.deltaTime;
            }
            else {
                if (Vector3.Distance(transform.position, GameManager.GetInstance().ActivePlayer.transform.position) < 7f)
                {
                    transform.position += GetDirectionVector(transform.position, GameManager.GetInstance().ActivePlayer.transform.position) * Speed * Time.deltaTime;
                }
                else {
                    playerCollisionDetected = false;
                }
            }
        }

        PerformCollisionDetection();
    }

    private void PerformCollisionDetection()
    {
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
        }
    }

    private Vector3 GetDirectionVector(Vector3 coord1, Vector3 coord2)
    {
        return (coord2 - coord1) / (coord2 - coord1).magnitude;
    }

    private void CycleWaypoint()
    {
        currentWaypoint++;
        if (currentWaypoint >= Waypoints.Length)
        {
            currentWaypoint = 0;
        }
    }
}
