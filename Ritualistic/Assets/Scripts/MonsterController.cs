using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    public List<HitText> hitTexts;

    // Use this for initialization
    void Start() {
        enemyCharacter = CharacterFactory.GetEnemyCharacter(characterType, this);
        currentWaypoint = 0;
        range = 160;
        rotationSpeed = 15f;

        playerController = GameManager.GetInstance().PlayerController;

        hitTexts = new List<HitText>();
    }

    // Update is called once per frame
    void Update() {
        for(int i = 0; i < hitTexts.Count; i++) {
            if (hitTexts[i].Display) {
                hitTexts[i].Update();
            }
            else {
                hitTexts.RemoveAt(i);
            }
        }
        if (GameManager.GetInstance().Active) {
            if (collisionDetected || !playerCollisionDetected) {
               /* if (Vector3.Distance(transform.position, Waypoints[currentWaypoint].position) < .1 || collisionDetected) {
                    CycleWaypoint();
                }
                */
                //transform.position += GetDirectionVector(transform.position, Waypoints[currentWaypoint].position) * enemyCharacter.MovementSpeed * Time.deltaTime;
            }
            else {
                if (Vector3.Distance(transform.position, playerController.transform.position) < 7f) {
                    Vector3 transformVec = GetDirectionVector(transform.position, playerController.transform.position) * enemyCharacter.MovementSpeed * Time.deltaTime;
                    transformVec.y = 0;
                    transform.position += transformVec;
                    transform.LookAt(playerController.GetComponent<Transform>());
                }
                else {
                    playerCollisionDetected = false;
                }
            }

        }

        PerformCollisionDetection();
    }

    void FixedUpdate() { 
        if (GameManager.GetInstance().Active) 
            {
                
            }       
    }

    void OnCollisionEnter(Collision col) {

        if (col.gameObject.name == "Hero") {

            //playerController.activeCharacter.DealDamage(enemyCharacter.Damage, (PlayerCharacter)playerController.activeCharacter);
            //Debug.Log(playerController.activeCharacter.Health);
        }
    }

    void OnGUI() {
        foreach(HitText hitText in hitTexts) {
            hitText.OnGUI();
        }
    }

    private void PerformCollisionDetection() {

        Vector3 rayDirection = playerController.transform.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit, range)) {
            if (hit.collider.gameObject.CompareTag("Player")) {
                playerCollisionDetected = true;
            }
            if (hit.collider.gameObject.CompareTag("Walls")) {
                collisionDetected = true;
            }
            else {
                collisionDetected = false;
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

    public int DealDamage(int damage, PlayerCharacter character) {
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

    public void AddHitText(string text) {
        HitText hitText = new HitText();
        hitTexts.Add(hitText);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        hitText.ShowText(text, GameProperties.HITS_TEXT_TIME, screenPos.x, screenPos.y);
    }

    public void DestroyEnemy() {
        Destroy(this.gameObject);
    }
}
