using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

    public float Speed;
    public Vector3 Direction;
    public Transform[] Waypoints;
    private int currentWaypoint;

	// Use this for initialization
	void Start () {
        currentWaypoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.GetInstance().Active) {
            if (!CanSeePlayer()) {
                if (Vector3.Distance(transform.position, Waypoints[currentWaypoint].position) < .1) {
                    CycleWaypoint();
                }

                transform.position += GetDirectionVector(transform.position, Waypoints[currentWaypoint].position) * Speed;
            }
            else {
                transform.position += GetDirectionVector(transform.position, GameManager.GetInstance().ActivePlayer.transform.position) * Speed;
            }
        }
    }

    private Vector3 GetDirectionVector(Vector3 coord1, Vector3 coord2) {
        return (coord2 - coord1) / (coord2 - coord1).magnitude;
    }

    private void CycleWaypoint() {
        currentWaypoint++;
        if(currentWaypoint >= Waypoints.Length) {
            currentWaypoint = 0;
        }
    }

    private bool CanSeePlayer() {
        return false;
    }
}
