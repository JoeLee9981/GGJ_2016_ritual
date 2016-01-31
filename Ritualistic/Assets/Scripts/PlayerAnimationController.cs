using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey("space"))
        {
            GetComponent<Animation>().Play("Attack");
        }
        else if (Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("w") || Input.GetKey("s"))
        {
            GetComponent<Animation>().Play("Walk");
        }
        /*else
        {
            GetComponent<Animation>().Play("Idle");
        }
        */
    }
}
