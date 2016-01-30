using UnityEngine;
using System.Collections;

public enum ItemType {
    KEY,
    ARMOR
}

public abstract class Item {

    public ItemType ItemType;
    public string ItemName { get; private set; }

    public Item(ItemType type, string itemName) {
        this.ItemType = type;
        this.ItemName = itemName;
    }

    public abstract void OnPickUp(PlayerCharacter character);
    public abstract void OnRemove(PlayerCharacter character);

    public override bool Equals(object obj) {
        if(obj is Item) {
            Item other = obj as Item;
            return ItemName.Equals(other.ItemName);
        }
        return false;
    }

    public override int GetHashCode() {
        return ItemName.GetHashCode();
    }
}
