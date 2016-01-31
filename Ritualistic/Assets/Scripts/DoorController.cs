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
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
            OpenDoor();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && PlayerHasCorrectKey())
            isOpen = true;
    }

    private bool PlayerHasCorrectKey()
    {
        GameObject playerObject = GameManager.GetInstance().ActivePlayer;
        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerController>();
            return player.playerCharacter.HasKey(CorrespondingKey);
        }

        return false;
    }

    private void OpenDoor()
    {
        if (transform.position.y > -1.5f)
            transform.position -= new Vector3(0, openPosition.y, 0);

        player.playerCharacter.RemoveFromInventory(new KeyItem(CorrespondingKey.ToString(), CorrespondingKey));
    }
}

public enum SpecialKey
{
    HI_KEY,
    LOW_KEY
}
