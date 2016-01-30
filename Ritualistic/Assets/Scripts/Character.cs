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

    //returns true if character is dead
    public bool IsDead() {
        return Health <= 0;
    }

    public bool DealDamage(float damageAmt) {
        health -= damageAmt - (damageAmt * Armor);

        return IsDead();
    }
}
