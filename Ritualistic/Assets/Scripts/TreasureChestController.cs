using UnityEngine;
using System.Collections;

public class TreasureChestController : MonoBehaviour {

    private bool isOpen;

    public SpecialKey keyType;
    
    void OnMouseDown()
    {
        if(!isOpen)
        {
            GetComponent<Animation>().Play("OpenChest");
            GameObject playerObject = GameManager.GetInstance().ActivePlayer;
            PlayerController player = playerObject.GetComponent<PlayerController>();
            player.playerCharacter.AddToInventory(new KeyItem(keyType.ToString(), keyType));
            isOpen = true;
            StartCoroutine(TakeKey());
        }
    }
    
    private IEnumerator TakeKey()
    {
        yield return new WaitForSeconds(1.5f);
        Transform keyObject = null;
        GameObject prefabObject = transform.parent.gameObject;
        if (keyType.ToString() == "LOW_KEY")
        {
            keyObject = prefabObject.GetComponentInChildren<Transform>().Find("basickey");
            keyObject.FindChild("pPipe6").GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            prefabObject.GetComponentInChildren<Transform>().Find("specialkey");
            keyObject.FindChild("pCylinder6").GetComponent<MeshRenderer>().enabled = false;
        }        
    }
}
