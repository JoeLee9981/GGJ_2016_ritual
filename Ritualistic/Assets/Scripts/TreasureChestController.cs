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
        }
    }
}
