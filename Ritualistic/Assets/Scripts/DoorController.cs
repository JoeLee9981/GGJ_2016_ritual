using UnityEngine;
using System.Collections;
using System;

public class DoorController : MonoBehaviour {

    private bool isOpen;
    private Vector3 openPosition;
    private float moveSpeed = 1.0f;

    public bool RequiresKey;

    public SpecialKey CorrespondingKey;

	// Use this for initialization
	void Start () {
        isOpen = false;
        openPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (isOpen)
            OpenDoor();
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if(RequiresKey)
            {
                if (PlayerHasCorrectKey())
                    isOpen = true;
            }
            else
            {
                isOpen = true;
            }
        }
    }

    private bool PlayerHasCorrectKey()
    {
        GameObject playerObject = GameManager.GetInstance().ActivePlayer;
        if(playerObject != null)
        {
            PlayerController player = playerObject.GetComponent<PlayerController>();
            return player.playerCharacter.InventoryContains(new KeyItem(CorrespondingKey.ToString(), CorrespondingKey));
        }

        return false;
    }

    private void OpenDoor()
    {
        if(transform.position.y > -1.5f)
            transform.position -= new Vector3(0, openPosition.y, 0);
    }
}

public enum SpecialKey
{
    FIRE_KEY,
    EARTH_KEY,
    METAL_KEY,
    WATER_KEY,
    AIR_KEY,
    AIR2_KEY,
    NO_KEY
}
