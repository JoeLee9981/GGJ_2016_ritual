using UnityEngine;
using System.Collections;
using System;

public class DoorController : MonoBehaviour {

    private bool isOpen;
    private Vector3 openPosition;

    public bool RequiresKey { get; set; }

    public SpecialKey CorrespondingKey { get; set; }

	// Use this for initialization
	void Start () {
        isOpen = false;
        openPosition = new Vector3(0f, -1.5f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if(RequiresKey)
            {
                if(PlayerHasCorrectKey())
                    OpenDoor();
            }
            else
            {
                OpenDoor();
            }
        }
    }

    private bool PlayerHasCorrectKey()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //return player.HasKey(CorrespondingKey);
        return true;
    }

    private void OpenDoor()
    {
        if(!isOpen)
        {
            transform.position += new Vector3(0, -1.5f, 0);
        }
    }
}

public enum SpecialKey
{
    FIRE_KEY,
    EARTH_KEY,
    METAL_KEY,
    WATER_KEY,
    AIR_KEY,
    AIR2_KEY
}
