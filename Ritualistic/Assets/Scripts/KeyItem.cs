using UnityEngine;
using System.Collections;
using System;

public class KeyItem : Item {

    public SpecialKey KeyType;

    public KeyItem(string itemName, SpecialKey keyType) : base(ItemType.KEY, itemName) {
        this.KeyType = keyType;

    }

    public override void OnPickUp(PlayerCharacter character) {
        character.AddToInventory(this);
    }

    public override void OnRemove(PlayerCharacter character) {
        //do nothing for keys
    }
}
