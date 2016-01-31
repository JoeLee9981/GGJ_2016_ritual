using UnityEngine;
using System.Collections;
using System;

public abstract class Character {

    protected Action<PlayerCharacter> OnDeathAction;

    public int MaxHealth;

    private int health;
    public int Health {
        set {
            if (value <= MaxHealth) {
                health = value;
            }
            else {
                health = MaxHealth;
            }
        }
        get {
            return health;
        }
    }

    private float armor;
    public float Armor {
        get {
            return armor;
        }
        set {
            armor = value + (value * ArmorBonus);
        }
    }
    private float armorBonus;
    public float ArmorBonus {
        get {
            return armorBonus;
        }
        set {
            armorBonus = value;
            Armor += Armor * value;
        }
    }

    public int Damage;

    public float AttackSpeedBonus = GameProperties.DEFAULT_ATTACK_BONUS;

    private float attackSpeed = GameProperties.DEFAULT_ATTACK_SPEED;
    public float AttackSpeed {
        get {
            return attackSpeed + (attackSpeed * AttackSpeedBonus);
        }
        set {
            attackSpeed = value;
        }
    }

    private float movementSpeed = GameProperties.DEFAULT_MOVEMENT_SPEED;
    public float MovementSpeed {
        get {
            return movementSpeed + (movementSpeed * SpeedBonus);
        }
        set {
            movementSpeed = value;
        }
    }

    public float SpeedBonus = GameProperties.DEFAULT_MOVEMENT_BONUS;

    //TODO Change this to switch out mesh
    public GameObject[] CharacterMeshes;

    //returns true if character is dead
    public bool IsDead() {
        return Health <= 0;
    }

    public bool DealDamage(int damageAmt, PlayerCharacter player) {
        if (Health <= 0) {
            return true;
        }
        Health = Health - (damageAmt - (int)(damageAmt * Armor));

        if (OnDeathAction != null) {
            OnDeathAction(player);
        }
        return IsDead();
    }
}
