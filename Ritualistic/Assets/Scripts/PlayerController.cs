using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Ritual {
    NONE,
    EARTH,
    AIR,
    FIRE,
    WATER,
    METAL,
};

public class PlayerController : MonoBehaviour {
    public float TurnSpeed;
    public Vector3 Direction;

    //container class for player character stats and behavior
    public PlayerCharacter playerCharacter;
    public Character activeCharacter;

    private GameController controller;

    // Use this for initialization
    void Start() {
        playerCharacter = CharacterFactory.GetPlayerCharacter(CharacterType.PLAYER) as PlayerCharacter;
        activeCharacter = playerCharacter;

        GameObject gameObj = GameObject.FindGameObjectWithTag("GameController");
        if (gameObj != null) {
            controller = gameObj.GetComponent<GameController>();
        }
    }

    // Update is called once per frame
    void Update() {

        if (GameManager.GetInstance().Active) {
            if (activeCharacter.IsDead()) {
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
                transform.position += Direction.normalized * playerCharacter.MovementSpeed * Time.deltaTime;
            }

            if (Input.GetButtonDown("Ritual")) {
                UpdateMesh();
            }
            if (Input.GetButtonDown("Rotate")) {
                playerCharacter.RotateRitual();
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

    void OnCollisionEnter(Collision col) {

        foreach (ContactPoint c in col.contacts) {

            if (c.thisCollider.name == "SwordCollider" && (Input.GetKey("space") || Input.GetKey("mouse 0"))) {
                if (col.gameObject.tag == "Monster") {
                    Debug.Log("HIT: " + col.gameObject.name + " for: " + playerCharacter.Damage);
                    MonsterController monsterController = col.gameObject.GetComponent<MonsterController>();
                    monsterController.AddHitText(playerCharacter.Damage.ToString());
                    if (monsterController.DealDamage(playerCharacter.Damage, playerCharacter)) {
                        Destroy(col.gameObject);
                    }
                }
            }
            if (c.thisCollider.name == "PlayerHitBox") {
                if (col.gameObject.tag == "Monster") {
                    activeCharacter.DealDamage(col.gameObject.GetComponent<MonsterController>().enemyCharacter.Damage, activeCharacter as PlayerCharacter);
                    Debug.Log(playerCharacter.Health);
                }
                if (col.gameObject.tag == "Weapon")
                {
                    activeCharacter.DealDamage(col.gameObject.GetComponent<Transform>().root.GetComponent<MonsterController>().enemyCharacter.Damage, activeCharacter as PlayerCharacter);
                    Debug.Log("Hit by Pitchfork");
                }
            }
        }
    }

    private void UpdateMesh() {

        foreach (GameObject obj in activeCharacter.CharacterMeshes) {
            obj.GetComponent<MeshRenderer>().enabled = false;
        }
        switch (playerCharacter.GetRitualForm()) {
            case Ritual.AIR:
                activeCharacter = CharacterFactory.GetPlayerCharacter(CharacterType.AIR_DEMON);
                break;
            case Ritual.EARTH:
                activeCharacter = CharacterFactory.GetPlayerCharacter(CharacterType.EARTH_DEMON);
                break;
            case Ritual.FIRE:
                activeCharacter = CharacterFactory.GetPlayerCharacter(CharacterType.FIRE_DEMON);
                break;
            case Ritual.METAL:
                activeCharacter = CharacterFactory.GetPlayerCharacter(CharacterType.METAL_DEMON);
                break;
            case Ritual.WATER:
                activeCharacter = CharacterFactory.GetPlayerCharacter(CharacterType.WATER_DEMON);
                break;
            default:
                activeCharacter = playerCharacter;
                break;
        }
        foreach (GameObject obj in activeCharacter.CharacterMeshes) {
            obj.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void ResetPlayer() {
        transform.position = GameProperties.GetDefaultPlayerVector();
        playerCharacter.Health = GameProperties.PLAYER_DEFAULT_HEALTH;
        playerCharacter.Armor = GameProperties.PLAYER_DEFAULT_ARMOR;
        playerCharacter.Damage = GameProperties.PLAYER_DEFAULT_DAMAGE;
    }

	void OnGUI()
	{
		GUI.Label(new Rect(100,100,500,500), "HP:  " + activeCharacter.Health);
		GUI.Label(new Rect(100,200,500,500),  "Ritual:  " + playerCharacter.GetRitualForm().ToString());

	}
}