using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCharacter : Character {

    public CharacterType characterType;
    protected List<Item> Inventory;
    protected List<Ritual> ActiveRituals;
    private int selectedRitual;


    public PlayerCharacter(CharacterType characterType) {
        this.characterType = characterType;
        SetupCharacter();
        Inventory = new List<Item>();
        //set the ritual
        selectedRitual = 0;
        ActiveRituals = new List<Ritual>();
        //add no rituals to list of available
        AddRitual(Ritual.NONE);
    }

    private void SetupCharacter() {
        switch (characterType) {
            case CharacterType.METAL_DEMON:
                SetupMetal();
                break;
            case CharacterType.AIR_DEMON:
                SetupAir();
                break;
            case CharacterType.FIRE_DEMON:
                SetupFire();
                break;
            case CharacterType.WATER_DEMON:
                SetupWater();
                break;
            case CharacterType.EARTH_DEMON:
                SetupEarth();
                break;
            default:
                SetupPlayer();
                break;

        }
    }

    private void SetupPlayer() {
        MaxHealth = GameProperties.PLAYER_DEFAULT_HEALTH;
        Armor = GameProperties.PLAYER_DEFAULT_ARMOR;
        Damage = GameProperties.PLAYER_DEFAULT_DAMAGE;
        Health = MaxHealth;
        CharacterMeshes = GameObject.FindGameObjectsWithTag(GameProperties.PLAYER_MESH);
    }
    private void SetupAir() {
        MaxHealth = GameProperties.AIR_HEALTH;
        Armor = GameProperties.AIR_ARMOR;
        Damage = GameProperties.AIR_DAMAGE;
        SpeedBonus = GameProperties.AIR_SPEED;
        Health = MaxHealth;
        CharacterMeshes = GameObject.FindGameObjectsWithTag(GameProperties.AIR_MESH); ;
    }

    private void SetupMetal() {
        MaxHealth = GameProperties.METAL_HEALTH;
        Armor = GameProperties.METAL_ARMOR;
        Damage = GameProperties.METAL_DAMAGE;
        AttackSpeedBonus = GameProperties.METAL_ATTACK_SPEED;
        Health = MaxHealth;
        CharacterMeshes = GameObject.FindGameObjectsWithTag(GameProperties.METAL_MESH); ;
    }

    private void SetupFire() {
        MaxHealth = GameProperties.FIRE_HEALTH;
        Armor = GameProperties.FIRE_ARMOR;
        Damage = GameProperties.FIRE_DAMAGE;
        Health = MaxHealth;
        CharacterMeshes = GameObject.FindGameObjectsWithTag(GameProperties.FIRE_MESH); ;
    }

    private void SetupEarth() {
        MaxHealth = GameProperties.EARTH_HEALTH;
        Armor = GameProperties.EARTH_ARMOR;
        Damage = GameProperties.EARTH_DAMAGE;
        Health = MaxHealth;
        CharacterMeshes = GameObject.FindGameObjectsWithTag(GameProperties.EARTH_MESH); ;
    }

    private void SetupWater() {
        MaxHealth = GameProperties.WATER_HEALTH;
        Armor = GameProperties.WATER_ARMOR;
        Damage = GameProperties.WATER_DAMAGE;
        Health = MaxHealth;
        CharacterMeshes = GameObject.FindGameObjectsWithTag(GameProperties.WATER_MESH); ;
    }

    public void AddToInventory(Item item) {
        Inventory.Add(item);
    }

    public void RemoveFromInventory(Item item) {
        Inventory.Remove(item);
        item.OnRemove(this);
    }

    public bool InventoryContains(Item item) {
        return Inventory.Contains(item);
    }

    public bool InventoryContains(string ItemName) {
        foreach (Item item in Inventory) {
            if (item.ItemName.Equals(ItemName)) {
                return true;
            }
        }
        return false;
    }

    public bool HasKey(SpecialKey key) {
        foreach (Item item in Inventory) {
            if (item is KeyItem) {
                KeyItem keyItem = item as KeyItem;
                if (keyItem.KeyType == key) {
                    return true;
                }
            }
        }
        return false;
    }

    public void ClearInventory() {
        foreach (Item item in Inventory) {
            item.OnRemove(this);
        }
        Inventory.Clear();
    }

    public void AddRitual(Ritual ritual) {
        if (!ActiveRituals.Contains(ritual)) {
            ActiveRituals.Add(ritual);
        }
    }

    public void ClearRituals() {
        ActiveRituals.Clear();
    }

    public void RotateRitual() {
        selectedRitual++;
        if (selectedRitual >= ActiveRituals.Count) {
            selectedRitual = 0;
        }
    }

    public Ritual GetRitualForm() {
        return ActiveRituals[selectedRitual];
    }


}
