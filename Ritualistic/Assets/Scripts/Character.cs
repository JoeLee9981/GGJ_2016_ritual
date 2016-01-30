using UnityEngine;
using System.Collections;

public abstract class Character {

    public float MaxHealth;

    private float health;
    public float Health {
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

    public float Armor;
    public float Damage;

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
    public Color CharacterMesh;

    //returns true if character is dead
    public bool IsDead() {
        return Health <= 0;
    }

    public bool DealDamage(float damageAmt) {
        health -= damageAmt - (damageAmt * Armor);

        return IsDead();
    }
}
