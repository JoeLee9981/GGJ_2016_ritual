using UnityEngine;

public class DoorController : MonoBehaviour
{
    private PlayerController player;
    private bool isOpen;
    private Vector3 openPosition;

    public SpecialKey CorrespondingKey;

    // Use this for initialization
    void Start()
    {
        isOpen = false;
        openPosition = transform.position;
        player = GameManager.GetInstance().PlayerController;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && PlayerHasCorrectKey() && !isOpen)
            OpenDoor();
    }

    private bool PlayerHasCorrectKey()
    {
        return player.playerCharacter.HasKey(CorrespondingKey);
    }

    private void OpenDoor()
    {
        if (transform.position.y > -1.5f)
            transform.position -= new Vector3(0, openPosition.y, 0);

        player.playerCharacter.RemoveFromInventory(new KeyItem(CorrespondingKey.ToString(), CorrespondingKey));
        isOpen = true;
    }
}

public enum SpecialKey
{
    HI_KEY,
    LOW_KEY
}
