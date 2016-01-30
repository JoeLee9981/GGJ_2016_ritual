using UnityEngine;
using System.Collections;
using System;

public class ArmorItem : Item {

    public float ArmorBonus {
        get;
        private set;
    }

    public ArmorItem(string itemName, float armorBonus) : base(ItemType.ARMOR, itemName) {
        this.ArmorBonus = armorBonus;
    }

    public override void OnPickUp(PlayerCharacter character) {
        character.ArmorBonus += ArmorBonus;
    }

    public override void OnRemove(PlayerCharacter character) {
        character.ArmorBonus -= ArmorBonus;
    }
}
