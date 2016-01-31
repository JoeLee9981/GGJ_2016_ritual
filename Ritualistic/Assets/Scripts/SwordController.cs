using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnterChild(Collision col) {
        print("test");
        if (col.gameObject.name == "Monster") {
            Destroy(col.gameObject);
        }
    }
}
